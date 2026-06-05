using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AhorcadoWCF
{
    [ServiceContract]
    public interface IPartidaService
    {
        [OperationContract]
        PartidaDTO CrearPartida(int idJugadorCreador);

        [OperationContract]
        List<PartidaDTO> ObtenerPartidasDisponibles();

        [OperationContract]
        bool VerificarDisponibilidadPartida(int idPartida);

        [OperationContract]
        bool UnirseAPartida(int idPartida, int idJugadorAdivinador);

        [OperationContract]
        PartidaDTO ObtenerEstadoPartida(int idPartida);

        [OperationContract]
        bool CancelarPartida(int idPartida);

        [OperationContract]
        bool AbandonarPartida(int idPartida, int idJugadorQueAbandona);

        [OperationContract]
        bool FinalizarPartida(int idPartida, int idGanador, string tipoPuntaje);

        [OperationContract]
        bool ReabrirPartida(int idPartida);
    }
}
