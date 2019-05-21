using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace MvcApplication1.Helpers
{
    public class SaldosHelp
    {
        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public decimal getMonto(string idUsuario)
        {

            decimal resultado = 0;
            // Create a request using a URL that can receive a post. 
            var baseAddress = api + "api/Helper/";

            WebClient webClient = new WebClient();
            webClient.QueryString.Add("idUsuario", idUsuario.ToString());
            string result = webClient.DownloadString(baseAddress);
            resultado = Convert.ToDecimal(result);

            
            return resultado;
        }
    }
}