using AhorcadoWCF;
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
   
    public partial class VentanaPartidas : Window
    {
        
        public VentanaPartidas()
        {
            InitializeComponent();
            Loaded += VentanaPartidas_Loaded;
        }

       
        private void VentanaPartidas_Loaded(object sender, RoutedEventArgs e)
        {
            btnUsuario.Content = $"{SesionActual.Nombre} ▼";
            CargarPartidasDisponibles();
        }

        private void CargarPartidasDisponibles()
        {
            try
            {
                var cliente = new PartidaServiceClient();
                var partidas = cliente.ObtenerPartidasDisponibles();

               
                if (partidas == null)
                {
                    MostrarErrorConexion();
                    return;
                }

                
                if (partidas.Count == 0)
                {
                    MostrarSinPartidas();
                    return;
                }

         
                MostrarListaPartidas(partidas);
            }
            catch (Exception)
            {
                MostrarErrorConexion(); 
            }
        }

       
        private void MostrarListaPartidas(List<PartidaDTO> partidas)
        {
          
            lvPartidas.Items.Clear();

            var items = partidas.Select(p => new PartidaItemViewModel
            {
                IdPartida = p.IdPartida,
                Creador = p.NombreCreador,
                Correo = p.CorreoCreador,
                Creada = p.FechaCreacion
            }).ToList();

            lvPartidas.ItemsSource = items;
        }

        
        private void MostrarSinPartidas()
        {
            lvPartidas.Items.Clear();
            lvPartidas.ItemsSource = null;

            
            lvPartidas.Items.Add(new ListViewItem
            {
                Content = "No hay partidas disponibles en este momento.",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14,
                Foreground = System.Windows.Media.Brushes.Gray,
                IsEnabled = false
            });
        }

        
        private void MostrarErrorConexion()
        {
            MessageBox.Show(
                "Error de conexión con base de datos, inténtelo más tarde.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            Close();
        }

       
        private void btnCrearPartida_Click(object sender, RoutedEventArgs e)
        {
            var ventanaEspera = new VentanaEsperandoRival();
            ventanaEspera.Show();
            Close();
        }

       
        private void btnUnirme_Click(object sender, RoutedEventArgs e)
        {

            var boton = sender as Button;
            var item = boton?.DataContext as PartidaItemViewModel;

            if (item == null) return;

            try
            {
                
                var clientePartida = new PartidaServiceClient();
                bool sigueDisponible = clientePartida.VerificarDisponibilidadPartida(item.IdPartida);

                
                if (!sigueDisponible)
                {
                    MessageBox.Show(
                        "Esta partida ya no está disponible. Por favor elige otra.",
                        "Partida no disponible",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    CargarPartidasDisponibles(); 
                    return;
                }

                
                bool unido = clientePartida.UnirseAPartida(item.IdPartida, SesionActual.IdUsuario);

               
                if (!unido)
                {
                    MessageBox.Show(
                        "Error de conexión con base de datos, inténtelo más tarde.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

               
                var clienteJuego = new JuegoCallbackServiceClient(
                    new System.ServiceModel.InstanceContext(new JuegoCallbackHandler()));

                clienteJuego.UnirseASalaDePartida(item.IdPartida, SesionActual.IdUsuario);

               
                var ventanaJuego = new VentanaJuegoAdivinador(item.IdPartida, item.Creador);
                ventanaJuego.Show();
                Close();
            }
            catch (Exception)
            {
               
                MessageBox.Show(
                    "Error de conexión con base de datos, inténtelo más tarde.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

      
        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            menuUsuario.PlacementTarget = btnUsuario;
            menuUsuario.IsOpen = true;
        }

        
        private void mnuVerPerfil_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Ver perfil — pendiente de implementar.");
        }


        private void mnuHistorial_Click(object sender, RoutedEventArgs e)
        {
            var ventanaHistorial = new VentanaHistorial();
            ventanaHistorial.Show();
            Close();
        }


        private void mnuCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var respuesta = MessageBox.Show(
                "¿Seguro que deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.Yes)
            {
                SesionActual.Cerrar();
                var ventanaLogin = new VentanaIniciarSesion();
                ventanaLogin.Show();
                Close();
            }
        }
    }
}