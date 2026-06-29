using System.Windows;

namespace ClienteAhorcado
{
    public partial class DialogoPerdedorCreador : Window
    {
        private readonly int _idPartida;
        private readonly string _nombreRival;
        private readonly string _palabra;
        private readonly string _categoria;
        private readonly int _puntajeGlobal;

        public DialogoPerdedorCreador(
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

            Loaded += DialogoPerdedorCreador_Loaded;
        }

        private void DialogoPerdedorCreador_Loaded(object sender, RoutedEventArgs e)
        {
            txtPalabra.Text = _palabra;
            txtRival.Text = _nombreRival;
            txtCategoria.Text = _categoria;
            txtPuntajeGlobal.Text = string.Format(Properties.Resources.Comun_FormatoPuntos, _puntajeGlobal);
        }

        private void btnLobby_Click(object sender, RoutedEventArgs e)
        {
            new VentanaPartidas().Show();
            Close();
        }

        private void btnJugarDeNuevo_Click(object sender, RoutedEventArgs e)
        {
            new VentanaEsperandoRival().Show();
            Close();
        }
    }
}
