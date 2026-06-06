using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class MovimientoDAO
    {
        public MovimientoDTO Registrar(int idPartida, char letra)
        {
            throw new NotImplementedException();
        }

        public List<MovimientoDTO> ObtenerMovimientoPorPartida(int idPartida)
        {
            using (var contexto = new AhorcadoDBEntities())
            {
                return contexto.movimiento
                    .Where(m => m.idPartida == idPartida)
                    .ToList()
                    .Select(m => new MovimientoDTO
                    {
                        IdMovimiento = m.idMovimiento,
                        IdPartida = m.idPartida,
                        Letra = string.IsNullOrEmpty(m.letraIngresada) ? '\0' : m.letraIngresada[0],
                        Acerto = m.esCorrecta,
                        Posiciones = new List<int>()
                    })
                    .ToList();
            }
        }
    }
}
