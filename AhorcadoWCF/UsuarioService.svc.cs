using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioService.svc o UsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : IUsuarioService
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

        public UsuarioDTO ObtenerPerfil(int idUsuario)
        {
            return usuarioDAO.ObtenerPorId(idUsuario);
        }

        public bool ActualizarPerfil(UsuarioDTO usuario)
        {
            if (usuario == null)
            {
                return false;
            }

            return usuarioDAO.Actualizar(usuario);
        }

        public bool CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            return usuarioDAO.CambiarContrasena(idUsuario, nuevaContrasena);
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
