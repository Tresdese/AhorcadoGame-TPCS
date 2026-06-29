using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
	public class MovimientoService : IMovimientoService
	{
		private readonly MovimientoDAO movimientoDAO = new MovimientoDAO();

		public MovimientoDTO RegistrarMovimiento(int idPartida, char letra)
		{
			return movimientoDAO.Registrar(idPartida, letra);
		}

		public List<MovimientoDTO> ObtenerMovimientosDePartida(int idPartida)
		{
			return movimientoDAO.ObtenerMovimientoPorPartida(idPartida);
		}
	}
}
