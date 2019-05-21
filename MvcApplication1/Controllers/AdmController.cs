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

    public class AdmController : Controller
    {


        int sesionUsr = 0;
        string nombre = string.Empty;
        string tipousr = string.Empty;

        SeguridadUsr seguridad = new SeguridadUsr();
        //
        // GET: /Adm/

        public ActionResult Index()
        {

            try
            {
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {

                    nombre = Session["Nombre"].ToString();
                    tipousr = Session["tipoUSR"].ToString();

                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());

                    if (Usuario.isAutenticated == true && Usuario.IdRol == 2) return View();
                    else return View("Acceso");

                }


            }
            catch
            {
                return View("Acceso");
            }

            return View();




        }
        public ActionResult Usuarios()
        {


            try
            {
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {

                    nombre = Session["Nombre"].ToString();
                    tipousr = Session["tipoUSR"].ToString();

                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());

                    if (Usuario.isAutenticated == true && Usuario.IdRol == 2)
                    {
                        AdmUsrCs listUsr = new AdmUsrCs();
                        List<USP_GetUsuarioCuenta_EE> ListaResult = new List<USP_GetUsuarioCuenta_EE>();
                        ListaResult = listUsr.ListaUsuarios();


                        return View(ListaResult);
                    }
                    else return View("Acceso");

                }


            }
            catch
            {
                return View("Acceso");
            }

            return View();

        }



        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult actualizaUsuario(int idUsuario, int IdTipo, decimal saldo, bool verTarifas)
        {
            AdmUsrCs obj = new AdmUsrCs();
            obj.ActualizaUsuarioCuenta(idUsuario, IdTipo, saldo, verTarifas);
            return Json("");
        }

        public ActionResult Ordenes()
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
                        string idUsuario = Session["idusuario"].ToString();

                        OrdenesUsuario _ordenesUsuario = new OrdenesUsuario();
                        //List<OrdenDeCompra> ordenesUsuario = new List<OrdenDeCompra>();
                        //ordenesUsuario = _ordenesUsuario.ListaOrdenes("0");

                        //obtiene la lista de estatus de las ordenes
                        ListaEstatus _estatusOrden = new ListaEstatus();
                        List<UxiEntities.EstatusOrden> listaEstatus = new List<UxiEntities.EstatusOrden>();
                        listaEstatus = _estatusOrden._listaEstatus();

                        nombre = Session["Nombre"].ToString();
                        ViewData["EstatusOrden"] = listaEstatus;
                        //ViewData["Ordenes"] = ordenesUsuario;
                        ViewBag.idUsuario = idUsuario;
                        ViewBag.NombreUsuario = nombre;

                        return View();
                       
                    }
                    return RedirectToAction("index");

                }


            }
            catch (Exception e)
            {
                return View("index");
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Ordenes(string altField,string altFieldHasta, int estatus,string ordenCompra,string email)
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
                        int IdOrden = 0;
                        string idUsuario = Session["idusuario"].ToString();
                        IdOrden = (ordenCompra == "" ? 0 : Convert.ToInt32(ordenCompra)) ;
                        altField = (altField == "" ? "00010101" : altField);
                        altFieldHasta = (altFieldHasta == "" ? "00010101" : altFieldHasta);
                        OrdenesUsuario _ordenesUsuario = new OrdenesUsuario();
                        List<OrdenDeCompra> ordenesUsuario = new List<OrdenDeCompra>();
                        ordenesUsuario = _ordenesUsuario.ListaOrdenes(IdOrden, altField, altFieldHasta,0, email);
                        if (estatus!=0)
                        {
                            ordenesUsuario = (from s in ordenesUsuario
                                      where s.IdEstatusOC == estatus
                                      select s).ToList();
                        }
                        //obtiene la lista de estatus de las ordenes
                        ListaEstatus _estatusOrden = new ListaEstatus();
                        List<UxiEntities.EstatusOrden> listaEstatus = new List<UxiEntities.EstatusOrden>();
                        listaEstatus = _estatusOrden._listaEstatus();

                        nombre = Session["Nombre"].ToString();
                        ViewData["EstatusOrden"] = listaEstatus;
                        ViewData["Ordenes"] = ordenesUsuario;
                        ViewBag.idUsuario = idUsuario;
                        ViewBag.NombreUsuario = nombre;

                        //return View();
                        return PartialView("_OrdenesAdm");
                    }
                    return RedirectToAction("index");

                }


            }
            catch (Exception e)
            {
                return View("index");
            }
            return View();
        }

        public ActionResult Servicios(int? ido)
        {
            List<Servicios> servicios = new List<Servicios>();
            Message msg = new Message();
            ListaServicios listServicios = new ListaServicios();
            try
            {
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {
                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());
                    if (Usuario.isAutenticated == false)
                    {
                        return View("Acceso");
                    }
                    
                    ViewData["listCategoria"] = listServicios.getCategorias();
                    if (ido == null)
                    {
                        msg.hasMessage = false;
                    }
                    else 
                    {
                        msg.hasMessage = true;
                        msg.strMessage = ido == 1 ? "¡Se agrego el servicio correctamente!" : "¡Se actualizo el servicio correctamente!";                        
                    }
                    ViewBag.Message = msg;
                }
            }
            catch
            {
                return View("Acceso");
            }
            
            return View(servicios);
        }
        [HttpPost]
        public ActionResult Servicios(string sta, string des, string idc)
        {
            List<Servicios> servicios = new List<Servicios>();
            ListaServicios listServicios = new ListaServicios();
            try
            {
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {
                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());
                    if (Usuario.isAutenticated == false)
                    {
                        return View("Acceso");
                    }
                    servicios = listServicios.getListaServicios(idc: idc, act: sta);
                    if (des != "")
                    {
                        servicios = (from s in servicios where s.Descripcion_Corta.Contains(des) select s).ToList();
                    }                            
                }
            }
            catch
            {
                return View("Acceso");
            }
            return PartialView("_listaServicios", servicios);
        }

        public ActionResult _detalleServicio(int? ids)
        {
            ListaServicios listServicios = new ListaServicios();
            Servicios servicio = listServicios.getDetalleServicio(ids: ids);
            ViewData["listCategoria"] = listServicios.getCategorias();
            return PartialView(servicio);
        }

        [HttpPost]
        public ActionResult _detalleServicio(Servicios ser)
        {
            ListaServicios listServicios = new ListaServicios();
            ViewData["listCategoria"] = listServicios.getCategorias();
            if (ModelState.IsValid)
            {
               
                ser.UUM = int.Parse(Session["idusuario"].ToString());
                foreach (var precio in ser.Precios)
                {
                    switch (precio.Tipocliente)
                    {
                        case 1:
                            precio.Precio = ser.PrecioMayoristaPRO;
                            break;
                        case 2:
                            precio.Precio = ser.PrecioMayorista;
                            break;
                    }
                }
                
                if (listServicios.setDetalleServicios(ser: ser))
                {
                    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Servicios", "Adm", new { ido = 2 });
                    return Json(new { Url = redirectUrl });
                }
            }
                
           
            return PartialView(ser);
        }

        public ActionResult _agregarServicio()
        {
            ListaServicios listServicios = new ListaServicios();
            Servicios ser = new Servicios();
            ViewData["listCategoria"] = listServicios.getCategorias();
            return PartialView(ser);
        }

        [HttpPost]
        public ActionResult _agregarServicio(Servicios ser)
        {
            ListaServicios listServicios = new ListaServicios();
            ViewData["listCategoria"] = listServicios.getCategorias();
            if (ModelState.IsValid)
            {
                ser.UUM = int.Parse( Session["idusuario"].ToString());
                List<Servicio_Precio_TipoUsuario> ListSerPreUsu = new List<Servicio_Precio_TipoUsuario>();
                ListSerPreUsu.Add(new Servicio_Precio_TipoUsuario()
                {
                    Tipocliente = 1,
                    Precio = ser.PrecioMayoristaPRO
                });
                ListSerPreUsu.Add(new Servicio_Precio_TipoUsuario()
                {
                    Tipocliente = 2,
                    Precio = ser.PrecioMayorista
                });
                ser.Precios = ListSerPreUsu;
                if (listServicios.addService(ser:ser))
                {
                    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Servicios", "Adm", new { ido = 1});
                    return Json(new { Url = redirectUrl });
                }
            }            
            
            return PartialView(ser);
        }

        public ActionResult _reporteOrden (string altField, string altFieldHasta, int estatus, string ordenCompra, string email)
        {
            try
            {
                //string altField, string altFieldHasta, int estatus, string ordenCompra, string email
                sesionUsr = Session["idusuario"].ToString() != "" ? Convert.ToInt16(Session["idusuario"].ToString()) : 0;

                if (sesionUsr != 0)
                {

                    UxiUsuariosEE Usuario = new UxiUsuariosEE();
                    Usuario = seguridad.Usuario(sesionUsr.ToString());
                    if (Usuario.isAutenticated == true)
                    {
                        int IdOrden = 0;
                        string idUsuario = Session["idusuario"].ToString();
                        IdOrden = (ordenCompra == "" ? 0 : Convert.ToInt32(ordenCompra));
                        altField = (altField == "" ? "00010101" : altField);
                        altFieldHasta = (altFieldHasta == "" ? "00010101" : altFieldHasta);
                        OrdenServicios _ordenesServicios = new OrdenServicios();
                        List<OrdenServicioDetalle> ordenesUsuario = new List<OrdenServicioDetalle>();
                        ordenesUsuario = _ordenesServicios.ListaOrdenesServicios(IdOrden, altField, altFieldHasta, 0, "");
                        var ordenesNoCanceladas = from x in ordenesUsuario where x.IdEstatusOC != 5 select x;
                        if (estatus != 0)
                        {
                            ordenesUsuario = (from s in ordenesUsuario
                                              where s.IdEstatusOC == estatus
                                              select s).ToList();
                        }
                        //obtiene la lista de estatus de las ordenes
                        var OrdenesAgrupadas = (from p in ordenesNoCanceladas group p by p.IdProducto into groupProduct select groupProduct).ToList(); 

                        ListaEstatus _estatusOrden = new ListaEstatus();
                        List<UxiEntities.EstatusOrden> listaEstatus = new List<UxiEntities.EstatusOrden>();
                        listaEstatus = _estatusOrden._listaEstatus();

                        nombre = Session["Nombre"].ToString();
                        ViewData["EstatusOrden"] = listaEstatus;
                        ViewData["Ordenes"] = ordenesUsuario;
                        ViewData["OrdenesAgrupadas"] = OrdenesAgrupadas;
                        ViewBag.idUsuario = idUsuario;
                        ViewBag.NombreUsuario = nombre;

                        HttpContext.Response.Buffer = true;
                        Response.Clear();
                        HttpContext.Response.ContentType = "application/vdn.ms-excel";
                        Response.AddHeader("Content-Disposition","attachment; filename= UxiOrdenes.xls");
                        return PartialView("_ReporteOrdenes");
                    }
                    return RedirectToAction("index");

                }


            }
            catch (Exception e)
            {
                return View("Acceso");
            }
            return PartialView("_ReporteOrdenes");
        }

     
    }

}
