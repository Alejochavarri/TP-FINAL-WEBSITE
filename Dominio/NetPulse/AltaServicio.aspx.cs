using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class AltaServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            dgvListaClientesInactivos.DataSource = clienteNegocio.listarClientesInactivos();
            dgvListaClientesInactivos.DataBind();
        }

        protected void btnBuscarDni_Click(object sender, EventArgs e)
        {
            /*Buscar en sessoin y modifica label*/
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
        }

        protected void btnReincorporar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
            /*Carga a los campos desde session, permite modificar y vuelve a activar.*/
        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarDomicilio.aspx");
        }

        protected void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPlanCliente.aspx");
        }
    }
}