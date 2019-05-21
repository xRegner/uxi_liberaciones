using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;
using AffiliateUXI.Afiliados_BLL;
using UxiEntities;

namespace AffiliateUXI.Controllers
{
    public class AdmPassController : ApiController
    {
        // GET: api/AdmPass
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/AdmPass/5
        public UxiUsuariosEE Get(int id)
        {
            UxiUsuariosEE resultado = new UxiUsuariosEE();
            try
            {
                using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                {
                    var query = from i in context.UXI_Usuarios
                                where i.IdUsuario == id && i.Activo == true
                                select new UxiUsuariosEE()
                                {
                                    Activo = i.Activo,
                                    isAutenticated = false,
                                    Nombre = i.Nombre,
                                    ApMaterno = i.ApMaterno,
                                    ApPaterno = i.ApPaterno,
                                    Email = i.Email,
                                    IdRol = i.IdRol,
                                    IdUsuario = i.IdUsuario,
                                    Telefono = i.Telefono,
                                    TipoCliente = i.TipoCliente,
                                    VerTarifas = i.VerTarifas
                                };
                    resultado = query.FirstOrDefault();

                }
            }
            catch
            {
                resultado.Nombre = "ERROR";
            }

            return resultado;
        }

        // POST: api/AdmPass
        public bool Post(string email)
        {
            EnviarCorreo objEnviaMail = new EnviarCorreo();
            bool resultado = false;
            UXI_Usuarios obj = new UXI_Usuarios();
            try
            {
                using(uxisolutionbdEntities context = new uxisolutionbdEntities())
                {
                    obj = context.UXI_Usuarios.First(i => i.Email == email);

                    if (obj.Email != "")
                    {
                        //envio correo
                        p_correoE mail = new p_correoE()
                        {
                            sFrom = "noreply@uxisolutions.com",
                            sTo = obj.Email,
                            sSubject = "Recordatorio de Password Uxi",
                            sBody = "Hola " + obj.Nombre + " Te recordamos que tu passwords es: " + obj.Password.ToString()

                        };
                        objEnviaMail.EnviarEmail(mail);


                        resultado = true;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                return false;
            }

            return resultado;
        }

        // PUT: api/AdmPass/5
        public bool Put(int id, string pass)
        {

            bool resultado = false;
            UXI_Usuarios usuario = new UXI_Usuarios();
            try
            {
                using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                {
                    usuario = context.UXI_Usuarios.First(i => i.IdUsuario == id && i.Activo == true);
                    usuario.Password = pass;
                    context.SaveChanges();
                    resultado = true;
                }
            }
            catch
            {
                resultado = false;
            }

            return resultado;
        }

        //// DELETE: api/AdmPass/5
        //public void Delete(int id)
        //{
        //}
    }
}
