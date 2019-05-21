using System;
using System.Collections.Generic;
using UxiEntities;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;

namespace MvcApplication1.Helpers
{
    public class OrdenServicios
    {
            string api = ConfigurationManager.AppSettings["apiUX"].ToString();
            public List<OrdenServicioDetalle> ListaOrdenesServicios(int IdOrdenCompra = 0, string FechaOrdenD = "", string FechaOrdenH = "", int IdUsuario = 0, string Email = "")
            {
                List<OrdenServicioDetalle> OrdenesCompra = new List<OrdenServicioDetalle>();
                var baseAddress = api + "api/OrdenService/GetOrdenServicio";
                using (var wb = new WebClient())
                {

                    WebClient webClient = new WebClient();
                    webClient.QueryString.Add("IdOrdenCompra", IdOrdenCompra.ToString());
                    webClient.QueryString.Add("FechaOrdenD", FechaOrdenD.ToString());
                    webClient.QueryString.Add("FechaOrdenH", FechaOrdenH.ToString());
                    webClient.QueryString.Add("IdUsuario", IdUsuario.ToString());
                    if (Email != "") webClient.QueryString.Add("Email", Email.ToString());
                    string result = webClient.DownloadString(baseAddress);
                    OrdenesCompra = ProcessDataJson(result);
                }
                return OrdenesCompra;
            }

            private List<OrdenServicioDetalle> ProcessDataJson(string strDataJson)
            {
                /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic data = jss.Deserialize<dynamic>(strDataJson); */
                List<OrdenServicioDetalle> obj = new List<OrdenServicioDetalle>();
                obj = JsonConvert.DeserializeObject<List<OrdenServicioDetalle>>(strDataJson);
                return obj;
            }

        }
}