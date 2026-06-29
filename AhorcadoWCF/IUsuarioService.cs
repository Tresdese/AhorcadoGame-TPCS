using System.Runtime.Serialization;
using System.ServiceModel;

namespace AhorcadoWCF
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        UsuarioDTO ObtenerPerfil(int idUsuario);

        [OperationContract]
        bool ActualizarPerfil(UsuarioDTO usuario);

        [OperationContract]
        bool CambiarContrasena(int idUsuario, string nuevaContrasena);
    }
}
