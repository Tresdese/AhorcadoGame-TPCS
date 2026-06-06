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
    /// Lógica de interacción para DialogoAbandonarPartida.xaml
    /// </summary>
    public partial class DialogoAbandonarPartida : Window {
        public DialogoAbandonarPartida() {
            InitializeComponent();
        }

        public bool Abandono { get; private set; } = false;

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            Abandono = false;
            this.Close();
        }

        private void btnAbandonar_Click(object sender, RoutedEventArgs e) {
            Abandono = true;
            this.Close();
        }
    }
}
