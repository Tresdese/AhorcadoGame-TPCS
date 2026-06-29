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

        public DialogoRivalAbandono(int idPartida, string nombreRival)
        {
            InitializeComponent();
            _idPartida = idPartida;
            _nombreRival = nombreRival;

            Loaded += DialogoRivalAbandono_Loaded;
        }

        private void DialogoRivalAbandono_Loaded(object sender, RoutedEventArgs e)
        {
            txtNombreRival.Text = _nombreRival;
        }

      
        private void btnEsperar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cliente = Conexiones.Partida();
                bool reabierta = cliente.ReabrirPartida(_idPartida);

                if (!reabierta)
                {
                    MessageBox.Show(
                        Properties.Resources.RivalAbandono_ErrorReabrir,
                        Properties.Resources.Comun_Error,
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    new VentanaPartidas().Show();
                    Close();
                    return;
                }

                new VentanaEsperandoRival().Show();
                Close();
            }
            catch
            {
                MessageBox.Show(
                    Properties.Resources.Partidas_ErrorConexion,
                    Properties.Resources.Comun_Error,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        
        private void btnLobby_Click(object sender, RoutedEventArgs e)
        {
            new VentanaPartidas().Show();
            Close();
        }
    }
}