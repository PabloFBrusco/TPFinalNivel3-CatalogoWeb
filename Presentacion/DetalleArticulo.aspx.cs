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
            int elegido = int.Parse(Request.QueryString["Id"].ToString());
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();
            Articulo seleccionado = ListaArticulos.Find(x => x.id == elegido);
            imgFoto.ImageUrl = seleccionado.imagen.ToString();
            lblCategoria.Text = "Categoría: " + seleccionado.categoria.ToString();
            lblMarca.Text = "Marca: " + seleccionado.marca.ToString();
            lblCodigo.Text = "Código: " + seleccionado.codigo;
            LblTitulo.Text = seleccionado.nombre;
            LblDescripcion.Text = "Descripción: " + seleccionado.descripcion;
            lblPrecio.Text = "Precio: " + seleccionado.precio.ToString("C");
        }
    }
}