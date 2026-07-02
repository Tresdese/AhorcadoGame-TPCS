using System;
using System.ServiceModel;
using System.Windows;

namespace ClienteAhorcado
{
    public static class ManejadorErrores
    {
        public static bool Ejecutar(Action accion)
        {
            bool resultado = false;
            try
            {
                accion();
                resultado = true;
            }
            catch (EndpointNotFoundException) { MostrarEX01(); resultado = false; }
            catch (CommunicationException) { MostrarEX01(); resultado = false; }
            catch (TimeoutException) { MostrarEX01(); resultado = false; }
            return resultado;
        }

        public static T Ejecutar<T>(Func<T> funcion, T valorPorDefecto = default)
        {

            T resultado = default;
            try
            {
                return funcion();
            }
            catch (EndpointNotFoundException) { MostrarEX01(); resultado = valorPorDefecto; }
            catch (CommunicationException) { MostrarEX01(); resultado = valorPorDefecto; }
            catch (TimeoutException) { MostrarEX01(); resultado = valorPorDefecto; }
            return resultado;
        }

        private static void MostrarEX01()
        {
            MessageBox.Show(
                Properties.Resources.Partidas_ErrorConexion,
                Properties.Resources.Comun_Error,
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
