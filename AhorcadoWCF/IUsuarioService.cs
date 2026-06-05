using System.Runtime.Serialization;
using System.ServiceModel;

namespace AhorcadoWCF
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        bool IniciarSesion(string correo, string contrasena);

        [OperationContract]
        bool RegistrarCuenta(UsuarioDTO usuario);

        [OperationContract]
        UsuarioDTO ObtenerPerfil(int idUsuario);

        [OperationContract]
        bool ActualizarPerfil(UsuarioDTO usuario);

        [OperationContract]
        bool CambiarContrasena(int idUsuario, string nuevaContrasena);

        [OperationContract]
        bool VerificarCorreoExistente(string correo);

        [OperationContract]
        bool ValidarSesionActiva(int idUsuario);
    }
}
