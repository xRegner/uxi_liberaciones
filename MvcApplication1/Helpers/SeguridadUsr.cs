using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;
using MvcApplication1.Helpers;
using UxiEntities;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;


namespace MvcApplication1.Helpers
{
    public class SeguridadUsr:Controller
    {

        int sesionUsr = 0;
        string nombre = string.Empty;
        string tipousr = string.Empty;

        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public UxiUsuariosEE Usuario(string idUsuario)
        {
            UxiUsuariosEE resultado = new UxiUsuariosEE();
            var baseAddress = api + "api/AdmPass/";
            using (var wb = new WebClient())
            {

                WebClient webClient = new WebClient();
                 webClient.QueryString.Add("id", idUsuario);
                string result = webClient.DownloadString(baseAddress);
                resultado = ProcessDataJson(result);
            }
            return resultado;

        }

        private UxiUsuariosEE ProcessDataJson(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            UxiUsuariosEE obj = new UxiUsuariosEE();
            obj = JsonConvert.DeserializeObject<UxiUsuariosEE>(strDataJson);
            obj.isAutenticated = true;
            return obj;
        }
    }
}