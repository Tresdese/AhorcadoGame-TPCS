using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AhorcadoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAutenticacionService" in both code and config file together.
    [ServiceContract]
    public interface IAutenticacionService
    {
        [OperationContract]
        bool IniciarSesion(string correo, string contrasena);

        [OperationContract]
        bool RegistrarCuenta(UsuarioDTO usuario);

        [OperationContract]
        bool VerificarCorreoExistente(string correo);

        [OperationContract]
        bool ValidarSesionActiva(int idUsuario);
    }
}
