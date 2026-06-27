using AhorcadoWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteAhorcado
{
    /// <summary>
    /// Implementación del contrato de callback IJuegoCallback.
    /// El servidor WCF llama a estos métodos para notificar eventos al cliente.
    /// Cada método delega en la ventana activa correspondiente.
    /// </summary>
    public class JuegoCallbackHandler : IJuegoCallback
    {
       
        public static VentanaJuegoAdivinador VentanaAdivinador { get; set; }
        public static VentanaEsperandoRival VentanaEspera { get; set; }

       
        public void PartidaCreada(PartidaDTO partida)
        {
           
        }

        
        public void PartidaRemovidaDelLobby(int idPartida)
        {
            
        }

        
        public void AdivinadorSeUnio(UsuarioDTO adivinador)
        {
            VentanaEspera?.NotificarAdivinadorUnido();
        }

        
        public void PalabraSeleccionada(int longitud, string descripcion, string categoria)
        {
            VentanaAdivinador?.IniciarJuego(longitud, descripcion, categoria);
        }

       
        public void LetraIngresada(char letra, bool acerto, List<int> posiciones, int intentosRestantes)
        {
            VentanaAdivinador?.ActualizarJuego(letra, acerto, posiciones, intentosRestantes);
        }

       
        public void MensajeChatRecibido(string remitente, string mensaje)
        {
            VentanaAdivinador?.AgregarMensajeChat(remitente, mensaje);
        }

       
        public void RivalAbandono(string nombreRival)
        {
            VentanaAdivinador?.NotificarRivalAbandono(nombreRival);
        }

        
        public void PartidaFinalizada(string resultado, string palabra, int puntosObtenidos, int puntajeGlobal)
        {
            VentanaAdivinador?.MostrarResultadoFinal(resultado, palabra, puntosObtenidos, puntajeGlobal);
        }
    }
}
