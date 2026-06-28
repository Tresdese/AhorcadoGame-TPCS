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
    public partial class VentanaBienvenida : Window {
        public VentanaBienvenida() {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e) {
            VentanaIniciarSesion ventanaIniciarSesion = new VentanaIniciarSesion();
            ventanaIniciarSesion.Show();
            this.Close();
        }

        private void btnRegistrarCuenta_Click(object sender, RoutedEventArgs e) {
            VentanaRegistrarCuenta ventanaRegistrarCuenta = new VentanaRegistrarCuenta();
            ventanaRegistrarCuenta.Show();
            this.Close();
        }
    }
}
