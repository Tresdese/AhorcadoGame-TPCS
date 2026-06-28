using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class PartidaDAO
    {
       
        public PartidaDTO Crear(int idJugadorCreador)
        {
            using (var transaccion = new TransactionScope())
            {
                using (var contexto = new AhorcadoDBEntities())
                {
                    int nuevoId = (contexto.partida.Max(p => (int?)p.idPartida) ?? 0) + 1;

                    var nuevaPartida = new partida
                    {
                        idPartida = nuevoId,
                        idJugadorUno = idJugadorCreador,
                        idJugadorDos = null,
                        estado = "Disponible",
                        fechaCreacion = DateTime.Now
                    };

                    contexto.partida.Add(nuevaPartida);
                    contexto.SaveChanges();

                    transaccion.Complete();

                    return new PartidaDTO
                    {
                        IdPartida = nuevaPartida.idPartida,
                        IdJugadorCreador = nuevaPartida.idJugadorUno,
                        IdJugadorAdivinador = 0,
                        Estado = nuevaPartida.estado
                    };
                }
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
                        (p, u) => p)
                    .AsEnumerable()
                    .Select(p => new PartidaDTO
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
            using (var transaccion = new TransactionScope())
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
                    transaccion.Complete();
                    return true;
                }
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
            using (var contexto = new AhorcadoDBEntities())
            {
                var partida = contexto.partida
                    .FirstOrDefault(p => p.idPartida == idPartida);

                if (partida == null)
                    return false;

                partida.estado = "Cancelada";
                contexto.SaveChanges();
                return true;
            }
        }

        public bool Abandonar(int idPartida, int idJugadorQueAbandona)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                var partida = contexto.partida
                    .FirstOrDefault(p => p.idPartida == idPartida);

                if (partida == null)
                    return false;

                partida.estado = "Abandonada";
                contexto.SaveChanges();
                return true;
            }
        }


        public bool Finalizar(int idPartida, int idGanador, string tipoPuntaje)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                var partida = contexto.partida
                    .FirstOrDefault(p => p.idPartida == idPartida);

                if (partida == null)
                    return false;

                partida.estado = "Finalizada";
                contexto.SaveChanges();
                return true;
            }
        }

        public bool Reabrir(int idPartida)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                var partida = contexto.partida
                    .FirstOrDefault(p => p.idPartida == idPartida);

                if (partida == null)
                    return false;

                partida.estado = "Disponible";
                partida.idJugadorDos = null;
                contexto.SaveChanges();
                return true;
            }
        }

    }
}
