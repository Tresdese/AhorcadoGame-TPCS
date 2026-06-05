using System.Runtime.Serialization;

namespace AhorcadoWCF
{
    [DataContract]
    public class PalabraDTO
    {
        [DataMember] public int IdPalabra { get; set; }
        [DataMember] public string Texto { get; set; }
        [DataMember] public string Descripcion { get; set; }
        [DataMember] public int IdCategoria { get; set; }
        [DataMember] public string Categoria { get; set; }
    }
}
