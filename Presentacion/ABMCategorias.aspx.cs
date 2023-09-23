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
    public partial class ABMCategorias : System.Web.UI.Page
    {
        List<Categoria> ListaCategorias = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                                      
                    if (Request.QueryString["id"] != null)
                    {
                        // traigo la lista de articulos y elijo el que me indicaron de la grilla
                        int elegido = int.Parse(Request.QueryString["Id"].ToString());
                        CategoriaNegocio negocio = new CategoriaNegocio();
                        ListaCategorias = negocio.listar();
                        Categoria seleccionado = ListaCategorias.Find(x => x.id == elegido);

                        // cargo en los campos los valores del objeto seleccionado
                        txtID.Text = seleccionado.id.ToString();
                        txtDescripcion.Text = seleccionado.descripcion;
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
                    LblExiste.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ManejoError error = new ManejoError();
                Session.Add("error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                Categoria nuevo = new Categoria();
                nuevo.descripcion = txtDescripcion.Text;
                negocio.agregar(nuevo);
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
                CategoriaNegocio negocio = new CategoriaNegocio();
                Categoria nuevo = new Categoria();
                nuevo.descripcion = txtDescripcion.Text;
                nuevo.id = int.Parse(txtID.Text);
                int id = int.Parse(txtID.Text);
                negocio.modificar(nuevo);

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
            CategoriaNegocio negocio = new CategoriaNegocio();
            if (!(negocio.VerificarArticulos(int.Parse(txtID.Text))))
            {
                chkEliminar.Visible = true;
                lblEliminar.Visible = true;
                btnEliminarDef.Visible = true;
            }
            else
            {
                LblExiste.Visible = true;
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articulos.aspx", false);
        }

        protected void btnEliminarDef_Click(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminar(int.Parse(txtID.Text));
                Response.Redirect("Articulos.aspx", false);
            }
        }
    }
}