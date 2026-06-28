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

namespace ClienteAhorcado
{
   
    public partial class DialogoGanadorCreador : Window
    {
        private readonly int _idPartida;
        private readonly string _nombreRival;
        private readonly string _palabra;
        private readonly string _categoria;
        private readonly int _puntosObtenidos;
        private readonly int _puntajeGlobal;

        public DialogoGanadorCreador(
            int idPartida,
            string nombreRival,
            string palabra,
            string categoria,
            int puntosObtenidos,
            int puntajeGlobal)
        {
            InitializeComponent();

            _idPartida = idPartida;
            _nombreRival = nombreRival;
            _palabra = palabra;
            _categoria = categoria;
            _puntosObtenidos = puntosObtenidos;
            _puntajeGlobal = puntajeGlobal;

            Loaded += DialogoGanadorCreador_Loaded;
        }

        private void DialogoGanadorCreador_Loaded(object sender, RoutedEventArgs e)
        {
            txtPalabra.Text = _palabra;
            txtRival.Text = _nombreRival;
            txtCategoria.Text = _categoria;
            txtPuntosObtenidos.Text = $"+{_puntosObtenidos} pts";
            txtPuntajeGlobal.Text = $"{_puntajeGlobal} pts";
            txtPreguntaRival.Text = _nombreRival;
        }

        private void btnLobby_Click(object sender, RoutedEventArgs e)
        {
            new VentanaPartidas().Show();
            Close();
        }

        private void btnJugarDeNuevo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cliente = Conexiones.Partida();
                bool reabierta = cliente.ReabrirPartida(_idPartida);

                if (!reabierta)
                {
                    MessageBox.Show(
                        "No se pudo reabrir la partida. Regresando al lobby.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    new VentanaPartidas().Show();
                    Close();
                    return;
                }

                new VentanaEsperandoRival().Show();
                Close();
            }
            catch
            {
                MessageBox.Show(
                    "Error de conexión con base de datos, inténtelo más tarde.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
