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
using System.Net.Http;

namespace MvcApplication1.Helpers
{
    public class ListaServicios
    {
        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public List<Servicios> ListarCatServices(string _tipousr, string _verTarifas)
        {
            List<Servicios> resultado = new List<Servicios>();
            var baseAddress = api + "api/GetServices/";
            using (var wb = new WebClient())
            {

                WebClient webClient = new WebClient();
                webClient.QueryString.Add("tipoCliente", _tipousr);
                webClient.QueryString.Add("verTarifas", _verTarifas.ToString());
                string result = webClient.DownloadString(baseAddress);
                resultado = ProcessDataJson(result);
            }
            return resultado;

        }

        public List<Saldos> ListarHistorialSaldos(int idUsuario, string altField, string altFieldHasta, int daym)
        {
            List<Saldos> resultado = new List<Saldos>();
            var baseAddress = api + "api/Saldos/";
            using (var wb = new WebClient())
            {

                WebClient webClient = new WebClient();
                webClient.QueryString.Add("IdUsuario", idUsuario.ToString());
                webClient.QueryString.Add("sd", altField);
                webClient.QueryString.Add("ed", altFieldHasta);
                webClient.QueryString.Add("daym", daym.ToString());
                string result = webClient.DownloadString(baseAddress);
                resultado = ProcessDataJsonHistorialSaldos(result);
            }
            return resultado;

        }

        public List<Servicios> getListaServicios(string ids = "0", string idc = "0", string act = "")
        {
            List<Servicios> result = new List<Servicios>();
            var baseAddress = api + "api/ServiciosAdm";
            using (var wb=new WebClient())
            {
                WebClient webClient = new WebClient();
                webClient.QueryString.Add("ids", ids);
                webClient.QueryString.Add("idc", idc);
                webClient.QueryString.Add("act", act);
                string _result = webClient.DownloadString(baseAddress);
                result = ProcessDataJson(_result);
            }

            return result;
        }

        public Servicios getDetalleServicio(int? ids)
        {
            List<Servicios> list = new List<Servicios>();
            Servicios result = new Servicios();
            var baseAdress = api + "api/ServiciosAdm";
            using (var wb = new WebClient())
            {
                WebClient wc = new WebClient();
                wb.QueryString.Add("ids", ids.ToString());
                string _result = wb.DownloadString(baseAdress);
                list = ProcessDataJson(_result);
                result = list.FirstOrDefault();
            }
            return result;
        }

        public bool setDetalleServicios(Servicios ser)
        {
            var baseAdress = api + "api/ServiciosAdm";
            using (var wb = new HttpClient())
            {
                var putTask = wb.PutAsJsonAsync<Servicios>(baseAdress + "?ids=" + ser.IdProducto, ser);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

       public List<Categoria> getCategorias()
        {
            List<Categoria> result = new List<Categoria>();
            var baseAdress = api + "api/Categoria";
            using(var wc = new WebClient())
            {
                string _resultl = wc.DownloadString(baseAdress);
                result = ProcessDataJsonCat(_resultl);
            }
            return result;
        } 

        public bool addService(Servicios ser)
        {
            //Servicios result = new Servicios();
            var baseAdress = api + "api/ServiciosAdm";
            using (var wc = new HttpClient())
            {
                var _result = wc.PostAsJsonAsync<Servicios>(baseAdress, ser);
                _result.Wait();

                var result = _result.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
        private List<Servicios> ProcessDataJson(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            List<Servicios> obj = new List<Servicios>();
            obj = JsonConvert.DeserializeObject<List<Servicios>>(strDataJson);
            return obj;
        }
        private List<Saldos> ProcessDataJsonHistorialSaldos(string strDataJson)
        {

            //remplazar por la entidad de saldos
            List<Saldos> obj = new List<Saldos>();
            obj = JsonConvert.DeserializeObject<List<Saldos>>(strDataJson);
            return obj;
        }
        private List<Categoria > ProcessDataJsonCat(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            List<Categoria> obj = new List<Categoria>();
            obj = JsonConvert.DeserializeObject<List<Categoria>>(strDataJson);
            return obj;
        }

    }
}