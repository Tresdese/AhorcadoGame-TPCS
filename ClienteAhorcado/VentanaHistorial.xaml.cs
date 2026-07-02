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
  
  
    public partial class VentanaHistorial : Page
    {
       
        private string _filtroActivo = "Ganadas";

       
        public VentanaHistorial()
        {
            InitializeComponent();
            Loaded += VentanaHistorial_Loaded;
        }

        
        private void VentanaHistorial_Loaded(object sender, RoutedEventArgs e)
        {
            btnUsuario.Content = $"{SesionActual.Nombre} ▼";
            btnIdioma.Content = SesionActual.Idioma == "es" ? "🌐 ES" : "🌐 EN";

            CargarEstadisticas();
            CargarHistorial("Ganadas");
        }

        private void btnIdioma_Click(object sender, RoutedEventArgs e)
        {
            GestorIdioma.Cambiar(SesionActual.Idioma == "es" ? "en" : "es");
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
                int abandonos = cliente.ObtenerPartidasAbandono(SesionActual.IdUsuario);


                txtPuntajeGlobal.Text = puntajeGlobal.ToString();
                txtGanadas.Text = partidasGanadas.ToString();
                txtRivalNoPudo.Text = rivalNoPudo.ToString();
                txtPenalizaciones.Text = penalizaciones.ToString();
                txtAbandonos.Text = abandonos.ToString();


                btnGanadas.Content = string.Format(Properties.Resources.Historial_BtnGanadas, partidasGanadas);
                btnRival.Content = string.Format(Properties.Resources.Historial_BtnRival, rivalNoPudo);
                btnPenalizaciones.Content = string.Format(Properties.Resources.Historial_BtnPenalizaciones, penalizaciones);
                btnAbandono.Content = string.Format(Properties.Resources.Historial_BtnAbandono, abandonos);
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
                    case "Abandono":
                        registros = cliente.ObtenerHistorialPorTipo(SesionActual.IdUsuario, "PartidaAbandono");
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
            lvHistorial.ItemsSource = null;
            lvHistorial.Items.Clear();

            var items = registros.Select(r => new HistorialItemViewModel
            {
                Fecha = r.Fecha,
                Palabra = r.Palabra,
                Rival = r.NombreRival,
                Puntos = filtro == "Penalizaciones"
                            ? string.Format(Properties.Resources.Historial_PuntosPerdidos, r.Puntos)
                            : string.Format(Properties.Resources.Historial_PuntosGanados, r.Puntos),
                Color = filtro == "Penalizaciones" ? "Red" : (filtro == "Abandono" ? "DarkOrange" : "Green")
            }).ToList();

            lvHistorial.ItemsSource = items;
        }

        
        private void MostrarSinRegistros()
        {
            lvHistorial.ItemsSource = null;
            lvHistorial.Items.Clear();
            lvHistorial.Items.Add(new ListViewItem
            {
                Content = Properties.Resources.Historial_SinRegistros,
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
                    colPalabra.Text = Properties.Resources.Historial_ColPalabraGanadas;
                    colRival.Text = Properties.Resources.Historial_ColRivalGanadas;
                    break;
                case "Rival":
                    colPalabra.Text = Properties.Resources.Historial_ColPalabraRival;
                    colRival.Text = Properties.Resources.Historial_ColRivalRival;
                    break;
                case "Penalizaciones":
                    colPalabra.Text = Properties.Resources.Historial_ColPalabraPenal;
                    colRival.Text = Properties.Resources.Historial_ColRivalPenal;
                    break;
                case "Abandono":                   
                    colPalabra.Text = Properties.Resources.Historial_ColPalabraPenal;
                    colRival.Text = Properties.Resources.Historial_ColRivalPenal;
                    break;
            }
        }

        
        private void btnGanadas_Click(object sender, RoutedEventArgs e)
            => CargarHistorial("Ganadas");

        private void btnRival_Click(object sender, RoutedEventArgs e)
            => CargarHistorial("Rival");

        private void btnPenalizaciones_Click(object sender, RoutedEventArgs e)
            => CargarHistorial("Penalizaciones");

        private void btnAbandono_Click(object sender, RoutedEventArgs e)
            => CargarHistorial("Abandono");

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Navegacion.Ir(new VentanaPartidas());
        }

        
        private void MostrarErrorConexion()
        {
            MessageBox.Show(
                Properties.Resources.Partidas_ErrorConexion,
                Properties.Resources.Comun_Error,
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            Navegacion.Ir(new VentanaPartidas());
        }
    }
}
