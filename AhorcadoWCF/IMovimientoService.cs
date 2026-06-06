using System.Collections.Generic;
using System.ServiceModel;

namespace AhorcadoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovimientoService" in both code and config file together.
    [ServiceContract]
    public interface IMovimientoService
    {
        [OperationContract]
        MovimientoDTO RegistrarMovimiento(int idPartida, char letra);

        [OperationContract]
        List<MovimientoDTO> ObtenerMovimientosDePartida(int idPartida);
    }
}
