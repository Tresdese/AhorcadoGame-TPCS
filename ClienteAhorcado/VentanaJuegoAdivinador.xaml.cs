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
    public partial class VentanaJuegoAdivinador : Page, IJuegoCallback
    {
        private readonly int _idPartida;
        private readonly string _nombreCreador;
        private IJuegoCallbackService _canal;

        private int _intentosRestantes = 6;
        private string[] _letrasOcultas;
        private readonly List<TextBlock> casillas = new List<TextBlock>();

        public VentanaJuegoAdivinador(int idPartida, string nombreCreador)
        {
            InitializeComponent();
            _idPartida = idPartida;
            _nombreCreador = nombreCreador;
            Loaded += VentanaJuegoAdivinador_Loaded;
            Unloaded += (s, e) => CerrarCanal();
        }

        private void CerrarCanal()
        {
            var com = _canal as ICommunicationObject;
            if (com == null) return;
            try { com.Abort(); } catch { }
        }

        private void VentanaJuegoAdivinador_Loaded(object sender, RoutedEventArgs e)
        {
            lblRival.Text = string.Format(Properties.Resources.Juego_VsRival, _nombreCreador);

            casillas.Clear();
            foreach (var name in new[] { "l1", "l2", "l3", "l4", "l5", "l6", "l7", "l8" })
            {
                var tb = FindName(name) as TextBlock;
                if (tb != null) casillas.Add(tb);
            }
            foreach (var c in casillas)
                c.Text = "";

            lblIntentos.Text = Properties.Resources.Juego_EsperandoPalabra;

            _canal = Conexiones.Juego(new InstanceContext(this));
            if (!ManejadorErrores.Ejecutar(() => _canal.UnirseASalaDePartida(_idPartida, SesionActual.IdUsuario)))
            {
                Navegacion.Ir(new VentanaPartidas());
            }
        }

        public void IniciarJuego(int longitud, string descripcion, string categoria)
        {
            Dispatcher.Invoke(() =>
            {
                _intentosRestantes = 6;
                _letrasOcultas = new string[longitud];
                for (int i = 0; i < longitud; i++)
                    _letrasOcultas[i] = "_";

                lblCategoria.Text = categoria;
                lblDescripcion.Text = descripcion;

                for (int i = 0; i < casillas.Count; i++)
                    if (casillas[i].Parent is UIElement borde)
                        borde.Visibility = i < longitud ? Visibility.Visible : Visibility.Collapsed;

                MostrarAhorcado(0);
                ActualizarCasillas();
                lblIntentos.Text = string.Format(Properties.Resources.Juego_IntentosRestantes, _intentosRestantes);
            });
        }

        private void btnLetra_Click(object sender, RoutedEventArgs e)
        {
            var boton = sender as Button;
            if (boton == null) return;

            char letra = boton.Content.ToString()[0];
            boton.IsEnabled = false;

            ManejadorErrores.Ejecutar(() => _canal.EnviarLetra(_idPartida, SesionActual.IdUsuario, letra));
        }

        public void LetraIngresada(char letra, bool acerto, List<int> posiciones, int intentosRestantes)
        {
            Dispatcher.Invoke(() =>
            {
                _intentosRestantes = intentosRestantes;
                lblIntentos.Text = string.Format(Properties.Resources.Juego_IntentosRestantes, intentosRestantes);

                ColorearBotonLetra(letra, acerto);

                if (intentosRestantes == 0)
                {
                    foreach (var b in GetAllButtons())
                        if (b.Content != null && b.Content.ToString().Length == 1 && char.IsLetter(b.Content.ToString()[0]))
                            b.IsEnabled = false;
                }

                if (acerto)
                {
                    foreach (var pos in posiciones)
                    {
                        if (pos >= 0 && pos < _letrasOcultas.Length)
                            _letrasOcultas[pos] = letra.ToString();
                    }
                    ActualizarCasillas();
                }
                else
                {
                    MostrarAhorcado(6 - intentosRestantes);
                }
            });
        }

        private static readonly string[] FramesAhorcado =
        {
            "ahorcado_vacio", "ahorcado_primerFallido", "ahorcado_segundoFallido",
            "ahorcado_tercerFallido", "ahorcado_cuartoFallido", "ahorcado_quintoFallido",
            "ahorcado_sextoFallido"
        };

        private void MostrarAhorcado(int fallos)
        {
            if (fallos < 0) fallos = 0;
            if (fallos >= FramesAhorcado.Length) fallos = FramesAhorcado.Length - 1;
            imgAhorcado.Source = new BitmapImage(
                new Uri($"/Recursos/{FramesAhorcado[fallos]}.png", UriKind.Relative));
        }

        public void MensajeChatRecibido(string remitente, string mensaje) =>
            AgregarMensajeChat(remitente, mensaje);

        public void RivalAbandono(string nombreRival)
        {
            Dispatcher.Invoke(() =>
            {
                var dialogo = new DialogoRivalAbandono(_idPartida, nombreRival);
                dialogo.Owner = Window.GetWindow(this);
                dialogo.ShowDialog();
                Navegacion.Ir(new VentanaPartidas());
            });
        }

        public void PartidaFinalizada(string resultado, string palabra, int puntosObtenidos, int puntajeGlobal)
        {
            Dispatcher.Invoke(() =>
            {
                string categoria = "—";
                if (resultado.Contains("|"))
                {
                    var partes = resultado.Split('|');
                    resultado = partes[0];
                    categoria = partes[1];
                }

                if (resultado == "Ganaste")
                {
                    var dialogo = new DialogoGanadorAdivinador(
                        _idPartida, _nombreCreador, palabra, categoria, puntosObtenidos, puntajeGlobal);
                    dialogo.Owner = Window.GetWindow(this);
                    dialogo.ShowDialog();
                }
                else
                {
                    var dialogo = new DialogoPerdedorAdivinador(
                        _idPartida, _nombreCreador, palabra, categoria, puntajeGlobal);
                    dialogo.Owner = Window.GetWindow(this);
                    dialogo.ShowDialog();
                }

                Navegacion.Ir(new VentanaPartidas());
            });
        }

        public void PartidaCreada(PartidaDTO partida) { }
        public void PartidaRemovidaDelLobby(int idPartida) { }
        public void AdivinadorSeUnio(UsuarioDTO adivinador) { }
        public void PalabraSeleccionada(int longitud, string descripcion, string categoria) { }

        private void ActualizarCasillas()
        {
            for (int i = 0; i < casillas.Count && i < _letrasOcultas.Length; i++)
            {
                casillas[i].Text = _letrasOcultas[i] == "_" ? "" : _letrasOcultas[i];
                casillas[i].FontWeight = _letrasOcultas[i] == "_"
                    ? FontWeights.Normal
                    : FontWeights.Bold;
            }
        }

        private void ColorearBotonLetra(char letra, bool acerto)
        {
            foreach (var elemento in GetAllButtons())
            {
                if (elemento.Content?.ToString() == letra.ToString())
                {
                    elemento.Background = acerto
                        ? new SolidColorBrush(Color.FromRgb(46, 125, 50))
                        : new SolidColorBrush(Color.FromRgb(211, 47, 47));
                    elemento.Foreground = Brushes.White;
                    elemento.BorderThickness = new Thickness(0);
                    break;
                }
            }
        }

        private IEnumerable<Button> GetAllButtons()
        {
            return FindVisualChildren<Button>(this);
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T t) yield return t;
                foreach (var c in FindVisualChildren<T>(child))
                    yield return c;
            }
        }

        private void btnEnviarMensaje_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = txtMensaje.Text.Trim();
            if (string.IsNullOrEmpty(mensaje)) return;

            if (ManejadorErrores.Ejecutar(() => _canal.EnviarMensajeChat(_idPartida, SesionActual.IdUsuario, mensaje)))
            {
                AgregarMensajePropioChat(mensaje);
                txtMensaje.Clear();
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
            var dialogo = new DialogoAbandonarPartida(_idPartida);
            dialogo.Owner = Window.GetWindow(this);
            dialogo.ShowDialog();

            if (dialogo.Confirmo)
            {
                int puntajeActual = 0;
                try
                {
                    var clientePuntaje = Conexiones.Puntaje();
                    puntajeActual = clientePuntaje.ObtenerPuntajeGlobal(SesionActual.IdUsuario);
                }
                catch { }

                var penalizacion = new DialogoPenalizacion(puntajeActual, 3);
                penalizacion.Show();
                Navegacion.Ir(new VentanaPartidas());
            }
        }
    }
}
