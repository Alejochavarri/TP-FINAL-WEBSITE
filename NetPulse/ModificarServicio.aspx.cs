using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class ModificarServicio : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ModificarDireccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modificaciones.aspx?Id=" + 1);
        }

        protected void ModificarPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modificaciones.aspx?Id=" + 2);
        }

        protected void ModificarFormaDePago_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modificaciones.aspx?Id=" + 3);
        }

        protected void DardeBaja_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modificaciones.aspx?Id=" + 4);
        }
        protected void btnAgendarMantenimiento_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            Response.Redirect("Reclamos.aspx?IdServicio=" + IdServicio);
        }
    }
}