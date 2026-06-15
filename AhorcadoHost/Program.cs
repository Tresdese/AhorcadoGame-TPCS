using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using AhorcadoWCF;

namespace AhorcadoHost
{
    /// <summary>
    /// Host de consola que publica todos los servicios WCF por TCP/IP (netTcpBinding)
    /// en la red local. Se ejecuta en la maquina servidor; cualquier cliente de la
    /// red se conecta usando la IP/host y el puerto configurados.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            // Host de escucha: si no se configura, se usa el nombre de la maquina
            // (resuelve a la IP de la LAN para que clientes remotos puedan conectar).
            string host = ConfigurationManager.AppSettings["ServidorHost"];
            if (string.IsNullOrWhiteSpace(host))
            {
                host = Dns.GetHostName();
            }

            string puerto = ConfigurationManager.AppSettings["ServidorPuerto"] ?? "8000";
            string baseUri = $"net.tcp://{host}:{puerto}";

            // SecurityMode.None: simplifica la conexion entre maquinas de la LAN
            // (sin autenticacion de Windows). El cliente debe usar el mismo modo.
            var binding = new NetTcpBinding(SecurityMode.None);

            var hosts = new List<ServiceHost>
            {
                Abrir<AutenticacionService, IAutenticacionService>(binding, baseUri, "AutenticacionService"),
                Abrir<UsuarioService, IUsuarioService>(binding, baseUri, "UsuarioService"),
                Abrir<PartidaService, IPartidaService>(binding, baseUri, "PartidaService"),
                Abrir<PuntajeService, IPuntajeService>(binding, baseUri, "PuntajeService"),
                Abrir<PalabraService, IPalabraService>(binding, baseUri, "PalabraService"),
                Abrir<MovimientoService, IMovimientoService>(binding, baseUri, "MovimientoService"),
                Abrir<JuegoCallbackService, IJuegoCallbackService>(binding, baseUri, "JuegoCallbackService"),
            };

            Console.WriteLine("Servidor del Ahorcado escuchando en:");
            Console.WriteLine($"  {baseUri}/<Servicio>");
            Console.WriteLine();
            Console.WriteLine("Presione ENTER para detener el servidor.");
            Console.ReadLine();

            foreach (var h in hosts)
            {
                if (h.State == CommunicationState.Faulted) { h.Abort(); } else { h.Close(); }
            }
        }

        private static ServiceHost Abrir<TServicio, TContrato>(
            NetTcpBinding binding, string baseUri, string ruta)
        {
            var host = new ServiceHost(typeof(TServicio), new Uri(baseUri));
            host.AddServiceEndpoint(typeof(TContrato), binding, ruta);
            host.Open();
            Console.WriteLine($"  [OK] {ruta}");
            return host;
        }
    }
}
