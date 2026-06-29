using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
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
    public partial class VentanaEsperandoRival : Window
    {
        private int idPartidaActual;
        
        private DispatcherTimer _timer;
        private int segundosEspera = 0;
        
        public VentanaEsperandoRival()
        {
            InitializeComponent();
            Loaded += VentanaEsperandoRival_Loaded;
        }
        
        private void VentanaEsperandoRival_Loaded(object sender, RoutedEventArgs e)
        {
            CrearPartida();
        }
       
        private void CrearPartida()
        {
            try
            {
                var cliente = Conexiones.Partida();
                var partida = cliente.CrearPartida(SesionActual.IdUsuario);
                
                if (partida == null)
                {
                    MostrarErrorConexion();
                    return;
                }
                
                idPartidaActual = partida.IdPartida;
                SesionActual.IdPartida = partida.IdPartida;

                JuegoCallbackHandler.VentanaEspera = this;
                JuegoCallbackHandler.ClienteJuego = Conexiones.Juego(
                    new System.ServiceModel.InstanceContext(new JuegoCallbackHandler()));
                JuegoCallbackHandler.ClienteJuego.UnirseASalaDePartida(idPartidaActual, SesionActual.IdUsuario);

                IniciarCronometro();
            }
            catch (Exception)
            {
                
                MostrarErrorConexion();
            }
        }
        
        private void IniciarCronometro()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
 
            _timer.Tick += (s, e) =>
            {
                segundosEspera++;
                int min = segundosEspera / 60;
                int seg = segundosEspera % 60;
                lblTiempo.Text = $"{min:D2}:{seg:D2}";
            };
 
            _timer.Start();
        }
 
        private void DetenerCronometro() => _timer?.Stop();
      
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            var respuesta = MessageBox.Show(
                "¿Seguro que deseas cancelar la partida?",
                "Cancelar partida",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
 
            if (respuesta == MessageBoxResult.Yes)
            {
                DetenerCronometro();
 
                try
                {
                    var cliente = Conexiones.Partida();
                    cliente.CancelarPartida(idPartidaActual);
                }
                catch (Exception)
                {

                }

                JuegoCallbackHandler.VentanaEspera = null;
                new VentanaPartidas().Show();
                Close();
            }
        }
        
        private void MostrarErrorConexion()
        {
            MessageBox.Show(
                "Error de conexión con base de datos, inténtelo más tarde.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            JuegoCallbackHandler.VentanaEspera = null;
            new VentanaPartidas().Show();
            Close();
        }
        
        public void NotificarAdivinadorUnido()
        {
            Dispatcher.Invoke(() =>
            {
                DetenerCronometro();
                JuegoCallbackHandler.VentanaEspera = null;
                new VentanaElegirCategoria().Show();
                Close();
            });
        }
    }
}
