using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class EjemploFormController : Controller
    {
        //
        // GET: /EjemploForm/

        public ActionResult EjemploForm()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EjemploForm(Producto lib)
        {
            lib.Nombre += " test"; // esto es para que veais que se modifica, si no parece que no haga nada...
            //Response.Redirect("index");
            return View("index", new { id = lib.Nombre });
        }

    }
}
