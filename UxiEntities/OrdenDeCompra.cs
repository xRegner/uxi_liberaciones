using System;
using Newtonsoft.Json;
namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OrdenDeCompra
    {
        [JsonProperty(PropertyName = "IdOrdenCompra")]
        public int IdOrdenCompra { get; set; }
        //[JsonProperty(PropertyName = "IdUsuario")]
        //public int IdUsuario { get; set; }
        [JsonProperty(PropertyName = "IdZona")]
        public Nullable<int> IdZona { get; set; }
        [JsonProperty(PropertyName = "ReferenciaBancaria")]
        public string ReferenciaBancaria { get; set; }
        [JsonProperty(PropertyName = "Total")]
        public Nullable<decimal> Total { get; set; }
        [JsonProperty(PropertyName = "IdEstatusOC")]
        public int IdEstatusOC { get; set; }
        [JsonProperty(PropertyName = "FechaOrden")]
        public System.DateTime FechaOrden { get; set; }
        [JsonProperty(PropertyName = "FechaPagoMax")]
        public System.DateTime FechaPagoMax { get; set; }
        [JsonProperty(PropertyName = "FUM")]
        public Nullable<System.DateTime> FUM { get; set; }
        [JsonProperty(PropertyName = "UUM")]
        public Nullable<int> UUM { get; set; }
        //[JsonProperty(PropertyName = "NombreUsuario")]
        //public string Nombre { get; set; }
        //[JsonProperty(PropertyName = "ApPaternoUsuario")]
        //public string ApPaterno { get; set; }
        //[JsonProperty(PropertyName = "ApMaternoUsuario")]
        //public string ApMaterno { get; set; }
        //[JsonProperty(PropertyName = "Email")]
        //public string Email { get; set; }
        [JsonProperty(PropertyName = "EstatusDesc")]
        public string EstatusDesc { get; set; }
        [JsonProperty(PropertyName = "Usuario")]
        public UxiUsuariosEE Usuario { get; set; }
        [JsonProperty(PropertyName = "Request")]
        public string Request { get; set; }

    }
}
