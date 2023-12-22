using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class Planes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanNegocio planNegocio = new PlanNegocio();
            dgvListaPlanes.DataSource = planNegocio.listar();
            dgvListaPlanes.DataBind();
            
        }

        protected void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPlan.aspx");
        }
    }
}