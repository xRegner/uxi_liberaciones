using System;
using System.Collections.Generic;
using UxiEntities;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;

namespace MvcApplication1.Helpers
{
    public class ListaEstatus
    {
        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public List<EstatusOrden> _listaEstatus()
        {
            List<EstatusOrden> OrdenesCompra = new List<EstatusOrden>();
            var baseAddress = api + "api/Estatus/GetLista";
            using (var wb = new WebClient())
            {

                WebClient webClient = new WebClient();
                string result = webClient.DownloadString(baseAddress);
                OrdenesCompra = ProcessDataJson(result);
            }
            return OrdenesCompra;
        }

        private List<EstatusOrden> ProcessDataJson(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            List<EstatusOrden> obj = new List<EstatusOrden>();
            obj = JsonConvert.DeserializeObject<List<EstatusOrden>>(strDataJson);
            return obj;
        }
    }
}