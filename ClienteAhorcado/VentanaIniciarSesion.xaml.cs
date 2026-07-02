using AhorcadoWCF;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ClienteAhorcado {
    public partial class VentanaIniciarSesion : Page {
        public VentanaIniciarSesion() {
            InitializeComponent();
            btnIdioma.Content = SesionActual.Idioma == "es" ? "🌐 ES" : "🌐 EN";
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaBienvenida ventanaBienvenida = new VentanaBienvenida();
            Navegacion.Ir(ventanaBienvenida);
        }

        private void btnIdioma_Click(object sender, RoutedEventArgs e) {
            string nuevo = SesionActual.Idioma == "es" ? "en" : "es";
            GestorIdioma.Cambiar(nuevo);
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e) {
            lblErrorCorreo.Visibility = Visibility.Collapsed;
            lblErrorContrasena.Visibility = Visibility.Collapsed;

            var bordeNormal = new SolidColorBrush(Color.FromRgb(0xCC, 0xCC, 0xCC));
            txtCorreo.BorderBrush = bordeNormal;
            txtContrasena.BorderBrush = bordeNormal;

            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Password;

            bool hayError = false;

            if (string.IsNullOrWhiteSpace(correo)) {
                lblErrorCorreo.Text = Properties.Resources.IniciarSesion_ErrorCorreoVacio;
                lblErrorCorreo.Visibility = Visibility.Visible;
                txtCorreo.BorderBrush = Brushes.Red;
                hayError = true;
            } else if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) {
                lblErrorCorreo.Text = Properties.Resources.comun_ErrorCorreoInvalido;
                lblErrorCorreo.Visibility = Visibility.Visible;
                txtCorreo.BorderBrush = Brushes.Red;
                hayError = true;
            }

            if (string.IsNullOrWhiteSpace(contrasena)) {
                lblErrorContrasena.Text = Properties.Resources.IniciarSesion_ErrorContrasenaVacia;
                lblErrorContrasena.Visibility = Visibility.Visible;
                txtContrasena.BorderBrush = Brushes.Red;
                hayError = true;
            }

            if (hayError) {
                return;
            }

            UsuarioDTO usuario = null;
            if (!ManejadorErrores.Ejecutar(() => { usuario = Conexiones.Autenticacion().IniciarSesion(correo, contrasena); })) {
                return;
            }

            if (usuario != null) {
                SesionActual.IdUsuario = usuario.IdUsuario;
                SesionActual.Nombre = usuario.Nombre;
                SesionActual.Correo = usuario.Correo;

                VentanaPartidas ventanaPartidas = new VentanaPartidas();
                Navegacion.Ir(ventanaPartidas);
                return;
            }

            bool correoExiste = false;
            if (!ManejadorErrores.Ejecutar(() => { correoExiste = Conexiones.Autenticacion().VerificarCorreoExistente(correo); })) {
                return;
            }

            if (correoExiste) {
                lblErrorContrasena.Text = Properties.Resources.IniciarSesion_ErrorContrasena;
                lblErrorContrasena.Visibility = Visibility.Visible;
                txtContrasena.BorderBrush = Brushes.Red;
            } else {
                lblErrorCorreo.Text = Properties.Resources.IniciarSesion_ErrorCorreo;
                lblErrorCorreo.Visibility = Visibility.Visible;
                txtCorreo.BorderBrush = Brushes.Red;
            }
        }

        private void lnkRegistrate_Click(object sender, MouseButtonEventArgs e) {
            VentanaRegistrarCuenta ventanaRegistrarCuenta = new VentanaRegistrarCuenta();
            Navegacion.Ir(ventanaRegistrarCuenta);
        }
    }
}
