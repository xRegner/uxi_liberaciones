using System;
using Newtonsoft.Json;

namespace UxiEntities
{
    public class ProductosDetalleOrden
    {
        [JsonProperty(PropertyName = "IdDetail")]
        public int IdDetail { get; set; }
        [JsonProperty(PropertyName = "PrecioNeto")]
        public Nullable<decimal> PrecioNeto { get; set; }
        [JsonProperty(PropertyName = "PrecioVenta")]
        public Nullable<decimal> PrecioVenta { get; set; }
        [JsonProperty(PropertyName = "Total")]
        public Nullable<decimal> Total { get; set; }
        [JsonProperty(PropertyName = "IdDescuento")]
        public Nullable<int> IdDescuento { get; set; }
        [JsonProperty(PropertyName = "Producto")]
        public Servicios Producto { get; set; }
    }
}
