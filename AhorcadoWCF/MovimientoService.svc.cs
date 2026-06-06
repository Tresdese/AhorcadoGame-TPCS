using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AhorcadoWCF.DAOs;

namespace AhorcadoWCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovimientoService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select MovimientoService.svc or MovimientoService.svc.cs at the Solution Explorer and start debugging.
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
