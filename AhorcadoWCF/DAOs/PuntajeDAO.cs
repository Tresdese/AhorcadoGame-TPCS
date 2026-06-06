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
    }
}
