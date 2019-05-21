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
    public class RegistroNuevoUsuario
    {

        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public bool RegistraUsuario(string mail)
        {

            bool resultado = false;

            // Create a request using a URL that can receive a post. 
            var baseAddress = api + "api/Helper/";

            using (var wb = new WebClient())
            {
                var dataw = new NameValueCollection();
                dataw["email"] = mail;

                var responser = wb.UploadValues(baseAddress, "POST", dataw);

                string s = wb.Encoding.GetString(responser);

                resultado = Convert.ToBoolean(s);
            }


            return resultado;


        }
    }
}