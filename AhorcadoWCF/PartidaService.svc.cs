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
            try
            {
                return partidaDAO.Cancelar(idPartida);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AbandonarPartida(int idPartida, int idJugadorQueAbandona)
        {
            try
            {
                return partidaDAO.Abandonar(idPartida, idJugadorQueAbandona);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FinalizarPartida(int idPartida, int idGanador, string tipoPuntaje)
        {
            try
            {
                return partidaDAO.Finalizar(idPartida, idGanador, tipoPuntaje);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ReabrirPartida(int idPartida)
        {
            try
            {
                return partidaDAO.Reabrir(idPartida);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
