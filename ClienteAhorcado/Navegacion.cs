using System.Windows.Controls;
using System.Windows;

namespace ClienteAhorcado
{
    public static class Navegacion
    {
        private static Frame _frame;

        public static void Inicializar(Frame frame) => _frame = frame;

        public static void Ir(Page pagina) => _frame?.Navigate(pagina);
    }
}
