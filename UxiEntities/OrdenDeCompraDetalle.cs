using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OrdenDeCompraDetalle
    {
        [JsonProperty(PropertyName = "IdOrdenCompra")]
        public int IdOrdenCompra { get; set; }
        [JsonProperty(PropertyName = "IdEstatus")]
        public int IdEstatus { get; set; }
        [JsonProperty(PropertyName = "Productos")]
        public List<ProductosDetalleOrden> Productos { get; set; }
    }
}
