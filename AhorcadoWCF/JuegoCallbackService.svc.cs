using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ServiceModel;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    public class EstadoRonda
    {
        public string Palabra { get; set; }
        public string Categoria { get; set; }
        public int IdAdivinador { get; set; }
        public int IdCreador { get; set; }
        public int IdPalabra { get; set; }
        public int IntentosRestantes { get; set; } = 6;
        public HashSet<char> LetrasUsadas { get; } = new HashSet<char>();
    }

    public static class RegistroSesiones
    {
        public static readonly ConcurrentDictionary<int, IJuegoCallback> Lobby =
            new ConcurrentDictionary<int, IJuegoCallback>();

        public static readonly ConcurrentDictionary<int, ConcurrentDictionary<int, IJuegoCallback>> Salas =
            new ConcurrentDictionary<int, ConcurrentDictionary<int, IJuegoCallback>>();

        public static readonly ConcurrentDictionary<int, EstadoRonda> Rondas =
            new ConcurrentDictionary<int, EstadoRonda>();

        public static readonly ConcurrentDictionary<int, string> IdiomaJugador =
            new ConcurrentDictionary<int, string>();

        public static void RegistrarIdioma(int idUsuario, string idioma) =>
            IdiomaJugador[idUsuario] = idioma;

        public static string ObtenerIdioma(int idUsuario) =>
            IdiomaJugador.TryGetValue(idUsuario, out var idioma) ? idioma : "es";

        public static void IniciarRonda(int idPartida, string palabra, string categoria, int idAdivinador, int idCreador, int idPalabra) =>
            Rondas[idPartida] = new EstadoRonda
            {
                Palabra = palabra,
                Categoria = categoria,
                IdAdivinador = idAdivinador,
                IdCreador = idCreador,
                IdPalabra = idPalabra
            };

        public static void AgregarAlLobby(int idUsuario, IJuegoCallback callback) =>
            Lobby[idUsuario] = callback;

        public static void QuitarDelLobby(int idUsuario) =>
            Lobby.TryRemove(idUsuario, out _);

        public static void UnirASala(int idPartida, int idUsuario, IJuegoCallback callback) =>
            Salas.GetOrAdd(idPartida, _ => new ConcurrentDictionary<int, IJuegoCallback>())[idUsuario] = callback;

        public static void SalirDeSala(int idPartida, int idUsuario)
        {
            if (Salas.TryGetValue(idPartida, out var sala))
            {
                sala.TryRemove(idUsuario, out _);
                if (sala.IsEmpty)
                {
                    Salas.TryRemove(idPartida, out _);
                    Rondas.TryRemove(idPartida, out _);
                }
            }
        }

        public static void SalirDeSalaSi(int idPartida, int idUsuario, IJuegoCallback callback)
        {
            if (Salas.TryGetValue(idPartida, out var sala) &&
                sala.TryGetValue(idUsuario, out var actual) &&
                ReferenceEquals(actual, callback))
            {
                SalirDeSala(idPartida, idUsuario);
            }
        }

        public static void NotificarSala(int idPartida, Action<IJuegoCallback> accion, int? excepto = null)
        {
            if (!Salas.TryGetValue(idPartida, out var sala)) return;
            foreach (var par in sala)
            {
                if (excepto.HasValue && par.Key == excepto.Value) continue;
                try { accion(par.Value); } catch { }
            }
        }

        public static void NotificarJugador(int idPartida, int idUsuario, Action<IJuegoCallback> accion)
        {
            if (Salas.TryGetValue(idPartida, out var sala) && sala.TryGetValue(idUsuario, out var cb))
            {
                try { accion(cb); } catch { }
            }
        }

        public static void NotificarFinPartida(int idPartida, string resultado, string palabra, int puntos, int puntajeGlobal) =>
            NotificarSala(idPartida, cb => cb.PartidaFinalizada(resultado, palabra, puntos, puntajeGlobal));
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class JuegoCallbackService : IJuegoCallbackService
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();
        private readonly MovimientoService movimientoService = new MovimientoService();
        private readonly PuntajeDAO puntajeDAO = new PuntajeDAO();
        private readonly PartidaDAO partidaDAO = new PartidaDAO();

        private const int PuntosVictoria = 10;
        private const int PuntosPenalizacion = 3;

        private static IJuegoCallback CanalActual() =>
            OperationContext.Current.GetCallbackChannel<IJuegoCallback>();

        public void ConectarAlLobby(int idUsuario) =>
            RegistroSesiones.AgregarAlLobby(idUsuario, CanalActual());

        public void DesconectarDelLobby(int idUsuario) =>
            RegistroSesiones.QuitarDelLobby(idUsuario);

        public void UnirseASalaDePartida(int idPartida, int idUsuario, string idioma)
        {
            RegistroSesiones.RegistrarIdioma(idUsuario, idioma);

            var callback = CanalActual();
            RegistroSesiones.UnirASala(idPartida, idUsuario, callback);

            var canal = OperationContext.Current.Channel;
            EventHandler limpiar = null;
            limpiar = (s, e) =>
            {
                RegistroSesiones.SalirDeSalaSi(idPartida, idUsuario, callback);
                canal.Closed -= limpiar;
                canal.Faulted -= limpiar;
            };
            canal.Closed += limpiar;
            canal.Faulted += limpiar;

            var adivinador = usuarioDAO.ObtenerPorId(idUsuario);
            RegistroSesiones.NotificarSala(idPartida, cb => cb.AdivinadorSeUnio(adivinador), excepto: idUsuario);
        }

        public void SalirDeSalaDePartida(int idPartida, int idUsuario) =>
            RegistroSesiones.SalirDeSala(idPartida, idUsuario);

        public void EnviarLetra(int idPartida, int idUsuario, char letra)
        {
            if (!RegistroSesiones.Rondas.TryGetValue(idPartida, out var ronda)) return;
            lock (ronda)
            {
                if (idUsuario != ronda.IdAdivinador) return;
                char letraMayus = char.ToUpper(letra);
                if (ronda.LetrasUsadas.Contains(letraMayus)) return;
                ronda.LetrasUsadas.Add(letraMayus);

                var posiciones = PosicionesDe(ronda.Palabra, letraMayus);
                bool acerto = posiciones.Count > 0;
                if (!acerto) ronda.IntentosRestantes = Math.Max(0, ronda.IntentosRestantes - 1);

                movimientoService.RegistrarMovimiento(idPartida, letra);

                RegistroSesiones.NotificarSala(idPartida,
                    cb => cb.LetraIngresada(letra, acerto, posiciones, ronda.IntentosRestantes));

                bool completa = PalabraAdivinada(ronda.Palabra, ronda.LetrasUsadas);
                if (completa || ronda.IntentosRestantes == 0)
                {
                    FinalizarPartida(idPartida, ronda, ganoAdivinador: completa);
                    RegistroSesiones.Rondas.TryRemove(idPartida, out _);
                }
            }
        }

        private void FinalizarPartida(int idPartida, EstadoRonda ronda, bool ganoAdivinador)
        {
            int ganador = ganoAdivinador ? ronda.IdAdivinador : ronda.IdCreador;
            int perdedor = ganoAdivinador ? ronda.IdCreador : ronda.IdAdivinador;
            string tipo = ganoAdivinador ? "Ganada" : "RivalNoPudo";

            puntajeDAO.Registrar(ganador, idPartida, ronda.IdPalabra, tipo, PuntosVictoria, perdedor);
            partidaDAO.Finalizar(idPartida, ganador, tipo);

            int globalAdiv = puntajeDAO.ObtenerPuntajeGlobal(ronda.IdAdivinador);
            int globalCreador = puntajeDAO.ObtenerPuntajeGlobal(ronda.IdCreador);

            string cat = ronda.Categoria ?? string.Empty;
            RegistroSesiones.NotificarJugador(idPartida, ronda.IdAdivinador,
                cb => cb.PartidaFinalizada($"{(ganoAdivinador ? "Ganaste" : "Perdiste")}|{cat}", ronda.Palabra,
                    ganoAdivinador ? PuntosVictoria : 0, globalAdiv));
            RegistroSesiones.NotificarJugador(idPartida, ronda.IdCreador,
                cb => cb.PartidaFinalizada($"{(ganoAdivinador ? "Perdiste" : "Ganaste")}|{cat}", ronda.Palabra,
                    ganoAdivinador ? 0 : PuntosVictoria, globalCreador));
        }

        private static List<int> PosicionesDe(string palabra, char letraMayus)
        {
            var posiciones = new List<int>();
            for (int i = 0; i < palabra.Length; i++)
                if (char.ToUpper(palabra[i]) == letraMayus) posiciones.Add(i);
            return posiciones;
        }

        private static bool PalabraAdivinada(string palabra, HashSet<char> letrasUsadas)
        {
            foreach (char c in palabra)
                if (char.IsLetter(c) && !letrasUsadas.Contains(char.ToUpper(c))) return false;
            return true;
        }

        public void EnviarMensajeChat(int idPartida, int idUsuario, string mensaje)
        {
            var remitente = usuarioDAO.ObtenerPorId(idUsuario);
            RegistroSesiones.NotificarSala(idPartida,
                cb => cb.MensajeChatRecibido(remitente.Nombre, mensaje), excepto: idUsuario);
        }

        public void NotificarAbandono(int idPartida, int idUsuario)
        {
            var quienAbandona = usuarioDAO.ObtenerPorId(idUsuario);

            if (RegistroSesiones.Rondas.TryGetValue(idPartida, out var ronda))
            {
                int rival = idUsuario == ronda.IdAdivinador ? ronda.IdCreador : ronda.IdAdivinador;
                puntajeDAO.Registrar(idUsuario, idPartida, ronda.IdPalabra, "Penalizacion", -PuntosPenalizacion, rival);
            }
            partidaDAO.Abandonar(idPartida, idUsuario);

            RegistroSesiones.NotificarSala(idPartida,
                cb => cb.RivalAbandono(quienAbandona.Nombre), excepto: idUsuario);
            RegistroSesiones.Rondas.TryRemove(idPartida, out _);
        }
    }
}
