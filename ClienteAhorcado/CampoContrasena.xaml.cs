using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ClienteAhorcado {
    public partial class CampoContrasena : UserControl {
        private bool _mostrando = false;
        private bool _sincronizando = false;

        public event RoutedEventHandler PasswordChanged;

        public CampoContrasena() {
            InitializeComponent();
        }

        public string Password {
            get { return _mostrando ? txtVisible.Text : txtOculto.Password; }
        }

        private void txtOculto_PasswordChanged(object sender, RoutedEventArgs e) {
            if (_sincronizando) return;
            _sincronizando = true;
            txtVisible.Text = txtOculto.Password;
            _sincronizando = false;
            PasswordChanged?.Invoke(this, e);
        }

        private void txtVisible_TextChanged(object sender, TextChangedEventArgs e) {
            if (_sincronizando) return;
            _sincronizando = true;
            txtOculto.Password = txtVisible.Text;
            _sincronizando = false;
            PasswordChanged?.Invoke(this, e);
        }

        private void btnOjito_Click(object sender, RoutedEventArgs e) {
            _mostrando = !_mostrando;
            if (_mostrando) {
                txtVisible.Visibility = Visibility.Visible;
                txtOculto.Visibility = Visibility.Collapsed;
                imgOjito.Source = new BitmapImage(new Uri("/Recursos/ocultar_contrasena.png", UriKind.Relative));
            } else {
                txtOculto.Visibility = Visibility.Visible;
                txtVisible.Visibility = Visibility.Collapsed;
                imgOjito.Source = new BitmapImage(new Uri("/Recursos/ver_contrasena.png", UriKind.Relative));
            }
        }
    }
}