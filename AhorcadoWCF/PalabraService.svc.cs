using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PalabraService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PalabraService.svc o PalabraService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PalabraService : IPalabraService
    {
        private readonly PalabraDAO palabraDAO = new PalabraDAO();
        private readonly PartidaDAO partidaDAO = new PartidaDAO();

        public List<CategoriaDTO> ObtenerCategorias(string idioma)
        {
            return palabraDAO.ObtenerCategorias(idioma);
        }

        public List<PalabraDTO> ObtenerPalabrasPorCategoria(int idCategoria)
        {
            return palabraDAO.ObtenerPorCategoria(idCategoria);
        }

        public bool AsignarPalabraAPartida(int idPartida, int idPalabra)
        {
            bool asignada = palabraDAO.AsignarAPartida(idPartida, idPalabra);
            if (asignada)
            {
                var palabra = palabraDAO.ObtenerPorId(idPalabra);
                if (palabra != null)
                {
                    var partida = partidaDAO.ObtenerEstado(idPartida);
                    RegistroSesiones.IniciarRonda(idPartida, palabra.Texto, partida.IdJugadorAdivinador);
                    RegistroSesiones.NotificarSala(idPartida,
                        cb => cb.PalabraSeleccionada(palabra.Texto.Length, palabra.Descripcion, palabra.Categoria));
                }
            }
            return asignada;
        }
    }
}
