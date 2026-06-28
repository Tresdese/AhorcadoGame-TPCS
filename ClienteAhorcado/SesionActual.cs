namespace ClienteAhorcado
{
   
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
