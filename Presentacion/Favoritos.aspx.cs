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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("paginaAnterior", "Favoritos.aspx");
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (Session["usuariologueado"] != null)
                {
                    ListaArticulos = negocio.listarFavoritos(((Usuario)Session["usuarioLogueado"]).Id);
                }
                else
                    ListaArticulos = negocio.listar("Código", "");
                
                if (!IsPostBack)
                {
                    
                    Reptarjeta.DataSource = ListaArticulos;
                    Reptarjeta.DataBind();
                }
            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void BtnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                FavoritoNegocio negocio = new FavoritoNegocio();
                Favorito favo = new Favorito();
                int idA = int.Parse(((Button)sender).CommandArgument);
                favo.idUser = ((Usuario)Session["usuarioLogueado"]).Id;
                favo.idArticulo = int.Parse(((Button)sender).CommandArgument);

                if (negocio.EvaluarFavorito(favo))
                    negocio.BorroFavorito(favo);
                else negocio.AgregoFavorito(favo);

                Response.Redirect("Favoritos.aspx", false);
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