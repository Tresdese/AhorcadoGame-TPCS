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

namespace ClienteAhorcado {  
    public partial class VentanaPartidas : Window {   
        public VentanaPartidas() {
            InitializeComponent();
            btnIdioma.Content = SesionActual.Idioma == "es" ? "🌐 ES" : "🌐 EN";
            Loaded += VentanaPartidas_Loaded;
        }

        private void btnIdioma_Click(object sender, RoutedEventArgs e) {
            string nuevo = SesionActual.Idioma == "es" ? "en" : "es";
            GestorIdioma.Cambiar(nuevo);
        }

        private void VentanaPartidas_Loaded(object sender, RoutedEventArgs e) {
            btnUsuario.Content = $"{SesionActual.Nombre} ▼";
            CargarPartidasDisponibles();
        }

        private void CargarPartidasDisponibles() {
            try {
                var cliente = Conexiones.Partida();
                var partidas = cliente.ObtenerPartidasDisponibles();
               
                if (partidas == null) {
                    MostrarErrorConexion();
                    return;
                }
                
                if (partidas.Count == 0) {
                    MostrarSinPartidas();
                    return;
                }
         
                MostrarListaPartidas(partidas);
            } catch (Exception) {
                MostrarErrorConexion(); 
            }
        }

        private void MostrarListaPartidas(List<PartidaDTO> partidas) {
            lvPartidas.ItemsSource = null;
            lvPartidas.Items.Clear();

            var items = partidas.Select(p => new PartidaItemViewModel {
                IdPartida = p.IdPartida,
                Creador = p.NombreCreador,
                Correo = p.CorreoCreador,
                Creada = p.FechaCreacion
            }).ToList();

            lvPartidas.ItemsSource = items;
            lblContadorPartidas.Text = items.Count + " " + Properties.Resources.Partidas_DisponiblesSufijo;
        }


        private void MostrarSinPartidas() {
            lvPartidas.ItemsSource = null;
            lvPartidas.Items.Clear();
            lvPartidas.Items.Add(new ListViewItem {
                Content = Properties.Resources.Partidas_SinPartidas,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14,
                Foreground = System.Windows.Media.Brushes.Gray,
                IsEnabled = false
            });

            lblContadorPartidas.Text = "0 " + Properties.Resources.Partidas_DisponiblesSufijo;
        }

        private void MostrarErrorConexion() {
            MessageBox.Show(
                Properties.Resources.Partidas_ErrorConexion,
                Properties.Resources.Comun_Error,
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e) {
            CargarPartidasDisponibles();
        }

        private void btnCrearPartida_Click(object sender, RoutedEventArgs e) {
            var ventanaEspera = new VentanaEsperandoRival();
            ventanaEspera.Show();
            Close();
        }
       
        private void btnUnirme_Click(object sender, RoutedEventArgs e) {
            var boton = sender as Button;
            var item = boton?.DataContext as PartidaItemViewModel;

            if (item == null) return;

            try {
                var clientePartida = Conexiones.Partida();
                bool sigueDisponible = clientePartida.VerificarDisponibilidadPartida(item.IdPartida);

                if (!sigueDisponible) {
                    MessageBox.Show(
                        Properties.Resources.Partidas_NoDisponibleMensaje,
                        Properties.Resources.Partidas_NoDisponibleTitulo,
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    
                    CargarPartidasDisponibles();
                    return;
                }

                bool unido = clientePartida.UnirseAPartida(item.IdPartida, SesionActual.IdUsuario);

                if (!unido) {
                    MessageBox.Show(
                        Properties.Resources.Partidas_ErrorConexion,
                        Properties.Resources.Comun_Error,
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                SesionActual.IdPartida = item.IdPartida;
                JuegoCallbackHandler.ClienteJuego = Conexiones.Juego(
                    new System.ServiceModel.InstanceContext(new JuegoCallbackHandler()));

                JuegoCallbackHandler.ClienteJuego.UnirseASalaDePartida(item.IdPartida, SesionActual.IdUsuario);

                var ventanaEspera = new VentanaEsperandoPalabra(item.IdPartida, item.Creador);
                ventanaEspera.Show();
                Close();
            } catch (Exception) {
                MessageBox.Show(
                    "Error de conexión con base de datos, inténtelo más tarde.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
      
        private void btnUsuario_Click(object sender, RoutedEventArgs e) {
            menuUsuario.PlacementTarget = btnUsuario;
            menuUsuario.IsOpen = true;
        }

        private void mnuVerPerfil_Click(object sender, RoutedEventArgs e) {
            var ventanaPerfil = new VentanaPerfil();
            ventanaPerfil.Show();
            Close();
        }

        private void mnuHistorial_Click(object sender, RoutedEventArgs e) {
            var ventanaHistorial = new VentanaHistorial();
            ventanaHistorial.Show();
            Close();
        }

        private void mnuCerrarSesion_Click(object sender, RoutedEventArgs e) {
            var respuesta = MessageBox.Show(
                Properties.Resources.Partidas_ConfirmarCerrarMensaje,
                Properties.Resources.Partidas_CerrarSesion,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.Yes) {
                SesionActual.Cerrar();
                var ventanaLogin = new VentanaIniciarSesion();
                ventanaLogin.Show();
                Close();
            }
        }
    }
}