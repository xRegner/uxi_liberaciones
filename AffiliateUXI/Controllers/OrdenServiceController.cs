using AffiliateUXI.Afiliados_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UxiEntities;
using UXiModel;
namespace AffiliateUXI.Controllers
{
    public class OrdenServiceController : ApiController
    {

        /// <summary>
        /// Insertar orden de compra
        /// </summary>Generar orden de compra 
        /// <param name="value"></param>
        // POST: api/OrdenService
        public OrdenDeCompra Post(OrdenDeCompra _objODC)
        {
            List<string> request = _objODC.Request.Split('|').ToList();
            TblOrdenDeCompra ordenCompra = new TblOrdenDeCompra(_objODC.Usuario.IdUsuario, request[0]);
            request.RemoveAt(0);
            ODC odc = new ODC();
            ordenCompra = odc.InsertOrden(ordenCompra);
            List<UXiModel.TblRelacionPedimento> detalle = request.Select(r => new UXiModel.TblRelacionPedimento(r, _objODC.Usuario.IdUsuario, ordenCompra.IdOrdenCompra)).ToList();
            odc.InsertAllOrderDetails(detalle);
            odc.SendMail(ordenCompra.IdOrdenCompra);
            return _objODC;
        }

        [Route("api/OrdenService/GetList")]
        public List<OrdenDeCompra> GetList(int IdOrdenCompra = 0, string FechaOrdenD = "",string FechaOrdenH="", int IdUsuario = 0, string Email = "")
        {
            var fechaD = FechaOrdenD == "" ? DateTime.MinValue : Convert.ToDateTime(FechaOrdenD.Substring(0, 4) + "-" + FechaOrdenD.Substring(4, 2) + "-" + FechaOrdenD.Substring(6, 2));
            var fechaH = FechaOrdenH == "" ? DateTime.MinValue : Convert.ToDateTime(FechaOrdenH.Substring(0, 4) + "-" + FechaOrdenH.Substring(4, 2) + "-" + FechaOrdenH.Substring(6, 2));
            List<OrdenDeCompra> listOrdenes = new List<OrdenDeCompra>();
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = (from obj in context.getOrdenesDeCompra(IdOrdenCompra, fechaD, fechaH, IdUsuario, Email)
                             select new OrdenDeCompra()
                             {
                                 IdOrdenCompra = obj.IdOrdenCompra,
                                 IdEstatusOC = obj.IdEstatusOC,
                                 IdZona = obj.IdZona,
                                 EstatusDesc = obj.EstatusDesc,
                                 FechaOrden = obj.FechaOrden,
                                 FechaPagoMax = obj.FechaPagoMax,
                                 UUM = obj.UUM,
                                 ReferenciaBancaria = obj.ReferenciaBancaria,
                                 FUM = obj.FUM,
                                 Total = obj.Total,
                                 Usuario = new UxiUsuariosEE()
                                 {
                                     IdUsuario = obj.IdUsuario,
                                     Nombre = obj.Nombre,
                                     ApPaterno = obj.ApPaterno,
                                     ApMaterno = obj.ApMaterno,
                                     Email = obj.Email,
                                     Telefono=obj.Telefono
                                 }
                             });
                listOrdenes.AddRange(query);
            }

