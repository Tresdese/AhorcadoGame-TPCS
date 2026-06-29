using System.Collections.Generic;
using System.Windows;
using AhorcadoWCF;

namespace ClienteAhorcado {
    public partial class VentanaElegirCategoria : Window {
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
            new VentanaElegirPalabra(categoria.IdCategoria, categoria.Nombre).Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaPartidas ventana = new VentanaPartidas();
            ventana.Show();
            this.Close();
        }
    }
}
