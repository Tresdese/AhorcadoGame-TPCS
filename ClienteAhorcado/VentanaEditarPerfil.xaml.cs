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
    public partial class VentanaEditarPerfil : Window {
        public VentanaEditarPerfil() {
            InitializeComponent();
            btnIdioma.Content = SesionActual.Idioma == "es" ? "🌐 ES" : "🌐 EN";
            CargarDatosActuales();
        }

        private void btnIdioma_Click(object sender, RoutedEventArgs e) {
            string nuevo = SesionActual.Idioma == "es" ? "en" : "es";
            GestorIdioma.Cambiar(nuevo);
        }

        private void CargarDatosActuales() {
            UsuarioDTO usuario = null;
            if (!ManejadorErrores.Ejecutar(() => { usuario = Conexiones.Usuario().ObtenerPerfil(SesionActual.IdUsuario); })) {
                new VentanaPerfil().Show();
                Close();
                return;
            }

            if (usuario == null) {
                new VentanaPerfil().Show();
                Close();
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
            ventanaPerfil.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            VentanaPerfil ventanaPerfil = new VentanaPerfil();
            ventanaPerfil.Show();
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e) {
            lblErrorNombre.Visibility = Visibility.Collapsed;
            lblErrorFecha.Visibility = Visibility.Collapsed;
            lblErrorCelular.Visibility = Visibility.Collapsed;
            lblErrorContrasena.Visibility = Visibility.Collapsed;

            string nombre = txtNombre.Text.Trim();
            DateTime? fechaNacimiento = dpFechaNacimiento.SelectedDate;
            string celular = txtCelular.Text.Trim();
            string nuevaContrasena = txtContrasena.Password;

            bool hayError = false;

            if (string.IsNullOrWhiteSpace(nombre)) {
                lblErrorNombre.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (fechaNacimiento == null) {
                lblErrorFecha.Text = Properties.Resources.RegistrarCuenta_ErrorFechaVacia;
                lblErrorFecha.Visibility = Visibility.Visible;
                hayError = true;
            } else if (!TieneAlMenos10Anios(fechaNacimiento.Value)) {
                lblErrorFecha.Text = Properties.Resources.RegistrarCuenta_ErrorEdadMinima;
                lblErrorFecha.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (string.IsNullOrWhiteSpace(celular) || !CelularEsValido(celular)) {
                lblErrorCelular.Text = Properties.Resources.RegistrarCuenta_ErrorCelularInvalido;
                lblErrorCelular.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (!string.IsNullOrWhiteSpace(nuevaContrasena) && !ContrasenaCumpleRequisitos(nuevaContrasena)) {
                lblErrorContrasena.Text = Properties.Resources.EditarPerfil_ErrorContrasenaRequisitos;
                lblErrorContrasena.Visibility = Visibility.Visible;
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

            if (!string.IsNullOrWhiteSpace(nuevaContrasena)) {
                bool contrasenaCambiada = false;
                if (!ManejadorErrores.Ejecutar(() => { contrasenaCambiada = Conexiones.Usuario().CambiarContrasena(SesionActual.IdUsuario, nuevaContrasena); })) {
                    return;
                }
            }

            if (actualizado) {
                SesionActual.Nombre = nombre;
                MessageBox.Show(
                    Properties.Resources.EditarPerfil_ExitoMensaje,
                    Properties.Resources.EditarPerfil_ExitoTitulo,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                VentanaPerfil ventanaPerfil = new VentanaPerfil();
                ventanaPerfil.Show();
                this.Close();
            }
        }

        private bool TieneAlMenos10Anios(DateTime fechaNacimiento) {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) {
                edad--;
            }
            return edad >= 10;
        }

        private bool CelularEsValido(string celular) {
            string soloDigitos = celular.Replace("+", "").Replace(" ", "").Replace("-", "");
            return soloDigitos.All(c => char.IsDigit(c)) && soloDigitos.Length >= 10 && soloDigitos.Length <= 15;
        }

        private bool ContrasenaCumpleRequisitos(string contrasena) {
            return contrasena.Length >= 8
                && contrasena.Any(c => char.IsUpper(c))
                && contrasena.Any(c => char.IsLower(c))
                && contrasena.Any(c => char.IsDigit(c));
        }
    }
}
