using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using Modelo;
using Negocio;

namespace Presentacion
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> lista = new List<Usuario>();
                Usuario usuario = new Usuario();
                if (Session["usuarioLogueado"] != null)
                {
                    string id = ((Usuario)Session["usuarioLogueado"]).Email;
                    lista = negocio.listar(id);
                    usuario = lista.Find(x => x.Email == id);
                    txtApellido.Text = (usuario.Apellido == "") ? "" : usuario.Apellido.ToString();
                    txtNombre.Text = (usuario.Nombre is null) ? "" : usuario.Nombre.ToString();
                    txtEmail.Text = usuario.Email.ToString();
                    imgPerfil.ImageUrl = (usuario.UrlImagenPerfil is null) ? "" : "~/images/imagesPerfil/" + usuario.UrlImagenPerfil.ToString();
                    txtEmail.ReadOnly = true;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuarioLogueado"];
                if (txtImagen.Value != "")
                {
                    string ruta = Server.MapPath("./Images/ImagesPerfil/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                    Image img = (Image)Master.FindControl("imgPerfil");
                    img.ImageUrl = "~/images/ImagesPerfil/" + usuario.UrlImagenPerfil;
                }
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Email = txtEmail.Text;
                negocio.modificar(usuario);
                imgPerfil.ImageUrl = (usuario.UrlImagenPerfil is null) ? "" : "~/images/imagesPerfil/" + usuario.UrlImagenPerfil.ToString();
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