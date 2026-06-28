using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class PuntajeDAO
    {
        private const string TipoPartidaGanada = "Ganada";
        private const string TipoRivalNoPudo = "RivalNoPudo";
        private const string TipoPenalizacion = "Penalizacion";

        public bool Registrar(int idUsuario, int idPartida, int idPalabra, string tipoPuntaje, int puntos, int idJugadorRival)
        {
            throw new NotImplementedException();
        }

        public int ObtenerPuntajeGlobal(int idUsuario)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.historial_puntaje
                    .Where(h => h.idJugador == idUsuario)
                    .Select(h => (int?)h.puntos)
                    .Sum() ?? 0;
            }
        }

        public int ObtenerPartidasGanadas(int idUsuario)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.historial_puntaje
                    .Count(h => h.idJugador == idUsuario && h.tipoPuntaje == TipoPartidaGanada);
            }
        }

        public int ObtenerPartidasRivalNoPudo(int idUsuario)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.historial_puntaje
                    .Count(h => h.idJugador == idUsuario && h.tipoPuntaje == TipoRivalNoPudo);
            }
        }

        public int ObtenerPenalizaciones(int idUsuario)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.historial_puntaje
                    .Count(h => h.idJugador == idUsuario && h.tipoPuntaje == TipoPenalizacion);
            }
        }


        public List<PuntajeHistorialDTO> ObtenerHistorialPorTipo(int idUsuario, string tipoPuntaje)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.historial_puntaje
                    .Where(h => h.idJugador == idUsuario && h.tipoPuntaje == tipoPuntaje)
                    .Join(
                        contexto.partida,
                        h => h.idPartida,
                        pa => pa.idPartida,
                        (h, pa) => new { h, pa })
                    .Join(
                        contexto.palabra,
                        x => x.pa.idPalabra,
                        w => w.idPalabra,
                        (x, w) => new { x.h, x.pa, w })
                    .Join(
                        contexto.usuario,
                        x => x.h.idJugadorRival,
                        u => u.idUsuario,
                        (x, u) => new { x.h, x.w, u })
                    .OrderByDescending(x => x.h.idPuntaje)
                    .AsEnumerable()
                    .Select(x => new PuntajeHistorialDTO
                    {
                        // ponytail: el modelo EF no tiene columna de fecha en historial_puntaje
                        Fecha = "—",
                        Palabra = x.w.palabra1.ToUpper(),
                        NombreRival = x.u.nombreCompleto,
                        Puntos = x.h.puntos,
                        TipoPuntaje = x.h.tipoPuntaje
                    })
                    .ToList();
            }
        }
    }
}
