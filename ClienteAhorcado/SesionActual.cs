namespace ClienteAhorcado
{
    /// <summary>
    /// Estado de la sesion activa, compartido entre todas las ventanas.
    /// Reemplaza el paso manual de idUsuario por constructores.
    /// Lo llenan A (al iniciar sesion) y lo consultan todos.
    /// </summary>
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Correo { get; set; }
        public static string Idioma { get; set; } = "es";
        public static int IdPartida { get; set; }

        public static bool HaySesion => IdUsuario > 0;

        public static void Cerrar()
        {
            IdUsuario = 0;
            Nombre = null;
            Correo = null;
        }
    }
}
