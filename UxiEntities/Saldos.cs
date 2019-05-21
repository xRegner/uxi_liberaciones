using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Saldos
    {
        [JsonProperty(PropertyName = "IdHistorial")]
        public int IdHistorial { get; set; }
        [JsonProperty(PropertyName = "IdUsuario")]
        public int IdUsuario { get; set; }
        [JsonProperty(PropertyName = "Fecha")]
        public System.DateTime Fecha { get; set; }
        [JsonProperty(PropertyName = "FechaFF")]
        public string FechaFF { get; set; }
        [JsonProperty(PropertyName = "UUM")]
        public int UUM { get; set; }
        [JsonProperty(PropertyName = "Monto_Entrada")]
        public decimal Monto_Entrada { get; set; }
        [JsonProperty(PropertyName = "Monto_Salida")]
        public decimal Monto_Salida { get; set; }
        [JsonProperty(PropertyName = "TipoMovimiento")]
        public TiposMovimientos TipoMovimiento { get; set; }
    }
}