            return listOrdenes;
        }
        [Route("api/OrdenService/GetDetail")]
        public OrdenDeCompraDetalle GetDetail(int IdOrdenCompra)
        {
            OrdenDeCompraDetalle listDetail = new OrdenDeCompraDetalle();
            List<ProductosDetalleOrden> Productos = new List<ProductosDetalleOrden>();
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = (from det in context.sp_getOrderDetail(IdOrdenCompra)
                             select det);

                listDetail.IdOrdenCompra = IdOrdenCompra;
                listDetail.IdEstatus = (from odc in context.TblOrdenDeCompra where odc.IdOrdenCompra == IdOrdenCompra select odc.IdEstatusOC).FirstOrDefault(); 

                foreach (sp_getOrderDetail_Result item in query)
                {
                    ProductosDetalleOrden prod = new ProductosDetalleOrden
                    {
                        IdDetail = item.IdODC,
                        PrecioNeto = item.PrecioNeto,
                        PrecioVenta = item.PrecioVenta,
                        Total = item.Total,
                        IdDescuento = item.IdDescuento,
                        Producto = new Servicios()
                        {
                            IdProducto = item.IdProducto,
                            Descripcion_Corta = item.Descripcion_Corta,
                            Descripcion_Larga = item.Descripcion_Larga,
                            SKU = item.SKU,
                            IMEI=item.IMEI
                        }
                    };
                    Productos.Add(prod);
                }
                listDetail.Productos = Productos;
            }
            return listDetail;
        }
        [Route("api/OrdenService/GETUpdateODS")]
        public bool GETUpdateODS(int id, int idStatus)
        {
            bool resultado = false;
            EnviarCorreo objEnviaMail = new EnviarCorreo();
            TblOrdenDeCompra objVar = new TblOrdenDeCompra();
            UXI_Usuarios usuario = new UXI_Usuarios();
            try
            {
                using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                {
                    objVar = (from i in context.TblOrdenDeCompra
                              where i.IdOrdenCompra == id
                              select i).FirstOrDefault();

                    objVar.IdEstatusOC = idStatus;
                    

                    usuario = (from o in context.UXI_Usuarios
                             where o.IdUsuario == objVar.IdUsuario
                             select o).FirstOrDefault();
                    if (idStatus == 5)
                    {
                        CancelacionController objcancel = new CancelacionController();
                        objcancel.Get(id);
                    }
                    context.SaveChanges();
                }

                if (objVar.IdEstatusOC == 4 && usuario.Email != "")
                {
                    p_correoE mail = new p_correoE()
                    {
                        sFrom = "noreply@uxisolutions.com",
                        sTo = usuario.Email,
                        sToCC = "Uriesbntz@gmail.com",
                        sSubject = "Orden Terminada",
                        sBody = "Hola " + usuario.Nombre + " " + usuario.ApPaterno + Environment.NewLine + ", te notificamos que tu orden número" + id.ToString() + " ya se encuentra terminada"
                    };

                    objEnviaMail.EnviarEmail(mail);
                }

                //si cancela se hace un reembolso 
               
                resultado = true;
            }

            catch
            {
                resultado =  false;
            }
            return resultado;
        }
        [Route("api/OrdenService/GetOrdenServicio")]
        public List<OrdenServicioDetalle> GetListOrdenServicio(int IdOrdenCompra = 0, string FechaOrdenD = "", string FechaOrdenH = "", int IdUsuario = 0, string Email = "")
        {
            var fechaD = FechaOrdenD == "" ? DateTime.MinValue : Convert.ToDateTime(FechaOrdenD.Substring(0, 4) + "-" + FechaOrdenD.Substring(4, 2) + "-" + FechaOrdenD.Substring(6, 2));
            var fechaH = FechaOrdenH == "" ? DateTime.MinValue : Convert.ToDateTime(FechaOrdenH.Substring(0, 4) + "-" + FechaOrdenH.Substring(4, 2) + "-" + FechaOrdenH.Substring(6, 2));
            List<OrdenServicioDetalle> listOrdenes = new List<OrdenServicioDetalle>();
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = (from obj in context.getOrdenesDeCompraServicio(IdOrdenCompra, fechaD, fechaH, IdUsuario, Email)
                             select new OrdenServicioDetalle()
                             {
                                 IdOrdenCompra = obj.IdOrdenCompra,
                                 FechaOrden = obj.FechaOrden,
                                 Total = obj.TotalServicio,
                                 IMEI=(obj.IMEI != null ? obj.IMEI : ""),
                                 Descripcion_Corta=obj.Descripcion_corta,                                 
                                 Descripcion_Larga=obj.Descripcion_Larga,
                                 descripcion=obj.Descripcion,
                                 email=obj.Email,
                                 IdEstatusOC=obj.IdEstatusOC,
                                 IdProducto=obj.IdProducto
                                
                             });
                listOrdenes.AddRange(query);
            }

            return listOrdenes;
        }
    }
}
