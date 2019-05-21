using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Mensaje
    {     
        [JsonProperty(PropertyName = "IdUsuario")]
        public int IdUsuario { get; set; }
        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }
        [JsonProperty(PropertyName = "ApPaterno")]
        public string ApPaterno { get; set; }
        [JsonProperty(PropertyName = "Mensaje")]
        public string MensajeText { get; set; }
        [JsonProperty(PropertyName = "FechaAlta")]
        public DateTime FechaAlta { get; set; }
    }
}
