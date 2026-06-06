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
    /// Lógica de interacción para VentanaElegirCategoria.xaml
    /// </summary>
    public partial class VentanaElegirCategoria : Window {
        public VentanaElegirCategoria() {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaEsperandoRival ventana = new VentanaEsperandoRival();
            ventana.Show();
            this.Close();
        }

        private void btnAnimales_Click(object sender, MouseButtonEventArgs e) { }
        private void btnPaises_Click(object sender, MouseButtonEventArgs e) { }
        private void btnComida_Click(object sender, MouseButtonEventArgs e) { }
        private void btnDeportes_Click(object sender, MouseButtonEventArgs e) { }
        private void btnPeliculas_Click(object sender, MouseButtonEventArgs e) { }
        private void btnTecnologia_Click(object sender, MouseButtonEventArgs e) { }

        private void btnContinuar_Click(object sender, RoutedEventArgs e) {
            VentanaElegirPalabra ventana = new VentanaElegirPalabra();
            ventana.Show();
            this.Close();
        }
    }
}
