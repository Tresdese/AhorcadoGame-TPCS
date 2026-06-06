using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PartidaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PartidaService.svc o PartidaService.svc.cs en el Explorador de soluciones e inicie la depuración.
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

        public bool UnirseAPartida(int idPartida, int idJugadorAdivinador)
        {
            return partidaDAO.Unirse(idPartida, idJugadorAdivinador);
        }

        public PartidaDTO ObtenerEstadoPartida(int idPartida)
        {
            return partidaDAO.ObtenerEstado(idPartida);
        }

        public bool CancelarPartida(int idPartida)
        {
            return partidaDAO.Cancelar(idPartida);
        }

        public bool AbandonarPartida(int idPartida, int idJugadorQueAbandona)
        {
            return partidaDAO.Abandonar(idPartida, idJugadorQueAbandona);
        }

        public bool FinalizarPartida(int idPartida, int idGanador, string tipoPuntaje)
        {
            return partidaDAO.Finalizar(idPartida, idGanador, tipoPuntaje);
        }

        public bool ReabrirPartida(int idPartida)
        {
            return partidaDAO.Reabrir(idPartida);
        }
    }
}
