using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UxiEntities;
using UXiModel;
namespace AffiliateUXI.Afiliados_BLL
{
    public class ODC
    {

        public OrdenDeCompra GenerarODC(TblOrdenDeCompra OrdenCompra)
        {
            OrdenDeCompra resultado = new OrdenDeCompra();

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = context.TblOrdenDeCompra.Add(OrdenCompra);
                context.SaveChanges();
                //TODO:Actualizar saldo usuario
            }

            return resultado;
        }

        public void RelacionPedimento(int idordenCompra, OrdenDeCompra odc)
        {

        }

        public TblOrdenDeCompra InsertOrden(TblOrdenDeCompra orden)
        {
            decimal resta = 0;
            UXiModel.CuentaUsuario _CtaUsr = new UXiModel.CuentaUsuario();
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = context.TblOrdenDeCompra.Add(orden);


                _CtaUsr = context.CuentaUsuario.First(i => i.IdUsuario == orden.IdUsuario);
                resta = (decimal)_CtaUsr.SaldoAFavor - orden.Total.Value;


                _CtaUsr.SaldoAFavor = resta;
                context.SaveChanges();

                var saldo = context.HistorialSaldos.Add(new HistorialSaldos()
                {
                    Fecha = DateTime.Now,
                    IdUsuario = orden.IdUsuario,
                    UUM = orden.IdUsuario,
                    Monto_Salida = (decimal)orden.Total,
                    IDTipoMovimiento = 4
                });

                context.SaveChanges();
            }
            return orden;
        }

        public List<OrdenCompraAll> SendMail(int idOdc)
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

            return resultado;
        }
        public void InsertAllOrderDetails(List<UXiModel.TblRelacionPedimento> details)
        {
            foreach (var detail in details)
            {
                InsertDetail(detail);
            }
        }
        public void InsertDetail(UXiModel.TblRelacionPedimento _ObjRelPend)
        {
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = context.TblRelacionPedimento.Add(_ObjRelPend);
                context.SaveChanges();
            }

        }
    }
}