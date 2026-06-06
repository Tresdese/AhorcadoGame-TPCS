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
    /// Lógica de interacción para VentanaElegirPalabra.xaml
    /// </summary>
    public partial class VentanaElegirPalabra : Window {
        public VentanaElegirPalabra() {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaElegirCategoria ventana = new VentanaElegirCategoria();
            ventana.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            VentanaPartidas ventana = new VentanaPartidas();
            ventana.Show();
            this.Close();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e) {
        }
    }
}
