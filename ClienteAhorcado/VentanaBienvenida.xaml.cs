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
    public partial class VentanaBienvenida : Page {
        public VentanaBienvenida() {
            InitializeComponent();
            btnIdioma.Content = SesionActual.Idioma == "es" ? "🌐 ES" : "🌐 EN";
            ConstruirPalabraDecorativa(Properties.Resources.Bienvenida_PalabraDecorativa);
        }

        private void ConstruirPalabraDecorativa(string patron) {
            panelPalabra.Children.Clear();

            foreach (char c in patron) {
                bool revelada = c != '_';

                var borde = new Border {
                    BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(
                        revelada ? "#0078D4" : "#999999")),
                    BorderThickness = new Thickness(1),
                    Width = 45,
                    Height = 50,
                    Margin = new Thickness(3)
                };

                if (revelada) {
                    borde.Child = new TextBlock {
                        Text = c.ToString(),
                        FontSize = 22,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                }

                panelPalabra.Children.Add(borde);
            }
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e) {
            VentanaIniciarSesion ventanaIniciarSesion = new VentanaIniciarSesion();
            Navegacion.Ir(ventanaIniciarSesion);
        }

        private void btnRegistrarCuenta_Click(object sender, RoutedEventArgs e) {
            VentanaRegistrarCuenta ventanaRegistrarCuenta = new VentanaRegistrarCuenta();
            Navegacion.Ir(ventanaRegistrarCuenta);
        }

        private void btnIdioma_Click(object sender, RoutedEventArgs e) {
            string nuevo = SesionActual.Idioma == "es" ? "en" : "es";
            GestorIdioma.Cambiar(nuevo);
        }
    }
}
