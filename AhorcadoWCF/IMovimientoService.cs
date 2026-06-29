using System.Collections.Generic;
using System.ServiceModel;

namespace AhorcadoWCF
{
    [ServiceContract]
    public interface IMovimientoService
    {
        [OperationContract]
        MovimientoDTO RegistrarMovimiento(int idPartida, char letra);

        [OperationContract]
        List<MovimientoDTO> ObtenerMovimientosDePartida(int idPartida);
    }
}
