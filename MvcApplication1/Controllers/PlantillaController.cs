using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class PlantillaController : Controller
    {
        //
        // GET: /Plantilla/

        public ActionResult Plantilla()
        {
            List<Producto> productos = new List<Producto>()
            {

            new Producto {Codigo = 1, Descripcion = "Descripción 1", Nombre = "Producto 1", Precio = 100m},
            new Producto {Codigo = 2, Descripcion = "Descripción 2", Nombre = "Producto 2", Precio = 200m},
            new Producto {Codigo = 3, Descripcion = "Descripción 3", Nombre = "Producto 3", Precio = 300m},
            new Producto {Codigo = 4, Descripcion = "Descripción 4", Nombre = "Producto 4", Precio = 400m}
            };
            return View(productos);
        }

    }
}
