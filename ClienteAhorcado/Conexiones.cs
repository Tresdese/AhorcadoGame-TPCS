using System;
using System.Configuration;
using System.ServiceModel;
using AhorcadoWCF;

namespace ClienteAhorcado
{
    public static class Conexiones
    {
        private static readonly string Ip = ConfigurationManager.AppSettings["ServidorIp"] ?? "localhost";
        private static readonly string Puerto = ConfigurationManager.AppSettings["ServidorPuerto"] ?? "8000";
        private static readonly NetTcpBinding Binding = new NetTcpBinding(SecurityMode.None);

        private static EndpointAddress Direccion(string servicio) =>
            new EndpointAddress($"net.tcp://{Ip}:{Puerto}/{servicio}");

        public static IAutenticacionService Autenticacion() => Crear<IAutenticacionService>("AutenticacionService");

        public static IUsuarioService Usuario() => Crear<IUsuarioService>("UsuarioService");

        public static IPartidaService Partida() => Crear<IPartidaService>("PartidaService");

        public static IPuntajeService Puntaje() => Crear<IPuntajeService>("PuntajeService");

        public static IPalabraService Palabra() => Crear<IPalabraService>("PalabraService");

        public static IMovimientoService Movimiento() => Crear<IMovimientoService>("MovimientoService");

        public static IJuegoService Juego(InstanceContext contexto)
        {
            var fabrica = new DuplexChannelFactory<IJuegoService>(
                contexto, Binding, Direccion("JuegoCallbackService"));
            return fabrica.CreateChannel();
        }

        private static T Crear<T>(string servicio)
        {
            var fabrica = new ChannelFactory<T>(Binding, Direccion(servicio));
            return fabrica.CreateChannel();
        }
    }
}
