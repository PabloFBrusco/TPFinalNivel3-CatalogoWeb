using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

namespace Presentacion
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Text = Session["error"].ToString();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["paginaAnterior"] != null)
            {
                Response.Redirect(Session["paginaAnterior"].ToString(), false);
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}