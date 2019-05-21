using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UxiEntities;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Collections.Specialized;

namespace MvcApplication1.Helpers
{
    public class OrdenesUsuario
    {
        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public List<OrdenDeCompra> ListaOrdenes(int IdOrdenCompra = 0, string FechaOrdenD = "", string FechaOrdenH = "", int IdUsuario = 0, string Email = "")
        {
            List<OrdenDeCompra> OrdenesCompra = new List<OrdenDeCompra>();
            var baseAddress = api + "api/OrdenService/GetList";
            using (var wb = new WebClient())
            {

                WebClient webClient = new WebClient();
                webClient.QueryString.Add("IdOrdenCompra", IdOrdenCompra.ToString());
                webClient.QueryString.Add("FechaOrdenD", FechaOrdenD.ToString());
                webClient.QueryString.Add("FechaOrdenH", FechaOrdenH.ToString());
                webClient.QueryString.Add("IdUsuario", IdUsuario.ToString());
                if (Email!="") webClient.QueryString.Add("Email", Email.ToString());
                string result = webClient.DownloadString(baseAddress);
                OrdenesCompra = ProcessDataJson(result);
            }
            return OrdenesCompra;
        }

        private List<OrdenDeCompra> ProcessDataJson(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            List<OrdenDeCompra> obj = new List<OrdenDeCompra>();
            obj = JsonConvert.DeserializeObject<List<OrdenDeCompra>>(strDataJson);
            return obj;
        }

    }
}