using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AhorcadoWCF
{
   
    [DataContract]
    public class PuntajeHistorialDTO
    {
        [DataMember] public string Fecha { get; set; }
        [DataMember] public string Palabra { get; set; }
        [DataMember] public string NombreRival { get; set; }
        [DataMember] public int Puntos { get; set; }
        [DataMember] public string TipoPuntaje { get; set; }
    }
}