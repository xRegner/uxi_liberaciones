using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using Newtonsoft.Json;
using UxiEntities;

namespace MvcApplication1.Helpers
{
    public class AdmUsrCs
    {
        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public List<USP_GetUsuarioCuenta_EE> ListaUsuarios()
        {
            List<USP_GetUsuarioCuenta_EE> resultado = new List<USP_GetUsuarioCuenta_EE>();
            var baseAddress = api + "api/UsuariosAdm/";
            using (var wb = new WebClient())
            {

                WebClient webClient = new WebClient();
               // webClient.QueryString.Add("tipoCliente", _tipousr);
                string result = webClient.DownloadString(baseAddress);
                resultado = ProcessDataJson(result);
            }
            return resultado;

        }

        private List<USP_GetUsuarioCuenta_EE> ProcessDataJson(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            List<USP_GetUsuarioCuenta_EE> obj = new List<USP_GetUsuarioCuenta_EE>();
            obj = JsonConvert.DeserializeObject<List<USP_GetUsuarioCuenta_EE>>(strDataJson);
            return obj;
        }

        public void ActualizaUsuarioCuenta(int idUsuario, int idtipoCliente, decimal saldo, bool verTarifas)
        {
            var baseAddress = api + "api/UsuariosAdm/";
            using (var wb = new WebClient())
            {
                var dataw = new NameValueCollection();
                dataw["IdUsuario"] = idUsuario.ToString();
                dataw["TipoCliente"] = idtipoCliente.ToString();
                dataw["saldoafavor"] = saldo.ToString();
                dataw["VerTarifas"] = verTarifas.ToString();

                var responser = wb.UploadValues(baseAddress, "POST", dataw);

                string s = wb.Encoding.GetString(responser);            
            }

        }
    }


}