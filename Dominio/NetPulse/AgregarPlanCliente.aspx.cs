using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace NetPulse
{
    public partial class AgregarPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanNegocio planNegocio = new PlanNegocio();
            List<TPlan> plans = new List<TPlan>();
            plans = planNegocio.listar();
            /*Session["Planes"] = plans;*/
            if (!IsPostBack)
            {
                foreach (var item in plans)
                {
                    DDLPlanes.Items.Add(item.IdPlan.ToString());
                }
            }
            
            inputPrecio.Text = plans[DDLPlanes.SelectedIndex].Precio.ToString();
            inputCantMegas.Text = plans[DDLPlanes.SelectedIndex].CantidadMegas.ToString();
            inputIdPlan.Text = plans[DDLPlanes.SelectedIndex].IdPlan.ToString();
        }

        protected void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            
        }
    }
}