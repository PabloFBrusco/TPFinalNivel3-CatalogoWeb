using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTabla.Items.Add("Articulos");
                ddlTabla.Items.Add("Categorias");
                ddlTabla.Items.Add("Marcas");
            }
            CargarGrilla();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMArticulos.aspx", false);
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int elegido = int.Parse(dgvArticulos.SelectedValue.ToString());
            Response.Redirect("ABMArticulos.aspx?id=" + elegido);
        }

        protected void ddlTabla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CargarGrilla()
        {
            if (ddlTabla.SelectedItem.ToString() == "Articulos")
            {
                dgvArticulos.Visible = true;
                dgvCategorias.Visible = false;
                dgvMarcas.Visible = false;
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar());
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();

            }
            else if (ddlTabla.SelectedItem.ToString() == "Categorias")
            {
                dgvArticulos.Visible = false;
                dgvCategorias.Visible = true;
                dgvMarcas.Visible = false;
                CategoriaNegocio negocio = new CategoriaNegocio();
                Session.Add("listaCategorias", negocio.listar());
                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = Session["listaCategorias"];
                dgvCategorias.DataBind();
            }
            else 
            {
                dgvArticulos.Visible = false;
                dgvCategorias.Visible = false;
                dgvMarcas.Visible = true;
                MarcaNegocio negocio = new MarcaNegocio();
                Session.Add("listaMarcas", negocio.listar());
                dgvMarcas.DataSource = null;
                dgvMarcas.DataSource = Session["listaMarcas"];
                dgvMarcas.DataBind();
            }

        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}