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
            return partidaDAO.Crear(idJugadorCreador);
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
