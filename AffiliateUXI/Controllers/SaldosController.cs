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
    public class SaldosController : ApiController
    {

        // GET: api/Saldos/5
        public List<Saldos> Get(int IdUsuario, string sd = "", string ed = "", int daym=0)
        {
            List<Saldos> saldos = new List<Saldos>();
            List<Saldos> query = null;

            var startDate = DateTime.Now;
            var endDate = DateTime.Today.AddDays(-daym);
            
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                query = (from h in context.HistorialSaldos
                         where h.IdUsuario == IdUsuario && (h.Fecha.Value >= endDate && h.Fecha.Value <= startDate)
                         select new Saldos
                         {
                             IdHistorial = h.IdHistorial,
                                Fecha = h.Fecha.Value,
                                FechaFF = h.Fecha.ToString(),
                                IdUsuario = (int)h.IdUsuario,
                                Monto_Salida = h.Monto_Salida,
                                Monto_Entrada = h.Monto_Entrada,
                                UUM = h.UUM,
                                TipoMovimiento = new TiposMovimientos
                                {
                                    IDTipoMovimiento = h.IDTipoMovimiento,
                                    Descripcion = h.CAT_TiposMovimientos.Descripcion
                                }
                            }).ToList();

                //saldos.AddRange(query);
            }
            return query;
        }

        // POST: api/Saldos
        public int Post(Saldos saldo)
        {
            int IDHistorial = 0;

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                HistorialSaldos hs = new HistorialSaldos();

                hs = context.HistorialSaldos.Add(new HistorialSaldos()
                {
                    Monto_Entrada = saldo.Monto_Entrada,
                    Monto_Salida = saldo.Monto_Salida,
                    IdUsuario = saldo.IdUsuario,
                    //Fecha = DateTime.Now,
                    UUM = saldo.UUM,
                    IDTipoMovimiento = saldo.TipoMovimiento.IDTipoMovimiento
                });

                context.SaveChanges();

                IDHistorial = hs.IdHistorial;
            }

            return IDHistorial;
        }

        // PUT: api/Saldos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Saldos/5
        public void Delete(int id)
        {
        }
    }
}
