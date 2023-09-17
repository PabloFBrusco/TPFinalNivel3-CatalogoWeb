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

        public void CorreoContacto(string emailRte, string asunto, string cuerpo, string nombre, string empresa, string telefono, string ciudad)
        {
            email = new MailMessage();
            email.From = new MailAddress("pbrusco@gmail.com");
            email.To.Add("pbrusco@gmail.com");
            email.Subject = "Nuevo contacto desde CatálogoWeb";
            //email.Body = cuerpo;
            email.IsBodyHtml = true;
            email.Body = "<h1>" + asunto + "</h1> <br> <p>Nombre: "+ nombre + "</p> <br> <p>Correo de: " + emailRte + " </p> <br> <p>Empresa: " + empresa + " </p> <br> <p>Telefono: " + telefono + " </p> <br> <p>Ciudad: " + ciudad + " </p> <br> <p>Mensaje: " + cuerpo + "</p>" ;

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
