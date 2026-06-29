using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AhorcadoWCF
{
    [DataContract]
    public class MovimientoDTO
    {
        [DataMember] public int IdMovimiento { get; set; }
        [DataMember] public int IdPartida { get; set; }
        [DataMember] public char Letra { get; set; }
        [DataMember] public bool Acerto { get; set; }
        [DataMember] public List<int> Posiciones { get; set; }
    }
}
