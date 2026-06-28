using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AhorcadoWCF
{
    [ServiceContract]
    public interface IPuntajeService
    {
        [OperationContract]
        int ObtenerPuntajeGlobal(int idUsuario);

        [OperationContract]
        int ObtenerPartidasGanadas(int idUsuario);

        [OperationContract]
        int ObtenerPartidasRivalNoPudo(int idUsuario);

        [OperationContract]
        int ObtenerPenalizaciones(int idUsuario);

        [OperationContract]
        bool RegistrarPuntaje(int idUsuario, int idPartida, int idPalabra, string tipoPuntaje, int puntos, int idJugadorRival);

        [OperationContract]
        List<PuntajeHistorialDTO> ObtenerHistorialPorTipo(int idUsuario, string tipoPuntaje);
    }
}
