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
    /// <summary>
    /// Lógica de interacción para VentanaPartidas.xaml
    /// </summary>
    public partial class VentanaPartidas : Window {
        public VentanaPartidas() {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e) {
            btnUsuario.ContextMenu.IsOpen = true;
        }

        private void mnuVerPerfil_Click(object sender, RoutedEventArgs e) {
            VentanaPerfil ventanaPerfil = new VentanaPerfil();
            ventanaPerfil.Show();
            this.Close();
        }

        private void mnuHistorial_Click(object sender, RoutedEventArgs e) {
            VentanaHistorial ventanaHistorial = new VentanaHistorial();
            ventanaHistorial.Show();
            this.Close();
        }

        private void mnuCerrarSesion_Click(object sender, RoutedEventArgs e) {
            VentanaBienvenida ventanaBienvenida = new VentanaBienvenida();
            ventanaBienvenida.Show();
            this.Close();
        }

        private void btnCrearPartida_Click(object sender, RoutedEventArgs e) {
            VentanaEsperandoRival ventana = new VentanaEsperandoRival();
            ventana.Show();
            this.Close();
        }

        private void btnUnirme_Click(object sender, RoutedEventArgs e) {
            VentanaEsperandoPalabra ventana = new VentanaEsperandoPalabra();
            ventana.Show();
            this.Close();
        }
    }
}
