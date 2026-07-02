using AhorcadoWCF;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClienteAhorcado {
    public partial class VentanaEditarPerfil : Page {
        public VentanaEditarPerfil() {
            InitializeComponent();
            btnIdioma.Content = SesionActual.Idioma == "es" ? "🌐 ES" : "🌐 EN";
            ConfigurarRangoFechas();
            CargarDatosActuales();
        }

        private void btnIdioma_Click(object sender, RoutedEventArgs e) {
            string nuevo = SesionActual.Idioma == "es" ? "en" : "es";
            GestorIdioma.Cambiar(nuevo);
        }

        private void ConfigurarRangoFechas() {
            DateTime hoy = DateTime.Today;
            dpFechaNacimiento.DisplayDateEnd = hoy.AddYears(-10);
            dpFechaNacimiento.DisplayDateStart = hoy.AddYears(-120);
            dpFechaNacimiento.DisplayDate = hoy.AddYears(-10);
        }

        private void CargarDatosActuales() {
            UsuarioDTO usuario = null;
            if (!ManejadorErrores.Ejecutar(() => { usuario = Conexiones.Usuario().ObtenerPerfil(SesionActual.IdUsuario); })) {
                Navegacion.Ir(new VentanaPerfil());
                return;
            }

            if (usuario == null) {
                Navegacion.Ir(new VentanaPerfil());
                return;
            }

            txtNombre.Text = usuario.Nombre;
            txtCelular.Text = usuario.Telefono;
            dpFechaNacimiento.SelectedDate = usuario.FechaNacimiento;

            lblNombreEncabezado.Text = usuario.Nombre;
            lblCorreoEncabezado.Text = usuario.Correo;
            btnUsuario.Content = usuario.Nombre + " ▼";
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaPerfil ventanaPerfil = new VentanaPerfil();
            Navegacion.Ir(ventanaPerfil);
        }

        private void btnCambiarContrasena_Click(object sender, RoutedEventArgs e) {
            var dialogo = new DialogoCambiarContrasena();
            dialogo.Owner = Window.GetWindow(this);
            dialogo.ShowDialog();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            VentanaPerfil ventanaPerfil = new VentanaPerfil();
            Navegacion.Ir(ventanaPerfil);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e) {
            lblErrorNombre.Visibility = Visibility.Collapsed;
            lblErrorFecha.Visibility = Visibility.Collapsed;
            lblErrorCelular.Visibility = Visibility.Collapsed;

            string nombre = txtNombre.Text.Trim();
            DateTime? fechaNacimiento = dpFechaNacimiento.SelectedDate;
            string celular = txtCelular.Text.Trim();

            bool hayError = false;

            if (string.IsNullOrWhiteSpace(nombre)) {
                lblErrorNombre.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (fechaNacimiento == null) {
                lblErrorFecha.Text = Properties.Resources.RegistrarCuenta_ErrorFechaVacia;
                lblErrorFecha.Visibility = Visibility.Visible;
                hayError = true;
            } else if (!EdadMinimaPermitida(fechaNacimiento.Value)) {
                lblErrorFecha.Text = Properties.Resources.RegistrarCuenta_ErrorEdadMinima;
                lblErrorFecha.Visibility = Visibility.Visible;
                hayError = true;
            } else if (!EdadMaximaPermitida(fechaNacimiento.Value)) {
                lblErrorFecha.Text = Properties.Resources.RegistrarCuenta_ErrorEdadMaxima;
                lblErrorFecha.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (string.IsNullOrWhiteSpace(celular) || !CelularEsValido(celular)) {
                lblErrorCelular.Text = Properties.Resources.RegistrarCuenta_ErrorCelularInvalido;
                lblErrorCelular.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (hayError) {
                return;
            }

            UsuarioDTO usuarioActualizado = new UsuarioDTO {
                IdUsuario = SesionActual.IdUsuario,
                Nombre = nombre,
                FechaNacimiento = fechaNacimiento.Value,
                Telefono = celular
            };

            bool actualizado = false;
            if (!ManejadorErrores.Ejecutar(() => { actualizado = Conexiones.Usuario().ActualizarPerfil(usuarioActualizado); })) {
                return;
            }

            if (actualizado) {
                SesionActual.Nombre = nombre;
                MessageBox.Show(
                    Properties.Resources.EditarPerfil_ExitoMensaje,
                    Properties.Resources.EditarPerfil_ExitoTitulo,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                VentanaPerfil ventanaPerfil = new VentanaPerfil();
                Navegacion.Ir(ventanaPerfil);
            }
        }

        private bool EdadMinimaPermitida(DateTime fechaNacimiento) {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) {
                edad--;
            }
            return edad >= 10;
        }

        private bool EdadMaximaPermitida(DateTime fechaNacimiento) {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) {
                edad--;
            }
            return edad <= 120;
        }

        private bool CelularEsValido(string celular) {
            string soloDigitos = celular.Replace("+", "").Replace(" ", "").Replace("-", "");
            return soloDigitos.All(c => char.IsDigit(c)) && soloDigitos.Length >= 10 && soloDigitos.Length <= 15;
        }
    }
}
