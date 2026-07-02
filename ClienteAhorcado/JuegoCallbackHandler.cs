using AhorcadoWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClienteAhorcado
{
    public class JuegoCallbackHandler : IJuegoCallback
    {
       
        public static VentanaEsperandoRival VentanaEspera { get; set; }
        public static VentanaEsperandoPalabra VentanaEsperaPalabra { get; set; }
        public static IJuegoService ClienteJuego { get; set; }
        
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

        public void RivalAbandono(string nombreRival) { 
            Application.Current.Dispatcher.Invoke(() =>
            {
                VentanaEspera = null;
                VentanaEsperaPalabra = null;
                var dialogo = new DialogoRivalAbandono(SesionActual.IdPartida, nombreRival, penalizado: false);
                dialogo.Owner = Application.Current.MainWindow;
                dialogo.ShowDialog();
            });
        }

        public void PartidaFinalizada(string resultado, string palabra, int puntosObtenidos, int puntajeGlobal) { }
    }
}
