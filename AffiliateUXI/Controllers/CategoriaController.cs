using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;
using UxiEntities;

namespace AffiliateUXI.Controllers
{
    public class CategoriaController : ApiController
    {
       
        // GET: api/Categoria/5
        public List<Categoria> Get()
        {
            List<Categoria> listC = new List<Categoria>();
            
            using(uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = (from c in context.TblCategoria  
                             select new Categoria
                             {
                                IdCategoria = c.IdCategoria ,
                                Descripcion = c.DescCategoria,
                                Activo = c.Activo 
                             });
                listC.AddRange(query);
            }

            return listC;
        }

        // POST: api/Categoria
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categoria/5
        public void Delete(int id)
        {
        }
    }
}
