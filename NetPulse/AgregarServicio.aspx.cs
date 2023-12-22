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
    public partial class AgregarServicio : System.Web.UI.Page
    {
        List<FormaPago> formaPagos = new List<FormaPago>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = int.Parse(Request.QueryString["Id"]);
            labelCheck.Text = Id.ToString();

            PlanNegocio planNegocio = new PlanNegocio();
            List<TPlan> plans = new List<TPlan>();
            plans = planNegocio.listar();
            FormaPagoNegocio servicioFP = new FormaPagoNegocio();
            formaPagos = servicioFP.listar();

            if (!IsPostBack)
            {
                foreach (var item in plans)
                {
                    DDLPlanes.Items.Add(item.IdPlan.ToString());
                }
                foreach (var item in formaPagos)
                {
                    DDLMedioDePago.Items.Add(item.Nombre.ToString());
                }
            }

            inputPrecio.Text = plans[DDLPlanes.SelectedIndex].Precio.ToString();
            inputCantMegas.Text = plans[DDLPlanes.SelectedIndex].CantidadMegas.ToString();
            inputIdPlan.Text = plans[DDLPlanes.SelectedIndex].IdPlan.ToString();
        }
        protected void btnDireccion_Click(object sender, EventArgs e)
        {

        }

        protected void btnPlan_Click(object sender, EventArgs e)
        {

        }

        protected void btnFDP_Click(object sender, EventArgs e)
        {

        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

        }
    }
}