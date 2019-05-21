using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class TiposMovimientos
    {
        [JsonProperty(PropertyName = "IDTipoMovimiento")]
        public int IDTipoMovimiento { get; set; }
        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }
    }
}
