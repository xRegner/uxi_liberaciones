using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UXiModel;
using UxiEntities;

namespace AffiliateUXI.Controllers
{
    public class MensajesOrdenesController : ApiController
    {
        private uxisolutionbdEntities db = new uxisolutionbdEntities();

        // GET: api/MensajesOrdenes
        public IQueryable<MensajesOrdenes> GetMensajesOrdenes()
        {
            return db.MensajesOrdenes;
        }

        // GET: api/MensajesOrdenes/5
        [ResponseType(typeof(MensajesOrdenes))]
        public List<Mensaje> GetMensajesOrdenes(int id)
        {

            List<Mensaje> listMensaje = new List<Mensaje>();
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                listMensaje = (from obj in context.sp_getMensajesOrdenes(id)
                               select new Mensaje()
                               {
                                   IdUsuario = obj.IdUsuario,
                                   MensajeText = obj.Mensaje,
                                   FechaAlta = obj.Fecha_Alta,
                                   ApPaterno = obj.ApPaterno,
                                   Nombre = obj.Nombre
                               }).OrderBy(x=> x.FechaAlta).ToList();
                //listOrdenes.AddRange(query);
            }

            return listMensaje;
        }

      
        // POST: api/MensajesOrdenes
        [ResponseType(typeof(MensajesOrdenes))]
        public IHttpActionResult PostMensajesOrdenes(MensajesOrdenes mensajesOrdenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            mensajesOrdenes.Fecha_Alta = DateTime.Now;
            db.MensajesOrdenes.Add(mensajesOrdenes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MensajesOrdenesExists(mensajesOrdenes.IdMensaje))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mensajesOrdenes.IdMensaje }, mensajesOrdenes);
        }

        // DELETE: api/MensajesOrdenes/5
        [ResponseType(typeof(MensajesOrdenes))]
        public IHttpActionResult DeleteMensajesOrdenes(int id)
        {
            MensajesOrdenes mensajesOrdenes = db.MensajesOrdenes.Find(id);
            if (mensajesOrdenes == null)
            {
                return NotFound();
            }

            db.MensajesOrdenes.Remove(mensajesOrdenes);
            db.SaveChanges();

            return Ok(mensajesOrdenes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensajesOrdenesExists(int id)
        {
            return db.MensajesOrdenes.Count(e => e.IdMensaje == id) > 0;
        }
    }
}