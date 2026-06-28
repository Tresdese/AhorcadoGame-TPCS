using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class UsuarioDAO
    {
        public UsuarioDTO ObtenerPorCredenciales(string correo, string contrasena)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.usuario
                    .Where(u => u.correoElectronico == correo && u.contrasena == contrasena)
                    .Select(u => new UsuarioDTO
                    {
                        IdUsuario = u.idUsuario,
                        Nombre = u.nombreCompleto,
                        Correo = u.correoElectronico
                    })
                    .FirstOrDefault();
            }
        }

        public bool RegistrarCuenta(UsuarioDTO usuario)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                var nuevoUsuario = new usuario
                {
                    nombreCompleto = usuario.Nombre,
                    correoElectronico = usuario.Correo,
                    contrasena = usuario.Contrasena,
                    fechaNacimiento = usuario.FechaNacimiento,
                    telefono = usuario.Telefono,
                    fechaRegistro = DateTime.Now
                };

                contexto.usuario.Add(nuevoUsuario);
                contexto.SaveChanges();
                return true;
            }
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
                        Correo = u.correoElectronico,
                        FechaNacimiento = u.fechaNacimiento,
                        Telefono = u.telefono
                    })
                    .FirstOrDefault() ?? new UsuarioDTO();
            }
        }

        public bool Actualizar(UsuarioDTO usuario)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                var usuarioExistente = contexto.usuario
                    .FirstOrDefault(u => u.idUsuario == usuario.IdUsuario);

                if(usuarioExistente == null) return false;

                usuarioExistente.nombreCompleto = usuario.Nombre;
                usuarioExistente.fechaNacimiento = usuario.FechaNacimiento;
                usuarioExistente.telefono = usuario.Telefono;

                contexto.SaveChanges();
                return true;
            }
        }

        public bool CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                var usuarioExistente = contexto.usuario
                    .FirstOrDefault(u => u.idUsuario == idUsuario);

                if(usuarioExistente == null) return false;

                usuarioExistente.contrasena = nuevaContrasena;

                contexto.SaveChanges();
                return true;
            }
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
