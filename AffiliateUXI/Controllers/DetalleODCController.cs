using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;
using UxiEntities;
using AffiliateUXI.Afiliados_BLL;
namespace AffiliateUXI.Controllers
{
    public class DetalleODCController : ApiController
    {
      



        // POST: api/DetalleODC
        public UxiEntities.TblRelacionPedimento Post( UXiModel.TblRelacionPedimento _ObjRelPend)
        {
            UxiEntities.TblRelacionPedimento result = new UxiEntities.TblRelacionPedimento();

            using(uxisolutionbdEntities context =  new uxisolutionbdEntities())
            {
                var query = context.TblRelacionPedimento.Add(_ObjRelPend);
                context.SaveChanges();
            }

                return result;

        }


        // GET: api/DetalleODC
        public List<OrdenCompraAll> Get(int idOdc)
        {
            EnviarCorreo objEnviaMail = new EnviarCorreo();
            List<OrdenCompraAll> resultado = new List<OrdenCompraAll>();
            string mailBody = string.Empty;
            OrdenCompraMail _odcBody = new OrdenCompraMail();
            p_correoE mail = new p_correoE()
            {
                sFrom = "noreply@uxisolutions.com",
         
                sToCC = "fernando_cabrera@uxisolutions.com",
                sSubject = "Orden de Servicio UXI-Solutions",
                sBody = mailBody

            };

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = from i in context.GetODCbyODC(idOdc)
                            select new OrdenCompraAll()
                            {
                                apPaterno = i.apPaterno,
                                descripcion = i.descripcion,
                                Descripcion_Larga = i.Descripcion_Larga,
                                email = i.email,
                                FechaOrden = i.FechaOrden,
                                IdOrdenCompra = i.IdOrdenCompra,
                                IdProducto = i.IdProducto,
                                idusuario = i.idusuario,
                                IMEI = i.IMEI,
                                Nombre = i.Nombre,
                                PrecioVenta = i.PrecioVenta,
                                telefono = i.telefono,
                                Total = i.Total                                
                            };
                resultado = query.ToList();
                mailBody = _odcBody.generaMAILODC(resultado);
                mail.sBody = mailBody;
                mail.sTo = resultado[0].email;
             


            }


            objEnviaMail.EnviarEmail(mail);

            //Envio e mail a proveedor

            p_correoE mailProveedor = new p_correoE()
            {
                sFrom = "noreply@uxisolutions.com",

                sToCC = "fernando_cabrera@uxisolutions.com",
                sSubject = "Nueva - Liberación",
                sBody = "Hola Jorge, se ha generado una nueva orden http://proveedoresuxi.azurewebsites.net/",
                sTo = "jneria13@gmail.com"

            };
            objEnviaMail.EnviarEmail(mailProveedor);




            return resultado;
        }


    }
}
