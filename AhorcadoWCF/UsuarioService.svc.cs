using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

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
    }
}
