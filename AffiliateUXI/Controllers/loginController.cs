using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;

namespace AffiliateUXI.Controllers
{
    public class loginController : ApiController
    {
   
        // POST: api/login
        public UXI_Usuarios Post(UXI_Usuarios obj)
        {
            UXI_Usuarios resultado = new UXI_Usuarios();
            try
            {
                using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                {
                    resultado = context.UXI_Usuarios.First(i => i.Email == obj.Email && i.Password == obj.Password && i.Activo==true);
                }
            }
            catch(Exception ex)
            {
                resultado.Nombre = "ERROR";
            }

            return resultado;
        }

       
    }
}
