using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UXiModel;
using AffiliateUXI.Afiliados_BLL;

namespace AffiliateUXI.Controllers
{
    public class ValuesController : ApiController
    {
        



        // POST api/values
       
        public UXI_Usuarios Post(UXI_Usuarios _usuario)
        {


            //TODO: Mandar Correo


            //TODO: Verifiar al usuario
            bool existeUsuario = false;
            AfiilateUtilidades verifica = new AfiilateUtilidades();
            existeUsuario = verifica.VerificaUsuario(_usuario.Email);

            UXI_Usuarios usuario = new UXI_Usuarios()
            {
                Activo = false,
                ApMaterno = _usuario.ApMaterno,
                ApPaterno = _usuario.ApPaterno,
                Email = _usuario.Email,
                IdRol = 1,   // este campo es temporal hasta tener un enum definido
                Nombre = _usuario.Nombre,
                Password = _usuario.Password,
                Telefono = _usuario.Telefono,
                TipoCliente = 3, // este campo es temporal hasta tener un enum definido Mayorista minorista etc
                FUM = DateTime.Now.Date,
                UUM = 1, // este campo es temporal hasta tener un enum definido
                VerTarifas =false
            };

            if (!existeUsuario)
            {
                string _StrinQ = string.Empty;



                EnviarCorreo objEnviaMail = new EnviarCorreo();


                if (!existeUsuario)
                {
                   
                    using (uxisolutionbdEntities context = new uxisolutionbdEntities())
                    {
                        context.UXI_Usuarios.Add(usuario);
                        context.SaveChanges();
                    }

                    CreaQueryS objQuery = new CreaQueryS();
                    _StrinQ = objQuery.ArmaQuery(usuario.IdUsuario, usuario.Email);

                    p_correoE mail = new p_correoE()
                    {
                        sFrom = "noreply@uxisolutions.com",
                        sTo = usuario.Email,
                        sSubject = "Nuevo Usuario",
                        sBody = " <p><h1>¡Estas apunto de terminar tu registro! solo da click en el siguinte link</h1></p><p>" + _StrinQ + " </p> "

                    };
                    objEnviaMail.EnviarEmail(mail);

                }

            }
            return usuario;
        }




    }
}
