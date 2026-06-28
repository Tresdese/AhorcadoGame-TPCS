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
  
  
    public partial class VentanaHistorial : Window
    {
       
        private string _filtroActivo = "Ganadas";

       
        public VentanaHistorial()
        {
            InitializeComponent();
            Loaded += VentanaHistorial_Loaded;
        }

        
        private void VentanaHistorial_Loaded(object sender, RoutedEventArgs e)
        {
            CargarEstadisticas();
            CargarHistorial("Ganadas");
        }

       
        private void CargarEstadisticas()
        {
            try
            {
                var cliente = Conexiones.Puntaje();

                int puntajeGlobal = cliente.ObtenerPuntajeGlobal(SesionActual.IdUsuario);
                int partidasGanadas = cliente.ObtenerPartidasGanadas(SesionActual.IdUsuario);
                int rivalNoPudo = cliente.ObtenerPartidasRivalNoPudo(SesionActual.IdUsuario);
                int penalizaciones = cliente.ObtenerPenalizaciones(SesionActual.IdUsuario);

               
                txtPuntajeGlobal.Text = puntajeGlobal.ToString();
                txtGanadas.Text = partidasGanadas.ToString();
                txtRivalNoPudo.Text = rivalNoPudo.ToString();
                txtPenalizaciones.Text = penalizaciones.ToString();

                
                btnGanadas.Content = $"Partidas ganadas ({partidasGanadas})";
                btnRival.Content = $"Rival no adivinó ({rivalNoPudo})";
                btnPenalizaciones.Content = $"Penalizaciones ({penalizaciones})";
            }
            catch (Exception)
            {
                MostrarErrorConexion();
            }
        }

        private void CargarHistorial(string filtro)
        {
            _filtroActivo = filtro;
            ActualizarBotonesFiltro();
            ActualizarColumnasTabla(filtro);

            try
            {
                var cliente = Conexiones.Puntaje();
                List<PuntajeHistorialDTO> registros;

                switch (filtro)
                {
                    case "Ganadas":
                        registros = cliente.ObtenerHistorialPorTipo(SesionActual.IdUsuario, "Ganada");
                        break;
                    case "Rival":
                        registros = cliente.ObtenerHistorialPorTipo(SesionActual.IdUsuario, "RivalNoPudo");
                        break;
                    case "Penalizaciones":
                        registros = cliente.ObtenerHistorialPorTipo(SesionActual.IdUsuario, "Penalizacion");
                        break;
                    default:
                        registros = new List<PuntajeHistorialDTO>();
                        break;
                }

                
                if (registros == null)
                {
                    MostrarErrorConexion();
                    return;
                }

                
                if (registros.Count == 0)
                {
                    MostrarSinRegistros();
                    return;
                }

                MostrarRegistros(registros, filtro);
            }
            catch (Exception)
            {
                MostrarErrorConexion();
            }
        }

        
        private void MostrarRegistros(List<PuntajeHistorialDTO> registros, string filtro)
        {
            lvHistorial.Items.Clear();

            var items = registros.Select(r => new HistorialItemViewModel
            {
                Fecha = r.Fecha,
                Palabra = r.Palabra,
                Rival = r.NombreRival,
                Puntos = filtro == "Penalizaciones"
                            ? $"–{r.Puntos} pts"
                            : $"+{r.Puntos} pts",
                Color = filtro == "Penalizaciones" ? "Red" : "Green"
            }).ToList();

            lvHistorial.ItemsSource = items;
        }

        
        private void MostrarSinRegistros()
        {
            lvHistorial.Items.Clear();
            lvHistorial.ItemsSource = null;
            lvHistorial.Items.Add(new ListViewItem
            {
                Content = "No hay registros en esta categoría.",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14,
                Foreground = Brushes.Gray,
                IsEnabled = false
            });
        }

       
        private void ActualizarBotonesFiltro()
        {
            
            SetBotonInactivo(btnGanadas);
            SetBotonInactivo(btnRival);
            SetBotonInactivo(btnPenalizaciones);

           
            switch (_filtroActivo)
            {
                case "Ganadas": SetBotonActivo(btnGanadas); break;
                case "Rival": SetBotonActivo(btnRival); break;
                case "Penalizaciones": SetBotonActivo(btnPenalizaciones); break;
            }
        }

        private void SetBotonActivo(Button btn)
        {
            btn.Background = new SolidColorBrush(Color.FromRgb(0, 120, 212));
            btn.Foreground = Brushes.White;
            btn.BorderThickness = new Thickness(0);
        }

        private void SetBotonInactivo(Button btn)
        {
            btn.Background = Brushes.White;
            btn.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            btn.BorderBrush = new SolidColorBrush(Color.FromRgb(204, 204, 204));
            btn.BorderThickness = new Thickness(1);
        }

        
        private void ActualizarColumnasTabla(string filtro)
        {
            switch (filtro)
            {
                case "Ganadas":
                    colPalabra.Text = "PALABRA ADIVINADA";
                    colRival.Text = "RIVAL VENCIDO";
                    break;
                case "Rival":
                    colPalabra.Text = "PALABRA ELEGIDA";
                    colRival.Text = "RIVAL QUE FALLÓ";
                    break;
                case "Penalizaciones":
                    colPalabra.Text = "PALABRA EN JUEGO";
                    colRival.Text = "PARTIDA ABANDONADA";
                    break;
            }
        }

        
        private void btnGanadas_Click(object sender, RoutedEventArgs e)
            => CargarHistorial("Ganadas");

        private void btnRival_Click(object sender, RoutedEventArgs e)
            => CargarHistorial("Rival");

        private void btnPenalizaciones_Click(object sender, RoutedEventArgs e)
            => CargarHistorial("Penalizaciones");

        
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            new VentanaPartidas().Show();
            Close();
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
    }
}
