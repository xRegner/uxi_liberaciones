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
    public class OdcIni
    {
        string api = ConfigurationManager.AppSettings["apiUX"].ToString();
        public OrdenDeCompra Odc(int idusuario, double total)
        {
            OrdenDeCompra oddc = new OrdenDeCompra();
            var baseAddress = api + "api/OrdenService";
            WebClient wc = new WebClient();

            wc.QueryString.Add("Usuario.IdUsuario", idusuario.ToString());
            wc.QueryString.Add("Total", total.ToString());

            var query = wc.UploadValues(baseAddress, "POST", wc.QueryString);

            // data here is optional, in case we recieve any string data back from the POST request.
            var responseString = UnicodeEncoding.UTF8.GetString(query);
            oddc = ProcessDataJson(responseString);
            return oddc;
        }

        private OrdenDeCompra ProcessDataJson(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            OrdenDeCompra obj = new OrdenDeCompra();
            obj = JsonConvert.DeserializeObject<OrdenDeCompra>(strDataJson);
            return obj;
        }

        public UxiEntities.TblRelacionPedimento OdcDetalle(UxiEntities.TblRelacionPedimento _pedido)
        {
            var baseAddress = api + "api/DetalleODC";

            TblRelacionPedimento resultado = new TblRelacionPedimento();
            WebClient wc = new WebClient();

            wc.QueryString.Add("IdOrdenCompra", _pedido.IdOrdenCompra.ToString());
            wc.QueryString.Add("IdProducto", _pedido.IdProducto.ToString());
            wc.QueryString.Add("SKU", _pedido.SKU.ToString());
            wc.QueryString.Add("PrecioNeto", _pedido.PrecioNeto.ToString());
            wc.QueryString.Add("PrecioVenta", _pedido.PrecioVenta.ToString());
            wc.QueryString.Add("IdDescuento", _pedido.IdDescuento.ToString());
            wc.QueryString.Add("Total", _pedido.Total.ToString());
            wc.QueryString.Add("FechaPedimento", _pedido.FechaPedimento.ToString());
            wc.QueryString.Add("IdEstatusPedimento", _pedido.IdEstatusPedimento.ToString());
            wc.QueryString.Add("IMEI", _pedido.IMEI.ToString());
            
            var query = wc.UploadValues(baseAddress, "POST", wc.QueryString);

            // data here is optional, in case we recieve any string data back from the POST request.
            var responseString = UnicodeEncoding.UTF8.GetString(query);
            resultado = ProcessDataJsonPedido(responseString);
            return _pedido;

        }

        public string InsertOrderRequest(string request, int idUser)
        {
            OrdenDeCompra oddc = new OrdenDeCompra();
            var baseAddress = api + "api/OrdenService";
            WebClient wc = new WebClient();

            wc.QueryString.Add("Usuario.IdUsuario", idUser.ToString());
            wc.QueryString.Add("Request", request);

            var query = wc.UploadValues(baseAddress, "POST", wc.QueryString);

            // data here is optional, in case we recieve any string data back from the POST request.
            var responseString = UnicodeEncoding.UTF8.GetString(query);
            oddc = ProcessDataJson(responseString);
            return request;

        }


        private TblRelacionPedimento ProcessDataJsonPedido(string strDataJson)
        {
            /*var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(strDataJson); */
            TblRelacionPedimento obj = new TblRelacionPedimento();
            obj = JsonConvert.DeserializeObject<TblRelacionPedimento>(strDataJson);
            return obj;
        }
    }
}