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
    /// Lógica de interacción para DialogoGanadorAdivinador.xaml
    /// </summary>
    public partial class DialogoGanadorAdivinador : Window {
        public DialogoGanadorAdivinador() {
            InitializeComponent();
        }

        private void btnLobby_Click(object sender, RoutedEventArgs e) {
            VentanaPartidas ventana = new VentanaPartidas();
            ventana.Show();
            this.Close();
        }

        private void btnJugarDeNuevo_Click(object sender, RoutedEventArgs e) {
            VentanaEsperandoRival ventana = new VentanaEsperandoRival();
            ventana.Show();
            this.Close();
        }
    }
}
