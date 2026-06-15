using System.ServiceModel;
using AhorcadoWCF;

namespace ClienteAhorcado
{
    /// <summary>
    /// Fabrica unica de canales WCF. Crea los proxies a partir de los endpoints
    /// nombrados en App.config, usando los contratos compartidos de AhorcadoWCF.
    /// Cada persona obtiene aqui el proxy de su servicio:
    ///   A -> Autenticacion(), Usuario()
    ///   B -> Partida(), Puntaje()
    ///   C -> Palabra(), Movimiento(), Juego(contexto)
    /// Recuerde cerrar el canal (Close/Abort) cuando termine de usarlo.
    /// </summary>
    public static class Conexiones
    {
        public static IAutenticacionService Autenticacion() => Crear<IAutenticacionService>("AutenticacionEndpoint");

        public static IUsuarioService Usuario() => Crear<IUsuarioService>("UsuarioEndpoint");

        public static IPartidaService Partida() => Crear<IPartidaService>("PartidaEndpoint");

        public static IPuntajeService Puntaje() => Crear<IPuntajeService>("PuntajeEndpoint");

        public static IPalabraService Palabra() => Crear<IPalabraService>("PalabraEndpoint");

        public static IMovimientoService Movimiento() => Crear<IMovimientoService>("MovimientoEndpoint");

        /// <summary>
        /// Canal duplex del juego en tiempo real. El "contexto" envuelve a la clase
        /// del cliente que implementa IJuegoCallback (la que recibe los callbacks).
        /// </summary>
        public static IJuegoCallbackService Juego(InstanceContext contexto)
        {
            var fabrica = new DuplexChannelFactory<IJuegoCallbackService>(contexto, "JuegoEndpoint");
            return fabrica.CreateChannel();
        }

        private static T Crear<T>(string nombreEndpoint)
        {
            var fabrica = new ChannelFactory<T>(nombreEndpoint);
            return fabrica.CreateChannel();
        }
    }
}
