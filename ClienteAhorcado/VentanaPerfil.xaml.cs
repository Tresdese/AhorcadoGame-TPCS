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
    public partial class VentanaPerfil : Window {
        public VentanaPerfil() {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaPartidas ventanaPartidas = new VentanaPartidas();
            ventanaPartidas.Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e) {
            VentanaEditarPerfil ventanaEditarPerfil = new VentanaEditarPerfil();
            ventanaEditarPerfil.Show();
            this.Close();
        }
    }
}
