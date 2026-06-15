using System;
using System.ServiceModel;
using System.Windows;

namespace ClienteAhorcado
{
    /// <summary>
    /// Manejo centralizado de la excepcion EX01 "Sin conexion a la base de datos",
    /// presente en casi todos los casos de uso. Uselo para envolver cualquier
    /// llamada a un servicio WCF.
    /// </summary>
    public static class ManejadorErrores
    {
        /// <summary>
        /// Ejecuta una accion sin valor de retorno. Devuelve true si se ejecuto;
        /// false si hubo fallo de conexion (ya mostro el aviso EX01).
        /// </summary>
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

        /// <summary>
        /// Ejecuta una funcion con valor de retorno. Si hay fallo de conexion
        /// muestra EX01 y devuelve el valor por defecto indicado.
        /// </summary>
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
        }
    }
}
