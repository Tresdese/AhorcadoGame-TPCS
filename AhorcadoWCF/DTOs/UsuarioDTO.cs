using System.Runtime.Serialization;

namespace AhorcadoWCF
{
    [DataContract]
    public class UsuarioDTO
    {
        [DataMember] public int IdUsuario { get; set; }
        [DataMember] public string Nombre { get; set; }
        [DataMember] public string Correo { get; set; }
        [DataMember] public string Contrasena { get; set; }
    }
}
