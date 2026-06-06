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
            return palabraDAO.AsignarAPartida(idPartida, idPalabra);
        }
    }
}
