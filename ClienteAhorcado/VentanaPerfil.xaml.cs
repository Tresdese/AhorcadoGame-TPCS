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
    public partial class VentanaPerfil : Window {
        public VentanaPerfil() {
            InitializeComponent();
            CargarPerfil();
        }

        private void CargarPerfil() {
            UsuarioDTO usuario = null;
            if (!ManejadorErrores.Ejecutar(() => { usuario = Conexiones.Usuario().ObtenerPerfil(SesionActual.IdUsuario); })) {
                return;
            }

            if (usuario == null) {
                return;
            }

            txtNombre.Text = usuario.Nombre;
            txtCorreo.Text = usuario.Correo;
            txtCelular.Text = usuario.Telefono;
            txtFechaNacimiento.Text = usuario.FechaNacimiento.ToString("dd/MM/yyyy");

            lblNombreEncabezado.Text = usuario.Nombre;
            lblCorreoEncabezado.Text = usuario.Correo;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaPartidas ventanaPartidas = new VentanaPartidas();
            ventanaPartidas.Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e) {
            VentanaEditarPerfil ventanaEditarPerfil = new VentanaEditarPerfil();
            ventanaEditarPerfil.Show();
            this.Close();
        }
    }
}
