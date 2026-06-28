using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        public UsuarioDTO IniciarSesion(string correo, string contrasena)
        {
            UsuarioDTO usuario = usuarioDAO.ObtenerPorCredenciales(correo, contrasena);
            if (usuario != null)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Jugador conectado: {correo}");
            }
            return usuario;
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
