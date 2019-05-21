using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;
using MvcApplication1.Helpers;
using UxiEntities;
using System.Configuration;
using System.Net;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        SeguridadUsr seguridad = new SeguridadUsr();
        int sesionUsr = 0;
        string nombre = string.Empty;
        string tipousr = string.Empty;
        public ActionResult Index()
        {
            try
            {
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {

                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());
                    if (Usuario.isAutenticated == true)
                    {
                        SaldosHelp saldos = new SaldosHelp();

                        nombre = Session["Nombre"].ToString();
                        tipousr = Session["tipoUSR"].ToString();
                        List<Servicios> listaSer = new List<Servicios>();
                        ListaServicios _objCatSerrvices = new ListaServicios();
                        listaSer = _objCatSerrvices.ListarCatServices(tipousr,Usuario.VerTarifas.ToString());
                        ViewBag.Servicios = new SelectList(listaSer, "IdProducto", "Descripcion_Larga");
                        ViewBag.MontoUsr = saldos.getMonto(Session["idusuario"].ToString());
                        ViewBag.NombreUsuario = nombre;
                        ViewBag.IdUsuario = sesionUsr.ToString();

                        if (Usuario.IdRol == 2)
                        {
                            ViewBag.Tipousr = true;
                        }
                        else ViewBag.Tipousr = false;

                        return View();
                    }
                }

                else
                {
                    return RedirectToAction("index");
                }
            }
            catch {
                return View("Acceso");
            }
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetServicio(int idProd)
        {

            tipousr = Session["tipoUSR"].ToString();
            List<Servicios> listaSer = new List<Servicios>();
            ListaServicios _objCatSerrvices = new ListaServicios();

            listaSer = _objCatSerrvices.ListarCatServices(tipousr, Session["verTarifas"].ToString());

            var lista = from i in listaSer
                        where i.IdProducto == idProd
                        select i;



            return Json(lista);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetHistorialSaldo(string altField, string altFieldHasta, int daym )
        {
            int UsarioLog = 0;
            UsarioLog = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;
         
            tipousr = Session["tipoUSR"].ToString();
            List<Saldos> HistorialList = new List<Saldos>();
            ListaServicios _objCatSerrvices = new ListaServicios();
            altField = (altField == "" ? "" : altField);
            altFieldHasta = (altFieldHasta == "" ? "" : altFieldHasta);
            HistorialList = _objCatSerrvices.ListarHistorialSaldos(UsarioLog, altField, altFieldHasta, daym);
            ViewData["HistorialMOV"] = HistorialList;
            
            return Json(HistorialList);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetHistorialSaldoUsr(int idusuario, string altField, string altFieldHasta, int daym)
        {
            int UsarioLog = 0;
            UsarioLog = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

            tipousr = Session["tipoUSR"].ToString();
            List<Saldos> HistorialList = new List<Saldos>();
            ListaServicios _objCatSerrvices = new ListaServicios();
            altField = (altField == "" ? "" : altField);
            altFieldHasta = (altFieldHasta == "" ? "" : altFieldHasta);
            HistorialList = _objCatSerrvices.ListarHistorialSaldos(idusuario, altField, altFieldHasta, daym);
            ViewData["HistorialMOV"] = HistorialList;

            return Json(HistorialList);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult InsertaOrdenServicio(double total )
        {
            int UsarioLog = 0;
            UsarioLog = Session["idusuario"].ToString() !="" ?  Convert.ToInt16( Session["idusuario"].ToString()): 0;
            OrdenDeCompra obj = new OrdenDeCompra();

            if(UsarioLog !=0)
            {
                OdcIni oebj = new OdcIni();
                obj = oebj.Odc(UsarioLog, total);
            }
            
            return Json(obj);
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult InsertaOrdenServicioDetalle(int _odc,decimal _monto, int _idProd, string _Imei, string _sku)
        {
            int UsarioLog = 0;
            UsarioLog = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;
            TblRelacionPedimento obj = new TblRelacionPedimento()
            {
                IdOrdenCompra = _odc,
                Total = _monto,
                UUM= UsarioLog,
                FechaPedimento = DateTime.Now.Date,
                FUM = DateTime.Now.Date,
                IdDescuento = 0,
                IdEstatusPedimento = 1,
                IdProducto = _idProd,
                IMEI = _Imei,
                PrecioNeto = _monto,
                PrecioVenta =_monto,
                SKU = _sku
                
            };
            OdcIni Getresponse = new OdcIni();


            if (UsarioLog != 0)
            {
                obj = Getresponse.OdcDetalle(obj);             
            }


            return Json(obj);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult InsertOrderRequest(string request)
        {
            int idUser = Session["idusuario"].ToString() != "" ? Convert.ToInt32(Session["idusuario"].ToString()) : 0;
            OdcIni Getresponse = new OdcIni();
            if (idUser != 0)
            {
                request = Getresponse.InsertOrderRequest(request.TrimEnd('|'), idUser);
            }

            return Json(request);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult InsertaMandaMail(int _odc)
        {
            string api = ConfigurationManager.AppSettings["apiUX"].ToString();
            
            // Create a request using a URL that can receive a post. 
            var baseAddress = api + "api/DetalleODC/";

            WebClient webClient = new WebClient();
            webClient.QueryString.Add("idOdc", _odc.ToString());
            string result = webClient.DownloadString(baseAddress);
           
            return Json(result);
        }




        public ActionResult CloseSesion()
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();

            Session.Remove("idusuario");
            Session.Remove("Nombre");
            return RedirectToAction("index", "index");
        }


        public ActionResult MiCuenta()
        {

            try
            {
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {

                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());
                    if (Usuario.isAutenticated == true )
                    {
                        SaldosHelp saldos = new SaldosHelp();

                        nombre = Session["Nombre"].ToString();
                        tipousr = Session["tipoUSR"].ToString();

                        List<Servicios> listaSer = new List<Servicios>();
                        ListaServicios _objCatSerrvices = new ListaServicios();
                        listaSer = _objCatSerrvices.ListarCatServices(tipousr,Usuario.VerTarifas.ToString());
                        ViewBag.Servicios = new SelectList(listaSer, "IdProducto", "Descripcion_Larga");
                        ViewBag.MontoUsr = saldos.getMonto(Session["idusuario"].ToString());
                        ViewBag.NombreUsuario = nombre;
                        ViewBag.IdUsuario = sesionUsr.ToString();

                        if (Usuario.IdRol == 2)
                        {
                            ViewBag.Tipousr = true;
                        }
                        else ViewBag.Tipousr = false;

                        return View();
                    }
                    return RedirectToAction("index");

                }


            }
            catch
            {
                return View("Acceso");
            }

            return View();
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MisPedidos()
        {
            try
            {
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {

                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());
                    if (Usuario.isAutenticated == true)
                    {
                        string idUsuario =Session["idusuario"].ToString();
                        OrdenesUsuario _ordenesUsuario = new OrdenesUsuario();
                        ListaEstatus _estatusOrden = new ListaEstatus();

                        //List<OrdenDeCompra> ordenesUsuario = new List<OrdenDeCompra>();
                        //ordenesUsuario = _ordenesUsuario.ListaOrdenes(idUsuario);

                        List<UxiEntities.EstatusOrden> listaEstatus = new List<UxiEntities.EstatusOrden>();
                        listaEstatus = _estatusOrden._listaEstatus();

                        nombre = Session["Nombre"].ToString();
                        ViewData["EstatusOrden"] = listaEstatus;
                        //ViewData["Ordenes"] = ordenesUsuario;
                        ViewBag.idUsuario = idUsuario;
                        ViewBag.NombreUsuario = nombre;
                        if (Usuario.IdRol == 2)
                        {
                            ViewBag.Tipousr = true;
                        }
                        else ViewBag.Tipousr = false;


                        return View();
                    }
                    return RedirectToAction("index");

                }


            }
            catch(Exception e)
            {
                return View("Acceso");
            }

            return View();
        }

    }
}
