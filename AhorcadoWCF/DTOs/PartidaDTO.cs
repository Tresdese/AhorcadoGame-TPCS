using System.Runtime.Serialization;

namespace AhorcadoWCF
{
    [DataContract]
    public class PartidaDTO
    {
        [DataMember] public int IdPartida { get; set; }
        [DataMember] public int IdJugadorCreador { get; set; }
        [DataMember] public int IdJugadorAdivinador { get; set; }
        [DataMember] public string Estado { get; set; }

        [DataMember] public string NombreCreador { get; set; }
        [DataMember] public string CorreoCreador { get; set; }
        [DataMember] public string FechaCreacion { get; set; }
    }
}
