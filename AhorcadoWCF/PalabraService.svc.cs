using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
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
                    string idiomaAdivinador = RegistroSesiones.ObtenerIdioma(partida.IdJugadorAdivinador);
                    string descripcion = palabraDAO.ObtenerDescripcion(idPalabra, idiomaAdivinador);

                    RegistroSesiones.IniciarRonda(idPartida, palabra.Texto, palabra.Categoria,
                        partida.IdJugadorAdivinador, partida.IdJugadorCreador, idPalabra);
                    RegistroSesiones.NotificarSala(idPartida,
                        cb => cb.PalabraSeleccionada(palabra.Texto.Length, descripcion, palabra.Categoria));
                }
            }
            return asignada;
        }
    }
}
