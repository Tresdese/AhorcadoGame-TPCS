using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AhorcadoWCF;

namespace ClienteAhorcado
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class VentanaJuegoCreador : Window, IJuegoCallback
    {
        private readonly string _palabra;
        private IJuegoCallbackService _canal;
        private readonly List<TextBlock> casillas = new List<TextBlock>();

        public VentanaJuegoCreador(string palabra, string descripcion, string categoria)
        {
            InitializeComponent();
            _palabra = palabra ?? "";
            lblPalabra.Text = _palabra.ToUpper();
            lblCategoria.Text = categoria;
            lblDescripcion.Text = descripcion;

            Loaded += (s, e) => Iniciar();
            Closing += (s, e) => CerrarCanal();
        }

        private void Iniciar()
        {
            ConstruirCasillas();
            lblIntentos.Text = "6  intentos restantes";

            _canal = Conexiones.Juego(new InstanceContext(this));
            _canal.UnirseASalaDePartida(SesionActual.IdPartida, SesionActual.IdUsuario);
        }

        private void ConstruirCasillas()
        {
            panelCasillas.Children.Clear();
            casillas.Clear();
            foreach (var c in _palabra)
            {
                var tb = new TextBlock
                {
                    Text = "",
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                var borde = new Border
                {
                    BorderBrush = new SolidColorBrush(Color.FromRgb(0x33, 0x33, 0x33)),
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 45,
                    Height = 55,
                    Margin = new Thickness(3),
                    Child = tb
                };
                casillas.Add(tb);
                panelCasillas.Children.Add(borde);
            }
        }

        public void LetraIngresada(char letra, bool acerto, List<int> posiciones, int intentosRestantes)
        {
            Dispatcher.Invoke(() =>
            {
                lblIntentos.Text = $"{intentosRestantes}  intentos restantes";

                if (acerto)
                {
                    foreach (var pos in posiciones)
                        if (pos >= 0 && pos < casillas.Count)
                        {
                            casillas[pos].Text = char.ToUpper(letra).ToString();
                            casillas[pos].FontWeight = FontWeights.Bold;
                        }
                }
                else
                {
                    int fallos = 6 - intentosRestantes;
                    imgAhorcado.Source = new BitmapImage(
                        new Uri($"/Recursos/ahorcado_{fallos}.png", UriKind.Relative));
                    AgregarLetraIncorrecta(letra);
                }
            });
        }

        public void MensajeChatRecibido(string remitente, string mensaje) =>
            AgregarMensajeChat(remitente, mensaje);

        public void RivalAbandono(string nombreRival)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(
                    $"{nombreRival} abandonó la partida. Regresarás al lobby.",
                    "Rival abandonó",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                new VentanaPartidas().Show();
                Close();
            });
        }

        public void PartidaFinalizada(string resultado, string palabra, int puntosObtenidos, int puntajeGlobal)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(
                    $"Resultado: {resultado}\nPalabra: {palabra}\nPuntos obtenidos: {puntosObtenidos}\nPuntaje global: {puntajeGlobal}",
                    "Partida finalizada",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                new VentanaPartidas().Show();
                Close();
            });
        }

        public void PartidaCreada(PartidaDTO partida) { }
        public void PartidaRemovidaDelLobby(int idPartida) { }
        public void AdivinadorSeUnio(UsuarioDTO adivinador) { }
        public void PalabraSeleccionada(int longitud, string descripcion, string categoria) { }

        private void AgregarLetraIncorrecta(char letra)
        {
            panelIncorrectas.Children.Add(new Border
            {
                BorderBrush = Brushes.Red,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(8, 4, 8, 4),
                Margin = new Thickness(3, 0, 3, 0),
                Child = new TextBlock
                {
                    Text = char.ToUpper(letra).ToString(),
                    FontSize = 13,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Red
                }
            });
        }

        private void btnEnviarMensaje_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = txtMensaje.Text.Trim();
            if (string.IsNullOrEmpty(mensaje)) return;

            try
            {
                _canal.EnviarMensajeChat(SesionActual.IdPartida, SesionActual.IdUsuario, mensaje);
                AgregarMensajePropioChat(mensaje);
                txtMensaje.Clear();
            }
            catch
            {
                MessageBox.Show("No se pudo enviar el mensaje.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void AgregarMensajeChat(string remitente, string mensaje)
        {
            Dispatcher.Invoke(() =>
            {
                var burbuja = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                    CornerRadius = new CornerRadius(8),
                    Padding = new Thickness(10),
                    Margin = new Thickness(0, 0, 50, 8),
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                var sp = new StackPanel();
                sp.Children.Add(new TextBlock { Text = remitente, FontSize = 11, FontWeight = FontWeights.Bold, Foreground = Brushes.Gray, Margin = new Thickness(0, 0, 0, 3) });
                sp.Children.Add(new TextBlock { Text = mensaje, FontSize = 13, TextWrapping = TextWrapping.Wrap });
                burbuja.Child = sp;
                panelChat.Children.Add(burbuja);
            });
        }

        private void AgregarMensajePropioChat(string mensaje)
        {
            var burbuja = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0, 120, 212)),
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(10),
                Margin = new Thickness(50, 0, 0, 8),
                HorizontalAlignment = HorizontalAlignment.Right
            };
            burbuja.Child = new TextBlock { Text = mensaje, FontSize = 13, Foreground = Brushes.White, TextWrapping = TextWrapping.Wrap };
            panelChat.Children.Add(burbuja);
        }

        private void btnAbandonar_Click(object sender, RoutedEventArgs e)
        {
            var respuesta = MessageBox.Show(
                "¿Seguro que deseas abandonar la partida? Perderás puntos.",
                "Abandonar partida",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (respuesta == MessageBoxResult.Yes)
            {
                try
                {
                    _canal.NotificarAbandono(SesionActual.IdPartida, SesionActual.IdUsuario);
                }
                catch { }

                new VentanaPartidas().Show();
                Close();
            }
        }

        private void CerrarCanal()
        {
            var com = _canal as ICommunicationObject;
            if (com == null) return;
            try { com.Abort(); } catch { }
        }
    }
}
