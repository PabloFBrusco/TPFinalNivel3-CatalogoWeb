using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService serviciomail = new EmailService();
            serviciomail.CorreoContacto(txtemail.Text, txtAsunto.Text, txtMensaje.Text, txtNombre.Text, TxtEmpresa.Text, txtTelefono.Text, txtCiudad.Text);
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                serviciomail.EnviarMail();
                Response.Redirect("RespuestaContacto.aspx", false);
            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}