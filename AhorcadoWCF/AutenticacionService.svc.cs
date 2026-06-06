using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AutenticacionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AutenticacionService.svc or AutenticacionService.svc.cs at the Solution Explorer and start debugging.
    public class AutenticacionService : IAutenticacionService
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        public bool IniciarSesion(string correo, string contrasena)
        {
            return usuarioDAO.ValidarCredenciales(correo, contrasena);
        }

        public bool RegistrarCuenta(UsuarioDTO usuario)
        {
            if (usuario == null)
            {
                return false;
            }

            return usuarioDAO.RegistrarCuenta(usuario);
        }

        public bool VerificarCorreoExistente(string correo)
        {
            return usuarioDAO.ExisteCorreo(correo);
        }

        public bool ValidarSesionActiva(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
