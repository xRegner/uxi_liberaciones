using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Helpers;
using System.Configuration;

namespace MvcApplication1.Controllers
{
    public class indexController : Controller
    {
        //
        // GET: /index/
        public ActionResult Index()
        {
            ViewBag.Msj = true;
            return View();
        }

        [HttpPost]
        public ActionResult EjemploForm(Producto lib)
        {
            
            lib.Nombre += " test"; // esto es para que veais que se modifica, si no parece que no haga nada...
            //Response.Redirect("index");
            ModelState.Clear();
            return Json(lib.Nombre);
        }

        public ActionResult Afiliate()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Acceso()
        {
            string  id = Request.QueryString["45932EE"];
            

            if (id != null)
            {
                bool usuarioactivo = false;
                RegistroNuevoUsuario _registroNuevoUsuario = new RegistroNuevoUsuario();
                usuarioactivo = _registroNuevoUsuario.RegistraUsuario(id);
                ViewBag.UsuarioLeido = usuarioactivo;
                
            }
            else
            {
                ViewBag.UsuarioLeido = false;
            }
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public  ActionResult SessionA(string id, string nombre, string tipoUSR, string verTarifas)
        {
            Session["idusuario"] = id;
            Session["Nombre"] = nombre;
            Session["tipoUSR"] = tipoUSR;
            Session["verTarifas"] = verTarifas;
            if (id != "0")
            {

                return this.Json(new { success = true });
            }
            else
            {
                return View();
            }
         
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ContactameIN(string email, string phone, string Message)
        {
            bool resultado = true;
            SendMail objEnviaMail = new SendMail();
            try
            {
                p_correoE mail = new p_correoE()
                {
                    sFrom = "noreply@uxisolutions.com",
                    sTo = email,
                    //sToCC = email,
                    sSubject = "Contacto",
                    sBody = Message

                };
                objEnviaMail.EnviarEmail(mail);
                resultado = false;
                ViewBag.Msj = resultado;
            }
            catch
            {
                resultado = true;
            }


            return View("index");

        }


    }


}
