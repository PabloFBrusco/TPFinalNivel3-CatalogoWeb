using Modelo;
using System;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class MasterTPFinal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogueado"] != null)
            {
                if (((Usuario)Session["usuarioLogueado"]).UrlImagenPerfil != null)

                    imgPerfil.ImageUrl = "~/images/imagesPerfil/" + ((Usuario)Session["usuarioLogueado"]).UrlImagenPerfil.ToString();
                else imgPerfil.ImageUrl = "https://media.istockphoto.com/id/1345002600/es/vector/avatar-de-perfil-neutro-de-g%C3%A9nero-vista-frontal-de-la-cara-de-una-persona-an%C3%B3nima.jpg?s=612x612&w=0&k=20&c=BUdEMu6OWjPX97gsy3ltUUxVJYtdzKI9q8H-Ph7FsL8=";

            }
            else
            {
                imgPerfil.ImageUrl = "https://media.istockphoto.com/id/1345002600/es/vector/avatar-de-perfil-neutro-de-g%C3%A9nero-vista-frontal-de-la-cara-de-una-persona-an%C3%B3nima.jpg?s=612x612&w=0&k=20&c=BUdEMu6OWjPX97gsy3ltUUxVJYtdzKI9q8H-Ph7FsL8=";
            }

            if (Page is Articulos || Page is ABMArticulos)
            {
                if (!(ValidarUsuario.validarAdmin((Usuario)Session["usuarioLogueado"])))
                {
                    Session.Add("error", "Debes ser Administrador para ingresar a esta página");
                    Response.Redirect("Error.aspx", false);
                }

            }
            else if (Page is Favoritos || Page is MiPerfil)
            {
                if (!(ValidarUsuario.validarUsuario((Usuario)Session["usuarioLogueado"])))
                {
                    Session.Add("error", "Debes loguearte para ingresar");
                    Response.Redirect("Error.aspx", false);
                }
            }


            if ((Usuario)Session["usuarioLogueado"] != null)
            {
                btnLogin.Text = "Cerrar sesion";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Login")
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                Session.Clear();
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}