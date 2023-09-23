using Helper;
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
    public partial class ABMArticulos : System.Web.UI.Page
    {
        List<Articulo> ListaArticulos = new List<Articulo>();
        List<Marca> ListaMarcas = new List<Marca>();
        List<Categoria> ListaCategorias = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // cargo los combos
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    ListaMarcas = marcaNegocio.listar();
                    ddlMarca.DataSource = ListaMarcas;
                    ddlMarca.DataTextField = "descripcion";
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataBind();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    ListaCategorias = categoriaNegocio.listar();
                    ddlCategoria.DataSource = ListaCategorias;
                    ddlCategoria.DataTextField = "descripcion";
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataBind();
                    if (Request.QueryString["id"] != null)
                    {
                        // traigo la lista de articulos y elijo el que me indicaron de la grilla
                        int elegido = int.Parse(Request.QueryString["Id"].ToString());
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        ListaArticulos = negocio.listar("Código");
                        Articulo seleccionado = ListaArticulos.Find(x => x.id == elegido);

                        // cargo en los campos los valores del objeto seleccionado
                        txtID.Text = seleccionado.id.ToString();
                        txtCodigo.Text = seleccionado.codigo;
                        txtNombre.Text = seleccionado.nombre;
                        txtDescripcion.Text = seleccionado.descripcion;
                        txtPrecio.Text = seleccionado.precio.ToString();
                        txtImagen.Text = seleccionado.imagen;
                        imgFoto.ImageUrl = txtImagen.Text;
                        ddlMarca.SelectedIndex = ddlMarca.Items.IndexOf(ddlMarca.Items.FindByValue(seleccionado.marca.id.ToString()));
                        ddlCategoria.SelectedValue = seleccionado.categoria.id.ToString();
                        btnAceptar.Visible = false;

                    }
                    else
                    {
                        btnModificar.Visible = false;
                        btnEliminar.Visible = false;
                    }
                    txtID.Enabled = false;
                    chkEliminar.Visible = false;
                    lblEliminar.Visible = false;
                    btnEliminarDef.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgFoto.ImageUrl = txtImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.agregar(CapturarArticulo());
            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }
            finally
            {
                Response.Redirect("Articulos.aspx", false);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                int id = int.Parse(txtID.Text);
                negocio.modificar(CapturarArticulo(), id);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Response.Redirect("Articulos.aspx", false);

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            chkEliminar.Visible = true;
            lblEliminar.Visible = true;
            btnEliminarDef.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articulos.aspx");
        }

        protected void btnEliminarDef_Click(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar(int.Parse(txtID.Text));
                Response.Redirect("Articulos.aspx", false);
            }
        }
        public Articulo CapturarArticulo()
        {
            Articulo ArticuloNuevo = new Articulo();
            ArticuloNuevo.codigo = txtCodigo.Text;
            ArticuloNuevo.nombre = txtNombre.Text;
            ArticuloNuevo.descripcion = txtDescripcion.Text;
            ArticuloNuevo.imagen = txtImagen.Text;
            ArticuloNuevo.precio = float.Parse(txtPrecio.Text);

            ArticuloNuevo.categoria = new Categoria();
            ArticuloNuevo.categoria.id = int.Parse(ddlCategoria.SelectedValue);

            ArticuloNuevo.marca = new Marca();
            ArticuloNuevo.marca.id = int.Parse(ddlMarca.SelectedValue);

            return ArticuloNuevo;
        }
    }
}