using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ClienteAhorcado {
    internal class GestorIdioma {
        public static void Aplicar(string idioma) {
            var cultura = new CultureInfo(idioma);
            Thread.CurrentThread.CurrentUICulture = cultura;
            Thread.CurrentThread.CurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            SesionActual.Idioma = idioma;
        }

        public static void Cambiar(string idioma) {
            Aplicar(idioma);

            var mainWindow = Application.Current.MainWindow as MainWindow;
            var frame = mainWindow?.MainFrame;
            var paginaActual = frame?.Content;
            if (paginaActual == null) return;

            try
            {
                var nueva = (System.Windows.Controls.Page)Activator.CreateInstance(paginaActual.GetType());
                frame.Navigate(nueva);
            }
            catch { }
        }
    }
}
