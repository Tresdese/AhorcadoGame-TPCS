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

namespace ClienteAhorcado
{
  
    public partial class DialogoRivalAbandono : Window
    {
        private readonly int _idPartida;
        private readonly string _nombreRival;
        private readonly bool _penalizado;

        public DialogoRivalAbandono(int idPartida, string nombreRival, bool penalizado = true)
        {
            InitializeComponent();
            _idPartida = idPartida;
            _nombreRival = nombreRival;
            _penalizado = penalizado;

            Loaded += DialogoRivalAbandono_Loaded;
        }

        private void DialogoRivalAbandono_Loaded(object sender, RoutedEventArgs e)
        {
            txtNombreRival.Text = _nombreRival;
            if (!_penalizado) txtPenalizacion.Text = "";
        }
        
        private void btnLobby_Click(object sender, RoutedEventArgs e)
        {
            Navegacion.Ir(new VentanaPartidas());
            Close();
        }
    }
}