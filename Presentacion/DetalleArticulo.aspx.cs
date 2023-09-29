using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> ListaArticulos = new List<Articulo>();
            if (Request.QueryString["Id"] != null)
            {
                int elegido = int.Parse(Request.QueryString["Id"].ToString());
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.listar("Código", "");
                Articulo seleccionado = ListaArticulos.Find(x => x.id == elegido);
                imgFoto.ImageUrl = seleccionado.imagen.ToString();
                if (imgFoto.ImageUrl == "") imgFoto.ImageUrl = "https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740";
                lblCategoria.Text = "Categoría: " + seleccionado.categoria.ToString();
                lblMarca.Text = "Marca: " + seleccionado.marca.ToString();
                lblCodigo.Text = "Código: " + seleccionado.codigo;
                LblTitulo.Text = seleccionado.nombre;
                LblDescripcion.Text = "Descripción: " + seleccionado.descripcion;
                lblPrecio.Text = "Precio: " + seleccionado.precio.ToString("C");
            }
            else
            {
                Session.Add("error", "No hay ningún artículo Seleccionado");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["paginaAnterior"] == null)
                Response.Redirect("Default.aspx", false);
            else
            Response.Redirect(Session["paginaAnterior"].ToString(), false);
        }

    }
}