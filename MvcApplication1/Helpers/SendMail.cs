using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace MvcApplication1.Helpers
{
    public class SendMail
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
    }

    public class p_correoE
    {
        public string sFrom { get; set; }
        public string sToCC { get; set; }
        public string sTo { get; set; }
        public string sSubject { get; set; }
        public string sBody { get; set; }
        public string sPathFile { get; set; }
        public string result { get; set; }
    }

}