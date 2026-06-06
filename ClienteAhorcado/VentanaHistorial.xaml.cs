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
    /// <summary>
    /// Lógica de interacción para VentanaHistorial.xaml
    /// </summary>
    public partial class VentanaHistorial : Window {
        public VentanaHistorial() {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e) {
            VentanaPartidas ventanaPartidas = new VentanaPartidas();
            ventanaPartidas.Show();
            this.Close();
        }

        private void btnGanadas_Click(object sender, RoutedEventArgs e) {
            btnGanadas.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0078D4"));
            btnGanadas.Foreground = new SolidColorBrush(Colors.White);
            btnGanadas.BorderThickness = new Thickness(0);
            btnRival.Background = new SolidColorBrush(Colors.White);
            btnRival.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnRival.BorderThickness = new Thickness(1);
            btnPenalizaciones.Background = new SolidColorBrush(Colors.White);
            btnPenalizaciones.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnPenalizaciones.BorderThickness = new Thickness(1);
            colPalabra.Text = "PALABRA ADIVINADA";
            colRival.Text = "RIVAL VENCIDO";
        }

        private void btnRival_Click(object sender, RoutedEventArgs e) {
            btnRival.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0078D4"));
            btnRival.Foreground = new SolidColorBrush(Colors.White);
            btnRival.BorderThickness = new Thickness(0);
            btnGanadas.Background = new SolidColorBrush(Colors.White);
            btnGanadas.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnGanadas.BorderThickness = new Thickness(1);
            btnPenalizaciones.Background = new SolidColorBrush(Colors.White);
            btnPenalizaciones.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnPenalizaciones.BorderThickness = new Thickness(1);
            colPalabra.Text = "PALABRA NO ADIVINADA";
            colRival.Text = "RIVAL VENCIDO";
        }

        private void btnPenalizaciones_Click(object sender, RoutedEventArgs e) {
            btnPenalizaciones.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0078D4"));
            btnPenalizaciones.Foreground = new SolidColorBrush(Colors.White);
            btnPenalizaciones.BorderThickness = new Thickness(0);
            btnGanadas.Background = new SolidColorBrush(Colors.White);
            btnGanadas.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnGanadas.BorderThickness = new Thickness(1);
            btnRival.Background = new SolidColorBrush(Colors.White);
            btnRival.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            btnRival.BorderThickness = new Thickness(1);
            colPalabra.Text = "PALABRA QUE SE JUGABA";
            colRival.Text = "RIVAL";
        }
    }
}
