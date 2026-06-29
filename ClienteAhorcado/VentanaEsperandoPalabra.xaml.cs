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
    public partial class VentanaEsperandoPalabra : Page {
        private readonly int _idPartida;
        private readonly string _nombreCreador;

        public VentanaEsperandoPalabra(int idPartida, string nombreCreador) {
            InitializeComponent();
            _idPartida = idPartida;
            _nombreCreador = nombreCreador;
            Loaded += VentanaEsperandoPalabra_Loaded;
        }

        private void VentanaEsperandoPalabra_Loaded(object sender, RoutedEventArgs e) {
            JuegoCallbackHandler.VentanaEsperaPalabra = this;
            btnUsuario.Content = $"{SesionActual.Nombre} ▼";
            btnIdioma.Content = SesionActual.Idioma == "es" ? "🌐 ES" : "🌐 EN";
            lblEligiendo.Text = string.Format(Properties.Resources.EsperandoPalabra_Eligiendo, _nombreCreador);
            btnCreador.Content = string.Format(Properties.Resources.EsperandoPalabra_CreadorBoton, _nombreCreador);
        }

        private void btnIdioma_Click(object sender, RoutedEventArgs e) {
            GestorIdioma.Cambiar(SesionActual.Idioma == "es" ? "en" : "es");
        }

        public void IrAlTablero(int longitud, string descripcion, string categoria) {
            Dispatcher.Invoke(() => {
                JuegoCallbackHandler.VentanaEsperaPalabra = null;
                var tablero = new VentanaJuegoAdivinador(_idPartida, _nombreCreador);
                Navegacion.Ir(tablero);
                tablero.IniciarJuego(longitud, descripcion, categoria);
            });
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e) {
            JuegoCallbackHandler.VentanaEsperaPalabra = null;
            VentanaPartidas ventana = new VentanaPartidas();
            Navegacion.Ir(ventana);
        }
    }
}
