using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    public class PuntajeService : IPuntajeService
    {
        private readonly PuntajeDAO puntajeDAO = new PuntajeDAO();

        public int ObtenerPuntajeGlobal(int idUsuario)
        {
            return puntajeDAO.ObtenerPuntajeGlobal(idUsuario);
        }

        public int ObtenerPartidasGanadas(int idUsuario)
        {
            return puntajeDAO.ObtenerPartidasGanadas(idUsuario);
        }

        public int ObtenerPartidasRivalNoPudo(int idUsuario)
        {
            return puntajeDAO.ObtenerPartidasRivalNoPudo(idUsuario);
        }

        public int ObtenerPenalizaciones(int idUsuario)
        {
            return puntajeDAO.ObtenerPenalizaciones(idUsuario);
        }

        public int ObtenerPartidasAbandono(int idUsuario)
        {
            return puntajeDAO.ObtenerPartidasAbandono(idUsuario);
        }

        public bool RegistrarPuntaje(int idUsuario, int idPartida, int idPalabra, string tipoPuntaje, int puntos, int idJugadorRival)
        {
            return puntajeDAO.Registrar(idUsuario, idPartida, idPalabra, tipoPuntaje, puntos, idJugadorRival);
        }

        public List<PuntajeHistorialDTO> ObtenerHistorialPorTipo(int idUsuario, string tipoPuntaje)
        {
            try
            {
                return puntajeDAO.ObtenerHistorialPorTipo(idUsuario, tipoPuntaje);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
