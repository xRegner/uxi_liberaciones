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
    public class GetServicesController : ApiController
    {


        // GET: api/GetServices/
        public List<Servicios> Get(int tipoCliente, bool verTarifas)
        {
            List<TblProductos> result = new List<TblProductos>();
            Servicios ser = new Servicios();

            List<Servicios> resultado = new List<Servicios>();
                using (uxisolutionbdEntities context =  new uxisolutionbdEntities())
            {
                if (tipoCliente == 3)
                {
                    var query = from j in context.TblProductos
                                where j.Activo == true
                                select new Servicios()
                                {
                                    IdProducto = j.IdProducto,
                                    Activo = j.Activo,
                                    Descripcion_Corta = j.Descripcion_Corta,
                                    Descripcion_Larga = j.Descripcion_Larga + " " + (verTarifas ? j.PrecioNeto.ToString() : "0 ") + "MXN",
                                    FacturaProveedor = j.FacturaProveedor,
                                    FUM = j.FUM,
                                    PrecioNeto = verTarifas ? j.PrecioNeto : 0,
                                    SKU = j.SKU
                                };
                    resultado = query.ToList();
                }
                else
                {
                    var query = from j in context.TblProductos
                                join k in context.TblServicio_Precio_tipoUsuario on j.IdProducto equals k.IdProducto
                                where j.Activo == true & k.TipoCliente == tipoCliente
                                select new Servicios()
                                {
                                    IdProducto = j.IdProducto,
                                    Activo = j.Activo,
                                    Descripcion_Corta = j.Descripcion_Corta,
                                    Descripcion_Larga = j.Descripcion_Larga + " " + (verTarifas ? k.Precio.ToString() : "0 ") + "MXN",
                                    FacturaProveedor = j.FacturaProveedor,
                                    FUM = j.FUM,
                                    PrecioNeto = verTarifas ? k.Precio : 0,
                                    SKU = j.SKU
                                };
                    resultado = query.ToList();
                }
              

            }

            return resultado.OrderByDescending(x=>x.IdProducto).ToList();
            
        }

  
    }
}
