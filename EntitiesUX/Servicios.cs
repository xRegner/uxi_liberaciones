using System;

namespace EntitiesUX
{
    public class Servicios
    {

        public int IdProducto { get; set; }
        public string SKU { get; set; }
        public string Descripcion_Corta { get; set; }
        public string Descripcion_Larga { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public string FacturaProveedor { get; set; }
        public Nullable<decimal> PrecioNeto { get; set; }
        public string Ubicacion { get; set; }
        public Nullable<System.DateTime> FUM { get; set; }
        public Nullable<int> UUM { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
