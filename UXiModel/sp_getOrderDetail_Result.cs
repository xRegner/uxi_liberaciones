//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UXiModel
{
    using System;
    
    public partial class sp_getOrderDetail_Result
    {
        public int IdOrdenCompra { get; set; }
        public int IdODC { get; set; }
        public int IdProducto { get; set; }
        public Nullable<decimal> PrecioNeto { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public decimal Total { get; set; }
        public int IdDescuento { get; set; }
        public string Descripcion_Corta { get; set; }
        public string Descripcion_Larga { get; set; }
        public string SKU { get; set; }
        public string IMEI { get; set; }
    }
}
