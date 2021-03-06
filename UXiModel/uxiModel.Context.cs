﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class uxisolutionbdEntities : DbContext
    {
        public uxisolutionbdEntities()
            : base("name=uxisolutionbdEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UXI_Usuarios> UXI_Usuarios { get; set; }
        public virtual DbSet<CuentaUsuario> CuentaUsuario { get; set; }
        public virtual DbSet<HistorialSaldos> HistorialSaldos { get; set; }
        public virtual DbSet<TblCategoria> TblCategoria { get; set; }
        public virtual DbSet<TblOrdenDeCompra> TblOrdenDeCompra { get; set; }
        public virtual DbSet<TblRelacionPedimento> TblRelacionPedimento { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<CAT_EStatusPedimento> CAT_EStatusPedimento { get; set; }
        public virtual DbSet<TblServicio_Precio_tipoUsuario> TblServicio_Precio_tipoUsuario { get; set; }
        public virtual DbSet<TblProductos> TblProductos { get; set; }
        public virtual DbSet<UXI_Proveedores> UXI_Proveedores { get; set; }
        public virtual DbSet<CAT_TiposMovimientos> CAT_TiposMovimientos { get; set; }
        public virtual DbSet<MensajesOrdenes> MensajesOrdenes { get; set; }
    
        public virtual ObjectResult<GetODCbyODC_Result> GetODCbyODC(Nullable<int> idOdc)
        {
            var idOdcParameter = idOdc.HasValue ?
                new ObjectParameter("idOdc", idOdc) :
                new ObjectParameter("idOdc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetODCbyODC_Result>("GetODCbyODC", idOdcParameter);
        }
    
        public virtual int GetODCbyUsr(Nullable<int> idUsur)
        {
            var idUsurParameter = idUsur.HasValue ?
                new ObjectParameter("idUsur", idUsur) :
                new ObjectParameter("idUsur", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetODCbyUsr", idUsurParameter);
        }
    
        public virtual ObjectResult<getOrdenesDeCompra_Result> getOrdenesDeCompra(Nullable<int> idOrdenCompra, Nullable<System.DateTime> fechaOrdenD, Nullable<System.DateTime> fechaOrdenH, Nullable<int> idUsuario, string email)
        {
            var idOrdenCompraParameter = idOrdenCompra.HasValue ?
                new ObjectParameter("IdOrdenCompra", idOrdenCompra) :
                new ObjectParameter("IdOrdenCompra", typeof(int));
    
            var fechaOrdenDParameter = fechaOrdenD.HasValue ?
                new ObjectParameter("FechaOrdenD", fechaOrdenD) :
                new ObjectParameter("FechaOrdenD", typeof(System.DateTime));
    
            var fechaOrdenHParameter = fechaOrdenH.HasValue ?
                new ObjectParameter("FechaOrdenH", fechaOrdenH) :
                new ObjectParameter("FechaOrdenH", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrdenesDeCompra_Result>("getOrdenesDeCompra", idOrdenCompraParameter, fechaOrdenDParameter, fechaOrdenHParameter, idUsuarioParameter, emailParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<sp_getOrderDetail_Result> sp_getOrderDetail(Nullable<int> idOrdenCompra)
        {
            var idOrdenCompraParameter = idOrdenCompra.HasValue ?
                new ObjectParameter("IdOrdenCompra", idOrdenCompra) :
                new ObjectParameter("IdOrdenCompra", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getOrderDetail_Result>("sp_getOrderDetail", idOrdenCompraParameter);
        }
    
        public virtual ObjectResult<sp_getServicesXParam_Result> sp_getServicesXParam(Nullable<int> idProducto, Nullable<int> idCategoria, Nullable<bool> activo)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("IdCategoria", idCategoria) :
                new ObjectParameter("IdCategoria", typeof(int));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("Activo", activo) :
                new ObjectParameter("Activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getServicesXParam_Result>("sp_getServicesXParam", idProductoParameter, idCategoriaParameter, activoParameter);
        }
    
        public virtual ObjectResult<getOrdenesDeCompraServicio_Result> getOrdenesDeCompraServicio(Nullable<int> idOrdenCompra, Nullable<System.DateTime> fechaOrdenD, Nullable<System.DateTime> fechaOrdenH, Nullable<int> idUsuario, string email)
        {
            var idOrdenCompraParameter = idOrdenCompra.HasValue ?
                new ObjectParameter("IdOrdenCompra", idOrdenCompra) :
                new ObjectParameter("IdOrdenCompra", typeof(int));
    
            var fechaOrdenDParameter = fechaOrdenD.HasValue ?
                new ObjectParameter("FechaOrdenD", fechaOrdenD) :
                new ObjectParameter("FechaOrdenD", typeof(System.DateTime));
    
            var fechaOrdenHParameter = fechaOrdenH.HasValue ?
                new ObjectParameter("FechaOrdenH", fechaOrdenH) :
                new ObjectParameter("FechaOrdenH", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrdenesDeCompraServicio_Result>("getOrdenesDeCompraServicio", idOrdenCompraParameter, fechaOrdenDParameter, fechaOrdenHParameter, idUsuarioParameter, emailParameter);
        }
    
        public virtual ObjectResult<SPBI_TOP10USR_Result> SPBI_TOP10USR(Nullable<System.DateTime> fecha_ini, Nullable<System.DateTime> fecha_Fin)
        {
            var fecha_iniParameter = fecha_ini.HasValue ?
                new ObjectParameter("Fecha_ini", fecha_ini) :
                new ObjectParameter("Fecha_ini", typeof(System.DateTime));
    
            var fecha_FinParameter = fecha_Fin.HasValue ?
                new ObjectParameter("Fecha_Fin", fecha_Fin) :
                new ObjectParameter("Fecha_Fin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPBI_TOP10USR_Result>("SPBI_TOP10USR", fecha_iniParameter, fecha_FinParameter);
        }
    
        public virtual ObjectResult<SPU_GetUsuarioCuenta_Result> SPU_GetUsuarioCuenta()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPU_GetUsuarioCuenta_Result>("SPU_GetUsuarioCuenta");
        }
    
        public virtual ObjectResult<sp_getMensajesOrdenes_Result> sp_getMensajesOrdenes(Nullable<int> idOrdenCompra)
        {
            var idOrdenCompraParameter = idOrdenCompra.HasValue ?
                new ObjectParameter("IdOrdenCompra", idOrdenCompra) :
                new ObjectParameter("IdOrdenCompra", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getMensajesOrdenes_Result>("sp_getMensajesOrdenes", idOrdenCompraParameter);
        }
    }
}
