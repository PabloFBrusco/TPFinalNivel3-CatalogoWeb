using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Negocio;
using Helper;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("paginaAnterior");
            Session.Add("paginaAnterior", "Login.aspx");
        }

        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                usuario = new Usuario();
                usuario.Email = txtUSer.Text;
                usuario.Pass = txtPass.Text;
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuarioLogueado", usuario);
                    if (usuario.Admin == true) Session.Add("usuarioAdmin", "SI");
                    else Session.Add("usuarioAdmin", "NO");
                    if (Session["paginaAnterior"] != null && Session["paginaAnterior"] != "Login.aspx")
                    {
                        Response.Redirect(Session["paginaAnterior"].ToString(), false);
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }


                }
                else
                {
                    Session.Add("error", "Usuario o Password incorrecta");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}