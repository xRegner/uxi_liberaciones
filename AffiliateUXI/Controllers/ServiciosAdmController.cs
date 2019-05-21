using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;
using UxiEntities;

namespace AffiliateUXI.Controllers
{
    public class ServiciosAdmController : ApiController
    {
        // GET: api/ServiciosAdm/5
        public List<Servicios> Get(int ids = 0, int idc = 0, bool? act = null)
        {
            List<Servicios> result = new List<Servicios>();

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = (from ser in context.sp_getServicesXParam(idProducto: ids, idCategoria: idc, activo: act) select ser).ToList();
                foreach (var ser in query)
                {
                    Servicios servicio = new Servicios(){
                        IdProducto = ser.idproducto,
                        SKU = ser.SKU,
                        Descripcion_Corta = ser.Descripcion_Corta,
                        Descripcion_Larga = ser.Descripcion_Larga,
                        IdCategoria = ser.IdCategoria,
                        Desc_Categoria = ser.DescCategoria,
                        IdProveedor = ser.IdProveedor,
                        FacturaProveedor = ser.FacturaProveedor,
                        PrecioNeto = ser.PrecioNeto,
                        Activo = ser.Activo
                    };

                    var precios = (from pre in context.TblServicio_Precio_tipoUsuario where pre.IdProducto == ser.idproducto select pre).ToList();
                    if (precios.Count > 0)
                    {
                        List<Servicio_Precio_TipoUsuario> ListSerPrecio = new List<Servicio_Precio_TipoUsuario>();
                        foreach (var precio in precios)
                        {
                            Servicio_Precio_TipoUsuario ServicioPrecios = new Servicio_Precio_TipoUsuario()
                            {
                                IDServicioPrecioUsuario = precio.IDServicioPrecioUsuario,
                                Precio = precio.Precio,
                                Tipocliente = precio.TipoCliente
                            };                            
                            switch (precio.TipoCliente) {
                                case 1:
                                    servicio.PrecioMayoristaPRO = precio.Precio;
                                    break;
                                case 2:
                                    servicio.PrecioMayorista = precio.Precio;
                                    break;
                            }
                            ListSerPrecio.Add(ServicioPrecios);
                        }
                        servicio.Precios = ListSerPrecio;
                    }
                   
                    result.Add(servicio);
                }
                                
            }

            return result;
        }

        // POST: api/ServiciosAdm
        public Servicios Post(Servicios ser)
        {
            TblProductos Prod = new TblProductos()
            {
                SKU = "SKU",
                Descripcion_Corta = ser.Descripcion_Corta,
                Descripcion_Larga = ser.Descripcion_Larga,
                IdCategoria = ser.IdCategoria,
                IdProveedor = 0,
                FacturaProveedor = "0",
                PrecioNeto = ser.PrecioNeto,
                Ubicacion = "0",
                FUM = DateTime.Now.Date,
                UUM = ser.UUM,
                Activo = true
            };
           
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                context.TblProductos.Add(Prod);
                context.SaveChanges();
            }

            List<TblServicio_Precio_tipoUsuario> ListSerPreUsu = new List<TblServicio_Precio_tipoUsuario>();
            foreach (var precio in ser.Precios)
            {
                TblServicio_Precio_tipoUsuario SerPreUsu = new TblServicio_Precio_tipoUsuario()
                {
                    IdProducto = Prod.IdProducto,
                    Precio = precio.Precio,
                    TipoCliente = precio.Tipocliente
                };
                ListSerPreUsu.Add(SerPreUsu);
            }

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                context.TblServicio_Precio_tipoUsuario.AddRange(ListSerPreUsu);
                context.SaveChanges();
            }

            ser.IdProducto = Prod.IdProducto; 
            return ser; 
        }

        // PUT: api/ServiciosAdm/5
        public bool Put(int ids, Servicios ser)
        {
            if (ids != ser.IdProducto)
            {
                return false;
            }

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                TblProductos Prod = new TblProductos()
                {
                IdProducto = ser.IdProducto,
                SKU = ser.SKU,
                Descripcion_Corta = ser.Descripcion_Corta,
                Descripcion_Larga = ser.Descripcion_Larga,
                IdCategoria = ser.IdCategoria,
                IdProveedor = ser.IdProveedor,
                FacturaProveedor = ser.FacturaProveedor,
                PrecioNeto = ser.PrecioNeto,
                Ubicacion = ser.Ubicacion,
                FUM = DateTime.Now.Date,
                UUM = ser.UUM,
                Activo = ser.Activo 
                };

                context.Entry(Prod).State = System.Data.Entity.EntityState.Modified;

                foreach (var precio in ser.Precios)
                {
                    TblServicio_Precio_tipoUsuario SerPreUsu = new TblServicio_Precio_tipoUsuario()
                    {
                        IDServicioPrecioUsuario = precio.IDServicioPrecioUsuario,
                        IdProducto = ser.IdProducto,
                        Precio = precio.Precio,
                        TipoCliente = precio.Tipocliente
                    };
                    context.Entry(SerPreUsu).State = System.Data.Entity.EntityState.Modified;
                }    

                context.SaveChanges();
            }

            return true;
        }

        // DELETE: api/ServiciosAdm/5
        //public void Delete(int id)
        //{
        //}
    }
}
