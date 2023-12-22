using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreUsuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (Session["NombreUsuario"] != null && Session["TipoUsuario"] != null)
            {
                string nombreUsuario = Session["NombreUsuario"].ToString();
                string tipoUsuario = Session["TipoUsuario"].ToString();
            }

            if (Session["NombreUsuario"] != null && Session["TipoUsuario"].ToString() != "Admin")
            {
                Response.Redirect("~/MainTecnico.aspx");
            }
        }
    }
}