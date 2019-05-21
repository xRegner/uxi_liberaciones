using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UXiModel;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace AffiliateUXI.Afiliados_BLL
{
    public class AfiilateUtilidades
    {

        /// <summary>
        /// Comprueba por medio del email que el usuario no este inscrito y que tampoco este activo
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool VerificaUsuario(string email)
        {


            bool resultado = false;
            UXI_Usuarios Usuario = new UXI_Usuarios();
            try
            {
                using (uxisolutionbdEntities Context = new uxisolutionbdEntities())
                {
                    var query = (from i in Context.UXI_Usuarios
                                 where i.Email == email
                                 && i.Activo != false
                                 select i).Count();

                    resultado = query != 0 ? true : false;
                }
            }
            catch
            {
                return resultado;
            }
            return resultado;
        }

        public bool MandaCorreoActivacion(string email)
        {


            return true;
        }


    }

    public class EnviarCorreo
    {
        private string sHostMail = "mail.uxisolutions.com";
        private int iPuertoMail = Convert.ToInt32(587);
        private string sUsuarioMail = "noreply@uxisolutions.com";
        private string sContrasenaMail = "H0ll1Sh3t";
        private Boolean bHabilitarSSL = false;
        private string eMailFromWc = "noreply@uxisolutions.com";

        public string EnviarEmail(p_correoE eMail)
        {
            try
            {
                eMail.sFrom = eMailFromWc;
                MailMessage msgMail = new MailMessage(eMail.sFrom, eMail.sTo, eMail.sSubject, eMail.sBody);
                SmtpClient cClienteCorreo = new SmtpClient(sHostMail, iPuertoMail);
                // Se asigna prioridad del correo

                msgMail.Priority = MailPriority.High;

                msgMail.IsBodyHtml = true;

                // En caso de existir archivos adjuntos, se agregan
                if ((eMail.sPathFile != null && eMail.sPathFile != string.Empty && eMail.sPathFile != ""))
                {
                    Attachment aData = new Attachment(eMail.sPathFile, MediaTypeNames.Application.Octet);
                    msgMail.Attachments.Add(aData);
                }

                // Con copia
                if ((eMail.sToCC != null))
                {
                    msgMail.CC.Add(eMail.sToCC);
                }

                // Se crean las credenciales         
                cClienteCorreo.Credentials = new NetworkCredential(sUsuarioMail, sContrasenaMail);
                cClienteCorreo.Port = iPuertoMail;
                cClienteCorreo.EnableSsl = bHabilitarSSL;

                try
                {

                    //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate); 

                    // Se envía el correo
                    cClienteCorreo.Send(msgMail);
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "Envío de correos exitoso!";
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            else
                return true;
        }

        private string testConexion()
        {

            return "Si hay conexión!";
        }
    }

    public class CreaQueryS
    {
        public string ArmaQuery(int idsuario, string email)
        {
            //TODO: Algoritmo

            string _q1 = "http://uxisolutions.com/index/Acceso?120987A="+idsuario+"&45932EE="+email;


            return _q1;
        }
    }


}