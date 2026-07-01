using AhorcadoWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteAhorcado
{
    public class JuegoCallbackHandler : IJuegoCallback
    {
       
        public static VentanaEsperandoRival VentanaEspera { get; set; }
        public static VentanaEsperandoPalabra VentanaEsperaPalabra { get; set; }
        public static IJuegoService ClienteJuego { get; set; }

       
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
            VentanaEsperaPalabra?.IrAlTablero(longitud, descripcion, categoria);
        }

       
        public void LetraIngresada(char letra, bool acerto, List<int> posiciones, int intentosRestantes) { }

        public void MensajeChatRecibido(string remitente, string mensaje) { }

        public void RivalAbandono(string nombreRival) { }

        public void PartidaFinalizada(string resultado, string palabra, int puntosObtenidos, int puntajeGlobal) { }
    }
}
