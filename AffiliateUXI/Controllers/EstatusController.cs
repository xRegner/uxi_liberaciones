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
    public class EstatusController : ApiController
    {
        public List<EstatusOrden> GetLista()
        {
            List<EstatusOrden> listEstatusOrden = new List<EstatusOrden>();

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = (from obj in context.CAT_EStatusPedimento
                             select new EstatusOrden()
                             {
                                 IdEstatusOC = obj.IdEstatusOC,
                                 Descripcion=obj.Descripcion
                             }
                             );
                listEstatusOrden.AddRange(query);
            }

            return listEstatusOrden;
        }
    }
}
