using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class TblRelacionPedimento
    {
        [JsonProperty(PropertyName = "IdODC")]
        public int IdODC { get; set; }
        [JsonProperty(PropertyName = "IdOrdenCompra")]
        public int IdOrdenCompra { get; set; }
        [JsonProperty(PropertyName = "IdProducto")]
        public int IdProducto { get; set; }
        [JsonProperty(PropertyName = "SKU")]
        public string SKU { get; set; }
        [JsonProperty(PropertyName = "PrecioNeto")]
        public Nullable<decimal> PrecioNeto { get; set; }
        [JsonProperty(PropertyName = "PrecioVenta")]
        public Nullable<decimal> PrecioVenta { get; set; }
        [JsonProperty(PropertyName = "IdDescuento")]
        public int IdDescuento { get; set; }
        [JsonProperty(PropertyName = "Total")]
        public decimal Total { get; set; }
        [JsonProperty(PropertyName = "FechaPedimento")]
        public System.DateTime FechaPedimento { get; set; }
        [JsonProperty(PropertyName = "IdEstatusPedimento")]
        public int IdEstatusPedimento { get; set; }
        [JsonProperty(PropertyName = "IMEI")]
        public string IMEI { get; set; }
        [JsonProperty(PropertyName = "UUM")]
        public Nullable<int> UUM { get; set; }
        [JsonProperty(PropertyName = "FUM")]
        public Nullable<System.DateTime> FUM { get; set; }
    }
}
