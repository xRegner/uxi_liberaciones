using System;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OrdenCompraAll
    {
        [JsonProperty(PropertyName = "idusuario")]
        public int idusuario { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
        [JsonProperty(PropertyName = "telefono")]
        public string telefono { get; set; }
        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }
        [JsonProperty(PropertyName = "apPaterno")]
        public string apPaterno { get; set; }
        [JsonProperty(PropertyName = "IdOrdenCompra")]
        public int IdOrdenCompra { get; set; }
        [JsonProperty(PropertyName = "Total")]
        public Nullable<decimal> Total { get; set; }
        [JsonProperty(PropertyName = "FechaOrden")]
        public System.DateTime FechaOrden { get; set; }
        [JsonProperty(PropertyName = "IdProducto")]
        public int IdProducto { get; set; }
        [JsonProperty(PropertyName = "Descripcion_Larga")]
        public string Descripcion_Larga { get; set; }
        [JsonProperty(PropertyName = "PrecioVenta")]
        public Nullable<decimal> PrecioVenta { get; set; }
        [JsonProperty(PropertyName = "IMEI")]
        public string IMEI { get; set; }
        [JsonProperty(PropertyName = "descripcion")]
        public string descripcion { get; set; }
    }
}
