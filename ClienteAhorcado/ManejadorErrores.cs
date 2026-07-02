using System;
using System.ServiceModel;
using System.Windows;

namespace ClienteAhorcado
{
    public static class ManejadorErrores
    {
        public static bool Ejecutar(Action accion)
        {
            try
            {
                accion();
                return true;
            }
            catch (EndpointNotFoundException) { MostrarEX01(); return false; }
            catch (CommunicationException) { MostrarEX01(); return false; }
            catch (TimeoutException) { MostrarEX01(); return false; }
        }

        public static T Ejecutar<T>(Func<T> funcion, T valorPorDefecto = default)
        {
            try
            {
                return funcion();
            }
            catch (EndpointNotFoundException) { MostrarEX01(); return valorPorDefecto; }
            catch (CommunicationException) { MostrarEX01(); return valorPorDefecto; }
            catch (TimeoutException) { MostrarEX01(); return valorPorDefecto; }
        }

        private static void MostrarEX01()
        {
            MessageBox.Show(
                "Error de conexión con base de datos, inténtelo más tarde.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            SesionActual.Cerrar();
            var ventanaLogin = new VentanaIniciarSesion();
            Navegacion.Ir(ventanaLogin);
        }
    }
}
