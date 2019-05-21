using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UXiModel;

namespace XML_DeveloperUI.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()

        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Index(UXiModel.UXI_Proveedores Prov)
        {
            if (ModelState.IsValid)
            {
                using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                {
                    var _prov = (from a in context.UXI_Proveedores where a.Email == Prov.Email && a.Password == Prov.Password select a).FirstOrDefault(); 
                    if (_prov != null)
                    {
                        Session["UserID"] = _prov.IdProveedor.ToString();
                        Session["UserName"] = _prov.Nombre.ToString() + " " + _prov.ApPaterno.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View(Prov);
            
        }

        // GET: Index/Create
        public ActionResult Create()
        {
                        return View();
        }

        // POST: Index/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Index/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Index/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Index/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
