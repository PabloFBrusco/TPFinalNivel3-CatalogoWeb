using Modelo;
using Negocio;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("paginaAnterior", "Default.aspx");
            try
            {
                if (!IsPostBack)
                {
                    ddlOrden.Items.Add("Código");
                    ddlOrden.Items.Add("Nombre");
                    ddlOrden.Items.Add("Menor valor");
                    ddlOrden.Items.Add("Mayor valor");
                    ddlOrden.SelectedValue = "Código";
                    Reptarjeta.DataSourceID = "";
                    Reptarjeta.DataSource = ListaArticulos;
                    Reptarjeta.DataBind();
                }
                
                CargarGrilla();
            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        public void CargarGrilla()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (Session["usuariologueado"] != null)
                {
                    ListaArticulos = negocio.listarLogueado(((Usuario)Session["usuarioLogueado"]).Id, ddlOrden.SelectedValue.ToString(), SetearConsulta());

                }

                else
                {
                    ListaArticulos = negocio.listar(ddlOrden.SelectedValue.ToString(), SetearConsulta());
                }
                Reptarjeta.DataSource = ListaArticulos;
                Reptarjeta.DataBind();


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
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlOrden_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtParametroFiltro.Text = "";
            CargarGrilla();
        }
        public string SetearConsulta()
        {
            float valor;
            string cadena = "";
            if (txtParametroFiltro.Text != "") 
            {
                if (ddlCampo.SelectedItem.ToString() == "Categoría")
                {
                    cadena = cadena + " where c.Descripcion";
                }
                else if (ddlCampo.SelectedItem.ToString() == "Marca")
                {
                    cadena = cadena + " where m.Descripcion";
                }
                else if (ddlCampo.SelectedItem.ToString() == "Nombre")
                {
                    cadena = cadena + " where a.Nombre";
                }
                else
                {
                    cadena = cadena + " where a.precio";
                }

                if (ddlCampo.SelectedItem.ToString() == "Precio")
                {
                    valor = float.Parse(txtParametroFiltro.Text);
                    if (ddlCriterio.SelectedItem.ToString() == "Mayor a")
                    {
                        cadena = cadena + "> " + valor;
                    }
                    else if (ddlCriterio.SelectedItem.ToString() == "Menor a")
                    {
                        cadena = cadena + "< " + valor;
                    }
                    else
                    {
                        cadena = cadena + "= " + valor;
                    }
                }
                else
                {
                    if (ddlCriterio.SelectedItem.ToString() == "Empieza con")
                    {
                        cadena = cadena + " LIKE '" + txtParametroFiltro.Text + "%'";
                    }
                    else if (ddlCriterio.SelectedItem.ToString() == "Termina con")
                    {
                        cadena = cadena + " LIKE '%" + txtParametroFiltro.Text + "'";

                    }
                    else
                    {
                        cadena = cadena + " LIKE '%" + txtParametroFiltro.Text + "%'";
                    }
                }
            }
            return cadena;
        }

    }
}