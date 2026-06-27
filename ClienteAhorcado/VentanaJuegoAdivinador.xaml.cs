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
    
    public partial class VentanaJuegoAdivinador : Window
    {
        private readonly int _idPartida;
        private readonly string _nombreCreador;

     
        private int _intentosRestantes = 6;
        private string[] _letrasOcultas;         
        private readonly List<TextBlock> casillas = new List<TextBlock>();

       
        private JuegoCallbackServiceClient clienteJuego;

        
        public VentanaJuegoAdivinador(int idPartida, string nombreCreador)
        {
            InitializeComponent();
            idPartida = idPartida;
            nombreCreador = nombreCreador;

            Loaded += VentanaJuegoAdivinador_Loaded;
            Closing += VentanaJuegoAdivinador_Closing;
        }

       
        private void VentanaJuegoAdivinador_Loaded(object sender, RoutedEventArgs e)
        {
           
            JuegoCallbackHandler.VentanaAdivinador = this;

           
            casillas.Clear();
            foreach (var name in new[] { "l1", "l2", "l3", "l4", "l5", "l6", "l7", "l8" })
            {
                var tb = FindName(name) as TextBlock;
                if (tb != null) casillas.Add(tb);
            }

           
            foreach (var c in casillas)
                c.Text = "";

           
            lblIntentos.Text = "Esperando que el creador elija la palabra...";
        }

       
        public void IniciarJuego(int longitud, string descripcion, string categoria)
        {
            Dispatcher.Invoke(() =>
            {
                _intentosRestantes = 6;
                _letrasOcultas = new string[longitud];
                for (int i = 0; i < longitud; i++)
                    _letrasOcultas[i] = "_";

                ActualizarCasillas();
                lblIntentos.Text = $"{_intentosRestantes}  intentos restantes";

                
            });
        }

       
        private void btnLetra_Click(object sender, RoutedEventArgs e)
        {
            var boton = sender as Button;
            if (boton == null) return;

            char letra = boton.Content.ToString()[0];

           
            boton.IsEnabled = false;

            try
            {
                clienteJuego = new JuegoCallbackServiceClient(
                    new System.ServiceModel.InstanceContext(new JuegoCallbackHandler()));

                clienteJuego.EnviarLetra(_idPartida, SesionActual.IdUsuario, letra);
               
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

        
        public void ActualizarJuego(char letra, bool acerto, List<int> posiciones, int intentosRestantes)
        {
            Dispatcher.Invoke(() =>
            {
                _intentosRestantes = intentosRestantes;
                lblIntentos.Text = $"{intentosRestantes}  intentos restantes";

               
                ColorearBotonLetra(letra, acerto);

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
                   
                    int fallos = 6 - intentosRestantes;
                    imgAhorcado.Source = new System.Windows.Media.Imaging.BitmapImage(
                        new System.Uri($"/Recursos/ahorcado_{fallos}.png", System.UriKind.Relative));
                }
            });
        }

       
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

            try
            {
                clienteJuego = new JuegoCallbackServiceClient(
                    new System.ServiceModel.InstanceContext(new JuegoCallbackHandler()));
                clienteJuego.EnviarMensajeChat(_idPartida, SesionActual.IdUsuario, mensaje);

                
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
                    clienteJuego = new JuegoCallbackServiceClient(
                        new System.ServiceModel.InstanceContext(new JuegoCallbackHandler()));
                    clienteJuego.NotificarAbandono(_idPartida, SesionActual.IdUsuario);
                }
                catch {  }

                JuegoCallbackHandler.VentanaAdivinador = null;

                var ventanaPartidas = new VentanaPartidas();
                ventanaPartidas.Show();
                Close();
            }
        }

       
        public void NotificarRivalAbandono(string nombreRival)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(
                    $"{nombreRival} abandonó la partida. Regresarás al lobby.",
                    "Rival abandonó",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                JuegoCallbackHandler.VentanaAdivinador = null;
                new VentanaPartidas().Show();
                Close();
            });
        }

       
        public void MostrarResultadoFinal(string resultado, string palabra, int puntosObtenidos, int puntajeGlobal)
        {
            Dispatcher.Invoke(() =>
            {
                
                MessageBox.Show(
                    $"Resultado: {resultado}\nPalabra: {palabra}\nPuntos obtenidos: {puntosObtenidos}\nPuntaje global: {puntajeGlobal}",
                    "Partida finalizada",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                JuegoCallbackHandler.VentanaAdivinador = null;
                new VentanaPartidas().Show();
                Close();
            });
        }

       
        private void VentanaJuegoAdivinador_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            JuegoCallbackHandler.VentanaAdivinador = null;
        }
    }
}
