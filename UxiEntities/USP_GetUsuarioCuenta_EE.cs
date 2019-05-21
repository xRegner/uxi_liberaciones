using System;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class USP_GetUsuarioCuenta_EE
    {
        [JsonProperty(PropertyName = "IdRol")]
        public int IdRol { get; set; }
        [JsonProperty(PropertyName = "IdUsuario")]
        public int IdUsuario { get; set; }
        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }
        [JsonProperty(PropertyName = "ApPaterno")]
        public string ApPaterno { get; set; }
        [JsonProperty(PropertyName = "ApMaterno")]
        public string ApMaterno { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "Telefono")]
        public string Telefono { get; set; }
        [JsonProperty(PropertyName = "Activo")]
        public bool Activo { get; set; }
        [JsonProperty(PropertyName = "TipoCliente")]
        public Nullable<int> TipoCliente { get; set; }
        [JsonProperty(PropertyName = "saldoafavor")]
        public Nullable<decimal> saldoafavor { get; set; }
        [JsonProperty(PropertyName = "VerTarifas")]
        public bool? VerTarifas { get; set; }
    }
}
