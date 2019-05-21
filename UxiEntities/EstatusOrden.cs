using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EstatusOrden
    {
        [JsonProperty(PropertyName = "IdEstatusOC")]
        public int IdEstatusOC { get; set; }
        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }
    }
}
