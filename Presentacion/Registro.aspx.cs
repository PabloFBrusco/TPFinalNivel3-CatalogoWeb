using Negocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

namespace Presentacion
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblExiste.Visible = false;
                lblCodigo.Visible = false;
                txtCodigo.Visible = false;
                btnVerificar.Visible = false;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            user.Email = txtEmail.Text;
            Session.Add("password", txtPass.Text);
            try
            {
                if (negocio.validarExisteMail(user) == 0)
                {
                    EmailService envio = new EmailService();
                    string tit = "Verificación de Correo - Catalogo Web";
                    envio.ArmarCorreo(txtEmail.Text, tit, "Su Cód. de validacion es A458-T23MJ", "VALIDE SU EMAIL");
                    envio.EnviarMail();
                    lblExiste.Text = "Enviamos un CODIGO de Verificación a su correo, por favor ingréselo a continuación";
                    lblExiste.Visible = true;
                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;
                    txtCodigo.Text = "";
                    btnVerificar.Visible = true;
                }
                else
                {
                    lblExiste.Visible = true;
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", "Se produjo un error al intentar registrarse" + ex.ToString());
                Response.Redirect("frmError.aspx", false);
            }
            finally
            {
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "A458-T23MJ")
            {
                try
                {
                    RegistraryEnviarMail();
                }
                catch (Exception ex)
                {
                    ManejoError error = new ManejoError();
                    Session.Add("error", error.MensajeError(ex));
                    Response.Redirect("Error.aspx", false);
                }

            }
            else
            {
                lblExiste.Text = "Código Incorrecto, ingreselo nuevamente";

            }
        }
        public void RegistraryEnviarMail()
        {
            Usuario user = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            user.Email = txtEmail.Text;
            user.Pass = Session["password"].ToString();
            try
            {
                EmailService envio = new EmailService();
                int id = negocio.agregar(user);
                string tit = "Bienvenido " + txtEmail.Text;
                envio.ArmarCorreo(txtEmail.Text, "Registro en CatalogoWeb", "Te has registrado correctamente. Ya podés usar nuestros servicios", tit);
                envio.EnviarMail();
                lblExiste.Visible = false;
                Session.Add("usuarioLogueado", user);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", "Se produjo un error al intentar registrarse" + ex.ToString());
                Response.Redirect("frmError.aspx", false);
            }

        }
    }
}