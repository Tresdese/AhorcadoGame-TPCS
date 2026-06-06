using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class PartidaDAO
    {
        public PartidaDTO Crear(int idJugadorCreador)
        {
            throw new NotImplementedException();
        }

        public List<PartidaDTO> ObtenerDisponibles()
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.partida
                    .Where(p => p.estado == "Disponible")
                    .Select(p => new PartidaDTO
                    {
                        IdPartida = p.idPartida,
                        IdJugadorCreador = p.idJugadorUno,
                        IdJugadorAdivinador = p.idJugadorDos ?? 0,
                        Estado = p.estado
                    })
                    .ToList();
            }
        }

        public bool VerificarDisponibilidad(int idPartida)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.partida
                    .Any(p => p.idPartida == idPartida && p.estado == "Disponible");
            }
        }

        public bool Unirse(int idPartida, int idJugadorAdivinador)
        {
            throw new NotImplementedException();
        }

        public PartidaDTO ObtenerEstado(int idPartida)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.partida
                    .Where(p => p.idPartida == idPartida)
                    .Select(p => new PartidaDTO
                    {
                        IdPartida = p.idPartida,
                        IdJugadorCreador = p.idJugadorUno,
                        IdJugadorAdivinador = p.idJugadorDos ?? 0,
                        Estado = p.estado
                    })
                    .FirstOrDefault() ?? new PartidaDTO();
            }
        }

        public bool Cancelar(int idPartida)
        {
            throw new NotImplementedException();
        }

        public bool Abandonar(int idPartida, int idJugadorQueAbandona)
        {
            throw new NotImplementedException();
        }

        public bool Finalizar(int idPartida, int idGanador, string tipoPuntaje)
        {
            throw new NotImplementedException();
        }

        public bool Reabrir(int idPartida)
        {
            throw new NotImplementedException();
        }
    }
}
