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

            var actual = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive) ?? Application.Current.MainWindow;

            if (actual == null) return;

            var nueva = (Window)Activator.CreateInstance(actual.GetType());
            Application.Current.MainWindow = nueva;
            nueva.Show();
            actual.Close();
        }
    }
}
