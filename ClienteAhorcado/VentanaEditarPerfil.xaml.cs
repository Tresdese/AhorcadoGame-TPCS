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
    public partial class VentanaEditarPerfil : Window {
        public VentanaEditarPerfil() {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaPerfil ventanaPerfil = new VentanaPerfil();
            ventanaPerfil.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            VentanaPerfil ventanaPerfil = new VentanaPerfil();
            ventanaPerfil.Show();
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e) {
        }
    }
}
