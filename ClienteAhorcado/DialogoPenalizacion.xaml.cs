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
    
    public partial class DialogoPenalizacion : Window
    {
        private readonly int _puntajeAnterior;
        private readonly int _puntajeNuevo;
        private readonly int _puntosPenalizacion;

        public DialogoPenalizacion(int puntajeAnterior, int puntosPenalizacion)
        {
            InitializeComponent();
            _puntajeAnterior = puntajeAnterior;
            _puntosPenalizacion = puntosPenalizacion;
            _puntajeNuevo = puntajeAnterior - puntosPenalizacion;

            Loaded += DialogoPenalizacion_Loaded;
        }

        private void DialogoPenalizacion_Loaded(object sender, RoutedEventArgs e)
        {
            txtPuntaje.Text = $"{_puntajeAnterior} pts → {_puntajeNuevo} pts";
        }

        
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            new VentanaPartidas().Show();
            Close();
        }
    }
}
