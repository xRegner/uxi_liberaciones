using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;
using AffiliateUXI.Afiliados_BLL;
using System.Configuration;

namespace AffiliateUXI.Controllers
{
    public class HelperController : ApiController
    {


        // GET: api/Helper/5
        public decimal Get(int idUsuario)
        {
            CuentaUsuario resultado = new CuentaUsuario();
            try
            {
                using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                {

                    resultado = context.CuentaUsuario.First(i => i.IdUsuario == idUsuario && i.Activo == true);
                }
            }
            catch{ resultado.SaldoAFavor = 0; }
                return (decimal)resultado.SaldoAFavor;
        }

        // POST: api/Helper
        public bool Post([FromBody]UXI_Usuarios usuario)
        {


            bool resultado = false;
            EnviarCorreo objEnviaMail = new EnviarCorreo();

            try
            {
                //Obtenemos el usuario original 
                UXI_Usuarios usuariooriginal = new UXI_Usuarios();
                using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                {
                    usuariooriginal = context.UXI_Usuarios.First(i => i.Email == usuario.Email && i.UUM !=0);


                    usuariooriginal.Activo = true;
                    context.SaveChanges();
                }

                p_correoE mail = new p_correoE()
                {
                    sFrom = "noreply@uxisolutions.com",
                    sTo = ConfigurationManager.AppSettings["EmailAdmin"].ToString(),
                    sSubject = "¡Nuevo registro de usuario!",
                    sBody = string.Format("<p><h2>El usuario {0} {1} con email {2} se ha registrado.<h2></p><p>Tiene pendiente la aprobación para ver costos.<p>", usuariooriginal.Nombre,usuariooriginal.ApPaterno,usuariooriginal.Email)
                };
                objEnviaMail.EnviarEmail(mail);

                resultado = true;
            }

            catch
            {
                resultado = false;
            }


            return resultado;
        }

        // PUT: api/Helper/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Helper/5
        public void Delete(int id)
        {
        }
    }
}
