using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using UxiEntities;

namespace ProveedoresUxi.Helpers
{
    public class Affiliate
    {
        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public List<EstatusOrden> _listaEstatus()
        {
            List<EstatusOrden> Estatus = new List<EstatusOrden>();
            var baseAddress = api + "api/Estatus/GetLista";
            using (var wb = new WebClient())
            {

                WebClient webClient = new WebClient();
                string result = webClient.DownloadString(baseAddress);
                Estatus = ProcessDataJson(result);
            }
            return Estatus;
        }

        public List<OrdenDeCompra> getListaOrdenes(string IdOrdenCompra, string FechaOrden)
        {
            List<OrdenDeCompra> Ordenes = new List<OrdenDeCompra>();
            var baseAddress = api + "api/OrdenService/GetList";
            using (var wc = new WebClient())
            {
                wc.QueryString.Add("IdOrdenCompra", IdOrdenCompra);
                wc.QueryString.Add("FechaOrdenD", FechaOrden);
                string _result = wc.DownloadString(baseAddress);
                Ordenes = ProcessDataJsonOrdenes(_result);
            }

            return Ordenes;
        }

        public OrdenDeCompraDetalle getOrdenDetail(int idoc)
        {
            OrdenDeCompraDetalle Detail = new OrdenDeCompraDetalle();
            var baseAddres = api + "api/OrdenService/GetDetail";
            using (var wc = new WebClient())
            {
                wc.QueryString.Add("IdOrdenCompra", idoc.ToString());
                string _result = wc.DownloadString(baseAddres);
                Detail = ProcessDataJsonDetail(_result);
            }

            return Detail;
        }

        public bool updOrdenStatus(int idoc, int ide)
        {
            bool isUpdate; 
            var baseAddress = api + "api/OrdenService/GETUpdateODS";
            using (var wc = new WebClient())
            {
                wc.QueryString.Add("id", idoc.ToString());
                wc.QueryString.Add("idStatus", ide.ToString());
                string _result = wc.DownloadString(baseAddress);
                isUpdate = ProcessDataJsonUpdate(_result);
            }

            return isUpdate;
        }

        private bool ProcessDataJsonUpdate(string strDataJson)
        {
            bool obj = new bool();
            obj = JsonConvert.DeserializeObject<bool>(strDataJson);
            return obj;
        }

        private List<EstatusOrden> ProcessDataJson(string strDataJson)
        {
            List<EstatusOrden> obj = new List<EstatusOrden>();
            obj = JsonConvert.DeserializeObject<List<EstatusOrden>>(strDataJson);
            return obj;
        }

        private List<OrdenDeCompra> ProcessDataJsonOrdenes(string strDataJson)
        {
            List<OrdenDeCompra> obj = new List<OrdenDeCompra>();
            obj = JsonConvert.DeserializeObject<List<OrdenDeCompra>>(strDataJson);
            return obj;
        }

        private OrdenDeCompraDetalle ProcessDataJsonDetail(string strDataJson)
        {
            OrdenDeCompraDetalle obj = new OrdenDeCompraDetalle();
            obj = JsonConvert.DeserializeObject<OrdenDeCompraDetalle>(strDataJson);
            return obj;
        }
    }
}