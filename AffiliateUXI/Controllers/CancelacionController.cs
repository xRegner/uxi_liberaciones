using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;
namespace AffiliateUXI.Controllers
{
    public class CancelacionController : ApiController
    {
        //// GET: api/Cancelacion
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Cancelacion/5
        public bool Get(int id)
        {
            bool resultado = false;
            TblOrdenDeCompra objOdcResult = new TblOrdenDeCompra();
            CuentaUsuario usuariosII = new CuentaUsuario();
            //obtener orden de servicio

            using(uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                objOdcResult = (from i in context.TblOrdenDeCompra
                            where i.IdOrdenCompra == id
                            select i).FirstOrDefault();

                if (objOdcResult.IdEstatusOC == 1)
                {
                    //cancelar
                    objOdcResult.IdEstatusOC = 5;
                  

                    //context.SaveChanges();

                    //regresa saldo a favor 
                    usuariosII = (from i in context.CuentaUsuario
                                where i.IdUsuario == objOdcResult.IdUsuario
                                select i).FirstOrDefault();

                    usuariosII.SaldoAFavor = usuariosII.SaldoAFavor + objOdcResult.Total;

                   

                    //TODO:inserta movimiento  a favor 
                    var saldo = context.HistorialSaldos.Add(new HistorialSaldos()
                    {
                        Fecha = DateTime.Now,
                        IdUsuario = usuariosII.IdUsuario,
                        UUM = usuariosII.IdUsuario,
                        Monto_Entrada = (decimal)objOdcResult.Total,
                        IDTipoMovimiento = 3
                    });
                    context.SaveChanges();
                    resultado = true;


                }

            }

            

            return resultado;
        }

        //// POST: api/Cancelacion
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Cancelacion/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Cancelacion/5
        //public void Delete(int id)
        //{
        //}
    }
}
