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
    public partial class FormAgregarServicio : System.Web.UI.Page
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
                    DDLPlanes.Items.Add(item.Nombre.ToString());
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
            int IdCliente = int.Parse(Request.QueryString["IdCliente"]);
            Domicilio domicilio = new Domicilio();

            domicilio.Barrio = inputBarrio.Text;
            domicilio.Ciudad = inputCiudad.Text;
            domicilio.Comentario = inputComentarios.Text;
            domicilio.Direccion = inputDireccion.Text;
            Session["DomicilioNuevo"] = domicilio;
            Response.Redirect("ActivarServicio.aspx?Id=" + 2 + "&IdCliente=" + IdCliente);
        }

        protected void btnPlan_Click(object sender, EventArgs e)
        {
            int IdCliente = int.Parse(Request.QueryString["IdCliente"]);
            TPlan plan = new TPlan();
            plan.Nombre = DDLPlanes.SelectedValue;
            plan.Precio = decimal.Parse(inputPrecio.Text);
            plan.CantidadMegas = int.Parse(inputCantMegas.Text.ToString());
            plan.IdPlan = int.Parse(inputIdPlan.Text.ToString());
            Session["PlanNuevo"] = plan;
            Response.Redirect("ActivarServicio.aspx?Id=" + 3 + "&IdCliente=" + IdCliente);
        }

        protected void btnFDP_Click(object sender, EventArgs e)
        {
            int IdCliente = int.Parse(Request.QueryString["IdCliente"]);
            FormaPago formaPago = new FormaPago();
            formaPago.IdFormaPago = formaPagos[DDLMedioDePago.SelectedIndex].IdFormaPago;
            formaPago.Nombre = formaPagos[DDLMedioDePago.SelectedIndex].Nombre;
            Session["FPNuevo"] = formaPago;
            Response.Redirect("ActivarServicio.aspx?Id=" + 4 + "&IdCliente=" + IdCliente);
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

        }
    }
}