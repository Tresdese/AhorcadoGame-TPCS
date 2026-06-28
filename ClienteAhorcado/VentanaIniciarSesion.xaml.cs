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
using AhorcadoWCF;

namespace ClienteAhorcado {
    public partial class VentanaIniciarSesion : Window {
        public VentanaIniciarSesion() {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaBienvenida ventanaBienvenida = new VentanaBienvenida();
            ventanaBienvenida.Show();
            this.Close();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e) {
            lblErrorCorreo.Visibility = Visibility.Collapsed;
            lblErrorContrasena.Visibility = Visibility.Collapsed;

            var bordeNormal = new SolidColorBrush(Color.FromRgb(0xCC, 0xCC, 0xCC));
            txtCorreo.BorderBrush = bordeNormal;
            txtContrasena.BorderBrush = bordeNormal;

            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Password;

            UsuarioDTO usuario = null;
            if (!ManejadorErrores.Ejecutar(() => { usuario = Conexiones.Autenticacion().IniciarSesion(correo, contrasena); })) {
                return;
            }

            if (usuario != null) {
                SesionActual.IdUsuario = usuario.IdUsuario;
                SesionActual.Nombre = usuario.Nombre;
                SesionActual.Correo = usuario.Correo;

                VentanaPartidas ventanaPartidas = new VentanaPartidas();
                ventanaPartidas.Show();
                this.Close();
                return;
            }

            bool correoExiste = false;
            if (!ManejadorErrores.Ejecutar(() => { correoExiste = Conexiones.Autenticacion().VerificarCorreoExistente(correo); })) {
                return;
            }

            if (correoExiste) {
                lblErrorContrasena.Visibility = Visibility.Visible;
                txtContrasena.BorderBrush = Brushes.Red;
            } else {
                lblErrorCorreo.Visibility = Visibility.Visible;
                txtCorreo.BorderBrush = Brushes.Red;
            }
        }
    }
}
