using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PuntajeService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PuntajeService.svc o PuntajeService.svc.cs en el Explorador de soluciones e inicie la depuración.
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
