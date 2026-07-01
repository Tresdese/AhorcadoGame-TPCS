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

        public PartidaDTO CrearPartida(int idJugadorCreador, string idioma)
        {
            return partidaDAO.Crear(idJugadorCreador, idioma);
        }

        public List<PartidaDTO> ObtenerPartidasDisponibles()
        {
            return partidaDAO.ObtenerDisponibles();
        }

        public bool VerificarDisponibilidadPartida(int idPartida)
        {
            return partidaDAO.VerificarDisponibilidad(idPartida);
        }

        public PartidaDTO ObtenerEstadoPartida(int idPartida)
        {
            return partidaDAO.ObtenerEstado(idPartida);
        }

        public bool UnirseAPartida(int idPartida, int idJugadorAdivinador)
        {
            return partidaDAO.Unirse(idPartida, idJugadorAdivinador);
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
