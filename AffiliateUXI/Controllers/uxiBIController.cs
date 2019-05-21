using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UXiModel;
using AffiliateUXI.Afiliados_BLL;

namespace AffiliateUXI.Controllers
{
    public class uxiBIController : ApiController
    {


        // GET: api/uxiBI/5
        public List<SPBI_TOP10USR_Result> Get(string FechaIni = "", string FechaFin = "")
        {


            var fechaD = FechaIni == "" ? DateTime.MinValue : Convert.ToDateTime(FechaIni.Substring(0, 4) + "-" + FechaIni.Substring(4, 2) + "-" + FechaIni.Substring(6, 2));
            var fechaH = FechaFin == "" ? DateTime.Now : Convert.ToDateTime(FechaFin.Substring(0, 4) + "-" + FechaFin.Substring(4, 2) + "-" + FechaFin.Substring(6, 2));
            List<SPBI_TOP10USR_Result> Resultado = new List<SPBI_TOP10USR_Result>();

            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                Resultado = context.SPBI_TOP10USR(fechaD, fechaH).ToList();
            }

            return Resultado;
        }


    }
}
