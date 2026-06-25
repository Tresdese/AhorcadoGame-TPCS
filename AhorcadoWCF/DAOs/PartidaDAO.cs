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
            using (var contexto = new AhorcadoDBEntities())
            {
                var nuevaPartida = new partida
                {
                    idJugadorUno = idJugadorCreador,
                    idJugadorDos = null,
                    estado = "Disponible"
                };

                contexto.partida.Add(nuevaPartida);
                contexto.SaveChanges();

                return new PartidaDTO
                {
                    IdPartida = nuevaPartida.idPartida,
                    IdJugadorCreador = nuevaPartida.idJugadorUno,
                    IdJugadorAdivinador = 0,
                    Estado = nuevaPartida.estado
                };
            }
        }

      
        public List<PartidaDTO> ObtenerDisponibles()
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.partida
                    .Where(p => p.estado == "Disponible")
                    .Join(
                        contexto.usuario,
                        p => p.idJugadorUno,
                        u => u.idUsuario,
                        (p, u) => new PartidaDTO
                        {
                            IdPartida = p.idPartida,
                            IdJugadorCreador = p.idJugadorUno,
                            IdJugadorAdivinador = p.idJugadorDos ?? 0,
                            Estado = p.estado,
                            FechaCreacion = p.fechaCreacion != null
                                                    ? ((DateTime)p.fechaCreacion).ToString("dd/MM/yyyy HH:mm")
                                                    : "—"
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
            using (var contexto = new AhorcadoDBEntities())
            {
                var partida = contexto.partida
                    .FirstOrDefault(p => p.idPartida == idPartida && p.estado == "Disponible");

                if (partida == null)
                    return false;

                partida.idJugadorDos = idJugadorAdivinador;
                partida.estado = "EnCurso";
                contexto.SaveChanges();
                return true;
            }
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
            throw new NotImplementedException("Se implementará en CU-12");
        }

        public bool Abandonar(int idPartida, int idJugadorQueAbandona)
        {
            throw new NotImplementedException("Se implementará en CU-12");
        }

     
        public bool Finalizar(int idPartida, int idGanador, string tipoPuntaje)
        {
            throw new NotImplementedException("Se implementará en CU-11");
        }

        public bool Reabrir(int idPartida)
        {
            throw new NotImplementedException("Se implementará en CU-11");
        }
    }
}
