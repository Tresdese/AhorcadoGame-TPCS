using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AhorcadoWCF.DAOs
{
    public class MovimientoDAO
    {
        public MovimientoDTO Registrar(int idPartida, char letra)
        {
            using (var transaccion = new TransactionScope())
            {
                using (var contexto = new AhorcadoDBEntities())
                {
                    var partida = contexto.partida.FirstOrDefault(p => p.idPartida == idPartida);
                    string palabra = partida?.palabra?.palabra1 ?? "";
                    bool acerto = palabra.ToUpper().IndexOf(char.ToUpper(letra)) >= 0;

                    var movimiento = new movimiento
                    {
                        idPartida = idPartida,
                        letraIngresada = letra.ToString(),
                        esCorrecta = acerto
                    };
                    contexto.movimiento.Add(movimiento);
                    contexto.SaveChanges();

                    transaccion.Complete();

                    return new MovimientoDTO
                    {
                        IdMovimiento = movimiento.idMovimiento,
                        IdPartida = movimiento.idPartida,
                        Letra = letra,
                        Acerto = movimiento.esCorrecta,
                        Posiciones = CalcularPosiciones(palabra, letra)
                    };
                }
            }
        }

        public List<MovimientoDTO> ObtenerMovimientoPorPartida(int idPartida)
        {
            using (var contexto = new AhorcadoDBEntities())
            {

                var partida = contexto.partida.FirstOrDefault(p => p.idPartida == idPartida);
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

        private static List<int> CalcularPosiciones(string palabra, char letra)
        {
            var posiciones = new List<int>();
            if (string.IsNullOrEmpty(palabra)) return posiciones;

            for (int i = 0; i < palabra.Length; i++)
            {
                if (char.ToUpper(palabra[i]) == char.ToUpper(letra))
                {
                    posiciones.Add(i);
                }
            }
            return posiciones;
        }
    }
}
