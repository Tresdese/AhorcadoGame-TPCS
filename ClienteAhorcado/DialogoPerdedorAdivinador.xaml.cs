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
   
    public partial class DialogoPerdedorAdivinador : Window
    {
        private readonly int _idPartida;
        private readonly string _nombreRival;
        private readonly string _palabra;
        private readonly string _categoria;
        private readonly int _puntajeGlobal;

        public DialogoPerdedorAdivinador(
            int idPartida,
            string nombreRival,
            string palabra,
            string categoria,
            int puntajeGlobal)
        {
            InitializeComponent();

            _idPartida = idPartida;
            _nombreRival = nombreRival;
            _palabra = palabra;
            _categoria = categoria;
            _puntajeGlobal = puntajeGlobal;

            Loaded += DialogoPerdedorAdivinador_Loaded;
        }

        private void DialogoPerdedorAdivinador_Loaded(object sender, RoutedEventArgs e)
        {
            txtPalabra.Text = _palabra;
            txtRival.Text = _nombreRival;
            txtCategoria.Text = _categoria;
            txtPuntosObtenidos.Text = "0 pts";
            txtPuntajeGlobal.Text = $"{_puntajeGlobal} pts";
            txtPreguntaRival.Text = _nombreRival;
        }

        private void btnLobby_Click(object sender, RoutedEventArgs e)
        {
            new VentanaPartidas().Show();
            Close();
        }
    }
}
