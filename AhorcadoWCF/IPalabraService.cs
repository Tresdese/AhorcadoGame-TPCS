using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AhorcadoWCF
{
    [ServiceContract]
    public interface IPalabraService
    {
        [OperationContract]
        List<CategoriaDTO> ObtenerCategorias(string idioma);

        [OperationContract]
        List<PalabraDTO> ObtenerPalabrasPorCategoria(int idCategoria);

        [OperationContract]
        bool AsignarPalabraAPartida(int idPartida, int idPalabra);
    }
}
