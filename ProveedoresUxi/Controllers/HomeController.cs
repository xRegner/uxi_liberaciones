using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProveedoresUxi.Helpers;
using UxiEntities;
using UXiModel;

namespace ProveedoresUxi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int sesionUsr = 0; 
            List<OrdenDeCompra> ODCS = new List<OrdenDeCompra>();
            try
            {
                sesionUsr = Session["UserID"].ToString() != "" ? Convert.ToInt16(Session["UserID"].ToString()) : 0;

                if (sesionUsr != 0)
                {
                    Affiliate aff = new Affiliate();
                    ViewData["listEstatus"] = aff._listaEstatus();
                }     
                else
                {
                return RedirectToAction("Index","Index");
                }
            }
            catch {
                return RedirectToAction("Index", "Index");

            }
                    
            

            return View(ODCS);
        }

        [HttpPost]
        public ActionResult Index(string date, int ide, string idoc)
        {
            int sessionUsr = 0;
            date = (date != "" ? date : "00010101");
            idoc = (idoc != "" ? idoc : "0");
            List<OrdenDeCompra> ODCS = new List<OrdenDeCompra>();
            Affiliate aff = new Affiliate();

            try
            {
                sessionUsr = Session["UserID"].ToString() != "" ? Convert.ToInt16(Session["UserID"].ToString()) : 0;
                if (sessionUsr != 0)
                {
                    ODCS = aff.getListaOrdenes(IdOrdenCompra: idoc, FechaOrden: date);

                    if (ide != 0)
                    {
                        ODCS = (from o in ODCS where o.IdEstatusOC == ide select o).ToList();
                    }

                    //using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                    //{
                    //    ODCS = (from o in ODCS
                    //            join rp in context.TblRelacionPedimento on o.IdOrdenCompra equals rp.IdOrdenCompra
                    //            join p in context.TblProductos on rp.IdProducto equals p.IdProducto
                    //            where p.IdCategoria == 1
                    //            select o).Distinct().ToList();
                    //}
                }
                else
                {
                    return RedirectToAction("Index", "Index");
                }                
            }
            catch
            {
                return RedirectToAction("Index", "Index");
            }
            
            return PartialView("_listaOrdenes",ODCS);
        }

        public ActionResult _detalleOrden(int idoc, int ide)
        {
            int sessionUsr = 0;
            Affiliate aff = new Affiliate();
            OrdenDeCompraDetalle detail = new OrdenDeCompraDetalle();

            try
            {
                sessionUsr = Session["UserID"].ToString() != "" ? Convert.ToInt16(Session["UserID"].ToString()) : 0;
                if (sessionUsr != 0)
                {
                    detail = aff.getOrdenDetail(idoc);

                    ViewData["listEstatus"] = (from e in aff._listaEstatus() where e.IdEstatusOC != 5 select e).ToList();
                }
                else
                {
                    return RedirectToAction("Index", "Index");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Index");
            }

            return PartialView(detail);
        }
        [HttpPost]
        public ActionResult _detalleOrden(OrdenDeCompraDetalle Detail)
        {
            Affiliate aff = new Affiliate();

            if (aff.updOrdenStatus(idoc: Detail.IdOrdenCompra, ide: Detail.IdEstatus))
            {
                var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Home");
                return Json(new { Url = redirectUrl });
            }

            ViewData["listEstatus"] = (from e in aff._listaEstatus() where e.IdEstatusOC != 5 select e).ToList();

            return PartialView(Detail);
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
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

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
