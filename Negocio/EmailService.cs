using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("pbrusco@gmail.com", "iigtluumgykinyqp");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo, string titulo)
        {
            email = new MailMessage();
            email.From = new MailAddress("pbrusco@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            //email.Body = cuerpo;
            email.IsBodyHtml = true;
             email.Body = "<h1>" + titulo + "</h1> <br> <p>" + cuerpo + "</p>";

        }

        public void EnviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
