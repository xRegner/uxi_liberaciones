using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AffiliateUXI.Afiliados_BLL;

namespace AffiliateUXI.Controllers
{
    public class MailController : ApiController
    {
        // GET: api/Mail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        public void Post([FromBody]p_correoE mail)
        {
            EnviarCorreo objEnviaMail = new EnviarCorreo();
            objEnviaMail.EnviarEmail(mail);
        }

        // PUT: api/Mail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mail/5
        public void Delete(int id)
        {
        }
    }
}
