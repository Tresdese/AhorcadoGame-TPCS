using System;
using System.Collections.Concurrent;
using System.ServiceModel;

namespace AhorcadoWCF
{
    // Registro estatico en memoria de quien esta conectado y su canal de callback.
    // Es la base de toda la comunicacion en tiempo real: el lobby y cada sala de partida.
    // ConcurrentDictionary porque el servicio corre con ConcurrencyMode.Multiple.
    public static class RegistroSesiones
    {
        // idUsuario -> callback (usuarios viendo el lobby/lista de partidas)
        public static readonly ConcurrentDictionary<int, IJuegoCallback> Lobby =
            new ConcurrentDictionary<int, IJuegoCallback>();

        // idPartida -> (idUsuario -> callback) (jugadores dentro de cada sala)
        public static readonly ConcurrentDictionary<int, ConcurrentDictionary<int, IJuegoCallback>> Salas =
            new ConcurrentDictionary<int, ConcurrentDictionary<int, IJuegoCallback>>();

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
                }
            }
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class JuegoCallbackService : IJuegoCallbackService
    {
        private static IJuegoCallback CanalActual() =>
            OperationContext.Current.GetCallbackChannel<IJuegoCallback>();

        public void ConectarAlLobby(int idUsuario) =>
            RegistroSesiones.AgregarAlLobby(idUsuario, CanalActual());

        public void DesconectarDelLobby(int idUsuario) =>
            RegistroSesiones.QuitarDelLobby(idUsuario);

        public void UnirseASalaDePartida(int idPartida, int idUsuario) =>
            RegistroSesiones.UnirASala(idPartida, idUsuario, CanalActual());

        public void SalirDeSalaDePartida(int idPartida, int idUsuario) =>
            RegistroSesiones.SalirDeSala(idPartida, idUsuario);

        public void EnviarLetra(int idPartida, int idUsuario, char letra) => throw new NotImplementedException();

        public void EnviarMensajeChat(int idPartida, int idUsuario, string mensaje) => throw new NotImplementedException();

        public void NotificarAbandono(int idPartida, int idUsuario) => throw new NotImplementedException();
    }
}
