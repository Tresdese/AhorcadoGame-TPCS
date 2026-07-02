using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AhorcadoWCF;

namespace ClienteAhorcado {
    public partial class VentanaElegirPalabra : Page {
        private readonly int _idCategoria;

        public VentanaElegirPalabra(int idCategoria, string nombreCategoria) {
            InitializeComponent();
            _idCategoria = idCategoria;
            lblCategoria.Text = string.Format(Properties.Resources.ElegirPalabra_CategoriaConNombre, nombreCategoria);
            Loaded += (s, e) => CargarPalabras();
        }

        private void CargarPalabras() {
            var palabras = ManejadorErrores.Ejecutar(
                () => Conexiones.Palabra().ObtenerPalabrasPorCategoria(_idCategoria),
                new List<PalabraDTO>());
            lstPalabras.ItemsSource = palabras;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e) {
            var palabra = lstPalabras.SelectedItem as PalabraDTO;
            if (palabra == null) {
                MessageBox.Show(Properties.Resources.ElegirPalabra_ErrorMensaje, Properties.Resources.Comun_Palabra,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            bool asignada = ManejadorErrores.Ejecutar(
                () => Conexiones.Palabra().AsignarPalabraAPartida(SesionActual.IdPartida, palabra.IdPalabra),
                false);
            if (!asignada) return;

            Navegacion.Ir(new VentanaJuegoCreador(palabra.Texto, palabra.Descripcion, palabra.Categoria));
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaElegirCategoria ventana = new VentanaElegirCategoria();
            Navegacion.Ir(ventana);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            ManejadorErrores.Ejecutar(() => JuegoCallbackHandler.ClienteJuego?.NotificarAbandono(SesionActual.IdPartida, SesionActual.IdUsuario));

            Navegacion.Ir(new VentanaPartidas());
        }
    }
}
