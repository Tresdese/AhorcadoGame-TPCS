using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    public class PartidaService : IPartidaService
    {
        private readonly PartidaDAO partidaDAO = new PartidaDAO();

       
        public PartidaDTO CrearPartida(int idJugadorCreador)
        {
            try
            {
                return partidaDAO.Crear(idJugadorCreador);
            }
            catch (Exception)
            {
                return null; 
            }
        }

        
        public List<PartidaDTO> ObtenerPartidasDisponibles()
        {
            try
            {
                return partidaDAO.ObtenerDisponibles();
            }
            catch (Exception)
            {
                return null; 
            }
        }

      
        public bool VerificarDisponibilidadPartida(int idPartida)
        {
            try
            {
                return partidaDAO.VerificarDisponibilidad(idPartida);
            }
            catch (Exception)
            {
                return false; 
            }
        }

       
        public PartidaDTO ObtenerEstadoPartida(int idPartida)
        {
            try
            {
                return partidaDAO.ObtenerEstado(idPartida);
            }
            catch (Exception)
            {
                return null; 
            }
        }

        
        public bool UnirseAPartida(int idPartida, int idJugadorAdivinador)
        {
            try
            {
                return partidaDAO.Unirse(idPartida, idJugadorAdivinador);
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public bool CancelarPartida(int idPartida)
        {
            throw new NotImplementedException("error");
        }

        public bool AbandonarPartida(int idPartida, int idJugadorQueAbandona)
        {
            throw new NotImplementedException("error");
        }

        public bool FinalizarPartida(int idPartida, int idGanador, string tipoPuntaje)
        {
            throw new NotImplementedException("error");
        }

        public bool ReabrirPartida(int idPartida)
        {
            throw new NotImplementedException("error");
        }
    }
}
