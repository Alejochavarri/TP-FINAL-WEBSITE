using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class Mantenimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
            dgvListaMantenimientos.DataSource = mantenimientoNegocio.listarMantenimientos(); 
            dgvListaMantenimientos.DataBind();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}