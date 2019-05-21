using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Servicios
    {
        [JsonProperty(PropertyName = "IdProducto")]
        public int IdProducto { get; set; }
        [JsonProperty(PropertyName = "SKU")]
        public string SKU { get; set; }
        [JsonProperty(PropertyName = "Descripcion_Corta")]
        [Required(ErrorMessage = "La descripción corta es requerida")]
        public string Descripcion_Corta { get; set; }        
        [JsonProperty(PropertyName = "Descripcion_Larga")]
        [Required(ErrorMessage = "La descripción larga es requerida")]
        public string Descripcion_Larga { get; set; }
        [JsonProperty(PropertyName = "IdCategoria")]
        [Required(ErrorMessage = "La categoria es requerida")]
        public Nullable<int> IdCategoria { get; set; }
        [JsonProperty(PropertyName = "Desc_Categoria")]
        public string Desc_Categoria { get; set; }
        [JsonProperty(PropertyName = "IdProveedor")]
        public Nullable<int> IdProveedor { get; set; }
        [JsonProperty(PropertyName = "FacturaProveedor")]
        public string FacturaProveedor { get; set; }
        [JsonProperty(PropertyName = "PrecioNeto")]
        [Required(ErrorMessage = "El precio minorista es requerido")]
        public Nullable<decimal> PrecioNeto { get; set; }
        [JsonProperty(PropertyName = "PrecioMayorista")]
        [Required(ErrorMessage = "El precio mayorista es requerido")]
        public Nullable<decimal> PrecioMayorista { get; set; }
        [JsonProperty(PropertyName = "PrecioMayoristaPRO")]
        [Required(ErrorMessage = "El precio mayorista PRO es requerido")]
        public Nullable<decimal> PrecioMayoristaPRO { get; set; }
        [JsonProperty(PropertyName = "Ubicacion")]
        public string Ubicacion { get; set; }
        [JsonProperty(PropertyName = "FUM")]
        public Nullable<System.DateTime> FUM { get; set; }
        [JsonProperty(PropertyName = "UUM")]
        public Nullable<int> UUM { get; set; }
        [JsonProperty(PropertyName = "Activo")]
        public Nullable<bool> Activo { get; set; }
        [JsonProperty(PropertyName = "IMEI")]
        public string IMEI { get; set; }
        [JsonProperty(PropertyName = "Precios")]
        public List<Servicio_Precio_TipoUsuario> Precios { get; set; }
    }
}
