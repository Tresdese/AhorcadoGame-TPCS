using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class PalabraDAO
    {
        public List<CategoriaDTO> ObtenerCategorias(string idioma)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.categoria
                    .Where(c => c.idioma == idioma)
                    .Select(c => new CategoriaDTO
                    {
                        IdCategoria = c.idCategoria,
                        Nombre = c.nombre,
                        Idioma = c.idioma
                    })
                    .ToList();
            }
        }

        public List<PalabraDTO> ObtenerPorCategoria(int idCategoria)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.palabra
                    .Where(p => p.idCategoria == idCategoria)
                    .Select(p => new PalabraDTO
                    {
                        IdPalabra = p.idPalabra,
                        Texto = p.palabra1,
                        Descripcion = p.descripcion,
                        IdCategoria = p.idCategoria,
                        Categoria = p.categoria.nombre
                    })
                    .ToList();
            }
        }

        public PalabraDTO ObtenerPorId(int idPalabra)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.palabra
                    .Where(p => p.idPalabra == idPalabra)
                    .Select(p => new PalabraDTO
                    {
                        IdPalabra = p.idPalabra,
                        Texto = p.palabra1,
                        Descripcion = p.descripcion,
                        IdCategoria = p.idCategoria,
                        Categoria = p.categoria.nombre
                    })
                    .FirstOrDefault();
            }
        }

        public bool AsignarAPartida(int idPartida, int idPalabra)
        {
            using (var transaccion = new TransactionScope())
            {
                using (var contexto = new AhorcadoDBEntities())
                {
                    var partida = contexto.partida.FirstOrDefault(p => p.idPartida == idPartida);
                    if (partida == null)
                    {
                        return false;
                    }

                    partida.idPalabra = idPalabra;
                    contexto.SaveChanges();
                    transaccion.Complete();
                    return true;
                }
            }
        }
    }
}
