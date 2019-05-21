using System;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CuentaUsuario
    {
        [JsonProperty(PropertyName = "IdCuentaUsuario")]
        public int IdCuentaUsuario { get; set; }
        [JsonProperty(PropertyName = "IdUsuario")]
        public int IdUsuario { get; set; }
        [JsonProperty(PropertyName = "SaldoAFavor")]
        public Nullable<decimal> SaldoAFavor { get; set; }
        [JsonProperty(PropertyName = "UUM")]
        public Nullable<int> UUM { get; set; }
        [JsonProperty(PropertyName = "FUM")]
        public Nullable<System.DateTime> FUM { get; set; }
        [JsonProperty(PropertyName = "Activo")]
        public bool Activo { get; set; }
    }
}
