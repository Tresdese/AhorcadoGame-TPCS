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
    /// Lógica de interacción para VentanaEsperandoRival.xaml
    /// </summary>
    public partial class VentanaEsperandoRival : Window {
        public VentanaEsperandoRival() {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            VentanaPartidas ventanaPartidas = new VentanaPartidas();
            ventanaPartidas.Show();
            this.Close();
        }
    }
}
