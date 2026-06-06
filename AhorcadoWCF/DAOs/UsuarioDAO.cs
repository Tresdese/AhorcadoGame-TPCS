using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class UsuarioDAO
    {
        public bool ValidarCredenciales(string correo, string contrasena)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.usuario.Any(u => u.correoElectronico == correo && u.contrasena == contrasena);
            }
        }

        public bool RegistrarCuenta(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO ObtenerPorId(int idUsuario)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.usuario
                    .Where(u => u.idUsuario == idUsuario)
                    .Select(u => new UsuarioDTO
                    {
                        IdUsuario = u.idUsuario,
                        Nombre = u.nombreCompleto,
                        Correo = u.correoElectronico
                    })
                    .FirstOrDefault() ?? new UsuarioDTO();
            }
        }

        public bool Actualizar(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public bool CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            throw new NotImplementedException();
        }

        public bool ExisteCorreo(string correo)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.usuario.Any(u => u.correoElectronico == correo);
            }
        }
    }
}
