using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AhorcadoWCF
{
    [ServiceContract]
    public interface IAutenticacionService
    {
        [OperationContract]
        UsuarioDTO IniciarSesion(string correo, string contrasena);

        [OperationContract]
        bool RegistrarCuenta(UsuarioDTO usuario);

        [OperationContract]
        bool VerificarCorreoExistente(string correo);

        [OperationContract]
        bool ValidarSesionActiva(int idUsuario);
    }
}
