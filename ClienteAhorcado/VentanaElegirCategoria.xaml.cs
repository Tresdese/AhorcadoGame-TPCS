using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AhorcadoWCF;

namespace ClienteAhorcado {
    public partial class VentanaElegirCategoria : Page {
        public VentanaElegirCategoria() {
            InitializeComponent();
            Loaded += (s, e) => CargarCategorias();
        }

        private void CargarCategorias() {
            var categorias = ManejadorErrores.Ejecutar(
                () => Conexiones.Palabra().ObtenerCategorias(SesionActual.Idioma),
                new List<CategoriaDTO>());
            lstCategorias.ItemsSource = categorias;
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e) {
            var categoria = lstCategorias.SelectedItem as CategoriaDTO;
            if (categoria == null) {
                MessageBox.Show(Properties.Resources.ElegirCategoria_ErrorMensaje, Properties.Resources.Comun_Categoria,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Navegacion.Ir(new VentanaElegirPalabra(categoria.IdCategoria, categoria.Nombre));
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            JuegoCallbackHandler.VentanaEsperaPalabra = null;
            ManejadorErrores.Ejecutar(() => JuegoCallbackHandler.ClienteJuego.NotificarAbandono(SesionActual.IdPartida, SesionActual.IdUsuario));
            Navegacion.Ir(new VentanaPartidas());
        }
    }
}
