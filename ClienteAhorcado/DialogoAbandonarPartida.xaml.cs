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
    public partial class DialogoAbandonarPartida : Window
    {
        private readonly int _idPartida;
        
        public bool Confirmo { get; private set; } = false;

        public DialogoAbandonarPartida(int idPartida)
        {
            InitializeComponent();
            _idPartida = idPartida;
        }
      
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Confirmo = false;
            Close();
        }
        
        private void btnAbandonar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var clienteJuego = Conexiones.Juego(
                    new System.ServiceModel.InstanceContext(new JuegoCallbackHandler()));
                clienteJuego.NotificarAbandono(_idPartida, SesionActual.IdUsuario);

                var clientePartida = Conexiones.Partida();
                clientePartida.AbandonarPartida(_idPartida, SesionActual.IdUsuario);

                Confirmo = true;
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
    }
}
