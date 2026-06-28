using AhorcadoWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class VentanaRegistrarCuenta : Window {
        public VentanaRegistrarCuenta() {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaBienvenida ventanaBienvenida = new VentanaBienvenida();
            ventanaBienvenida.Show();
            this.Close();
        }

        private void txtContrasena_PasswordChanged(object sender, RoutedEventArgs e) {
            string contrasena = txtContrasena.Password;

            chk8Caracteres.IsChecked = contrasena.Length >= 8;
            chkMayuscula.IsChecked = contrasena.Any(c => char.IsUpper(c));
            chkMinuscula.IsChecked = contrasena.Any(c => char.IsLower(c));
            chkNumero.IsChecked = contrasena.Any(c => char.IsDigit(c));
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e) {
            lblErrorNombre.Visibility = Visibility.Collapsed;
            lblErrorCorreo.Visibility = Visibility.Collapsed;
            lblErrorFecha.Visibility = Visibility.Collapsed;
            lblErrorCelular.Visibility = Visibility.Collapsed;
            lblErrorContrasena.Visibility = Visibility.Collapsed;

            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string celular = txtCelular.Text.Trim();
            string contrasena = txtContrasena.Password;
            string confirmar = txtConfirmarContrasena.Password;
            DateTime? fechaNacimiento = dpFechaNacimiento.SelectedDate;

            bool hayError = false;

            if (string.IsNullOrWhiteSpace(nombre)) {
                lblErrorNombre.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (string.IsNullOrWhiteSpace(correo) || !CorreoTieneFormatoValido(correo)) {
                lblErrorCorreo.Text = "Ingresa un correo electrónico válido.";
                lblErrorCorreo.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (string.IsNullOrWhiteSpace(celular) || !CelularEsValido(celular)) {
                lblErrorCelular.Text = "Ingresa un número de celular válido (10 a 15 dígitos).";
                lblErrorCelular.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (fechaNacimiento == null) {
                lblErrorFecha.Text = "Selecciona tu fecha de nacimiento.";
                lblErrorFecha.Visibility = Visibility.Visible;
                hayError = true;
            } else if (!TieneAlMenos10Anios(fechaNacimiento.Value)) {
                lblErrorFecha.Text = "Debes tener al menos 10 años cumplidos para registrarte.";
                lblErrorFecha.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (!ContrasenaCumpleRequisitos(contrasena)) {
                lblErrorContrasena.Text = "La contraseña no cumple los requisitos.";
                lblErrorContrasena.Visibility = Visibility.Visible;
                hayError = true;
            } else if (contrasena != confirmar) {
                lblErrorContrasena.Text = "Las contraseñas no coinciden.";
                lblErrorContrasena.Visibility = Visibility.Visible;
                hayError = true;
            }

            if (hayError) {
                return;
            }

            bool correoExiste = false;
            if (!ManejadorErrores.Ejecutar(() => { correoExiste = Conexiones.Autenticacion().VerificarCorreoExistente(correo); })) {
                return;
            }

            if (correoExiste) {
                lblErrorCorreo.Text = "Este correo ya tiene una cuenta asociada.";
                lblErrorCorreo.Visibility = Visibility.Visible;
                return;
            }

            UsuarioDTO nuevoUsuario = new UsuarioDTO {
                Nombre = nombre,
                Correo = correo,
                Contrasena = contrasena,
                FechaNacimiento = fechaNacimiento.Value,
                Telefono = celular
            };

            bool registrado = false;
            if (!ManejadorErrores.Ejecutar(() => { registrado = Conexiones.Autenticacion().RegistrarCuenta(nuevoUsuario); })) {
                return;
            }

            if (registrado) {
                MessageBox.Show("¡Cuenta creada con éxito! Ahora puedes iniciar sesión.", "Registro exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                VentanaIniciarSesion ventanaIniciarSesion = new VentanaIniciarSesion();
                ventanaIniciarSesion.Show();
                this.Close();
            }
        }

        private bool CorreoTieneFormatoValido(string correo) {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool CelularEsValido(string celular) {
            string soloDigitos = celular.Replace("+", "").Replace(" ", "").Replace("-", "");
            return soloDigitos.All(c => char.IsDigit(c)) && soloDigitos.Length >= 10 && soloDigitos.Length <= 15;
        }

        private bool TieneAlMenos10Anios(DateTime fechaNacimiento) {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) {
                edad--;
            }
            return edad >= 10;
        }

        private bool ContrasenaCumpleRequisitos(string contrasena) {
            return contrasena.Length >= 8
                && contrasena.Any(c => char.IsUpper(c))
                && contrasena.Any(c => char.IsLower(c))
                && contrasena.Any(c => char.IsDigit(c));
        }
    }
}
