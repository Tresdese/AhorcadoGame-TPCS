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
    /// Lógica de interacción para VentanaJuegoCreador.xaml
    /// </summary>
    public partial class VentanaJuegoCreador : Window {
        public VentanaJuegoCreador() {
            InitializeComponent();
        }

        private void btnAbandonar_Click(object sender, RoutedEventArgs e) {
            DialogoAbandonarPartida dialogo = new DialogoAbandonarPartida();
            dialogo.Owner = this;
            dialogo.ShowDialog();
            if (dialogo.Abandono) {
                DialogoPenalizacion penalizacion = new DialogoPenalizacion();
                penalizacion.Show();
                this.Close();
            }
        }

        private void btnEnviarMensaje_Click(object sender, RoutedEventArgs e) {
        }
    }
}
