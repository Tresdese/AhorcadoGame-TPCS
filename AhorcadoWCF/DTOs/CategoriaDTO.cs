using System.Runtime.Serialization;

namespace AhorcadoWCF
{
    [DataContract]
    public class CategoriaDTO
    {
        [DataMember] public int IdCategoria { get; set; }
        [DataMember] public string Nombre { get; set; }
        [DataMember] public string Idioma { get; set; }
    }
}
