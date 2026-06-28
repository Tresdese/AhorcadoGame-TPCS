using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClienteAhorcado {
    public partial class VentanaEsperandoPalabra : Window {
        private readonly int _idPartida;
        private readonly string _nombreCreador;

        public VentanaEsperandoPalabra(int idPartida, string nombreCreador) {
            InitializeComponent();
            _idPartida = idPartida;
            _nombreCreador = nombreCreador;
            Loaded += (s, e) => JuegoCallbackHandler.VentanaEsperaPalabra = this;
        }

        public void IrAlTablero(int longitud, string descripcion, string categoria) {
            Dispatcher.Invoke(() => {
                JuegoCallbackHandler.VentanaEsperaPalabra = null;
                var tablero = new VentanaJuegoAdivinador(_idPartida, _nombreCreador);
                tablero.Show();
                tablero.IniciarJuego(longitud, descripcion, categoria);
                Close();
            });
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e) {
            JuegoCallbackHandler.VentanaEsperaPalabra = null;
            VentanaPartidas ventana = new VentanaPartidas();
            ventana.Show();
            this.Close();
        }
    }
}
