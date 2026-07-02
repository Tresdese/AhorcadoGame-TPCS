using AhorcadoWCF;
using System.Linq;
using System.Windows;

namespace ClienteAhorcado {
    public partial class DialogoCambiarContrasena : Window {
        public DialogoCambiarContrasena() {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e) {
            lblErrorActual.Visibility = Visibility.Collapsed;
            string actual = txtActual.Password;

            if (string.IsNullOrWhiteSpace(actual)) {
                lblErrorActual.Text = Properties.Resources.CambiarContrasena_ErrorActualVacia;
                lblErrorActual.Visibility = Visibility.Visible;
                return;
            }

            UsuarioDTO usuario = null;
            if (!ManejadorErrores.Ejecutar(() => { usuario = Conexiones.Autenticacion().IniciarSesion(SesionActual.Correo, actual); })) {
                return;
            }

            if (usuario == null) {
                lblErrorActual.Text = Properties.Resources.CambiarContrasena_ErrorActualIncorrecta;
                lblErrorActual.Visibility = Visibility.Visible;
                return;
            }

            panelPaso1.Visibility = Visibility.Collapsed;
            panelPaso2.Visibility = Visibility.Visible;
        }

        private void txtNueva_PasswordChanged(object sender, RoutedEventArgs e) {
            string c = txtNueva.Password;
            chk8Caracteres.IsChecked = c.Length >= 8;
            chkMayuscula.IsChecked = c.Any(x => char.IsUpper(x));
            chkMinuscula.IsChecked = c.Any(x => char.IsLower(x));
            chkNumero.IsChecked = c.Any(x => char.IsDigit(x));
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e) {
            lblErrorNueva.Visibility = Visibility.Collapsed;
            string nueva = txtNueva.Password;
            string confirmar = txtConfirmar.Password;

            if (!ContrasenaCumpleRequisitos(nueva)) {
                lblErrorNueva.Text = Properties.Resources.EditarPerfil_ErrorContrasenaRequisitos;
                lblErrorNueva.Visibility = Visibility.Visible;
                return;
            }

            if (nueva != confirmar) {
                lblErrorNueva.Text = Properties.Resources.RegistrarCuenta_ErrorContrasenasNoCoinciden;
                lblErrorNueva.Visibility = Visibility.Visible;
                return;
            }

            bool cambiada = false;
            if (!ManejadorErrores.Ejecutar(() => { cambiada = Conexiones.Usuario().CambiarContrasena(SesionActual.IdUsuario, nueva); })) {
                return;
            }

            if (cambiada) {
                MessageBox.Show(
                    Properties.Resources.CambiarContrasena_ExitoMensaje,
                    Properties.Resources.CambiarContrasena_ExitoTitulo,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private bool ContrasenaCumpleRequisitos(string c) {
            return c.Length >= 8 && c.Any(x => char.IsUpper(x)) && c.Any(x => char.IsLower(x)) && c.Any(x => char.IsDigit(x));
        }
    }
}