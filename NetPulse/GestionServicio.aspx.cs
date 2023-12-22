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
    public partial class GestionServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List<Servicio> listaServicios = servicioNegocio.buscarServicio(IdServicio);

            List<Cliente> ListaCliente = new List<Cliente>();
            List<Domicilio> domicilio = new List<Domicilio>();
            List<TPlan> plan = new List<TPlan>();
            List<FormaPago> formaPagos = new List<FormaPago>();

            ListaCliente.Add(listaServicios[0].Cliente);
            domicilio.Add(listaServicios[0].Domicilio);
            plan.Add(listaServicios[0].Plan);
            formaPagos.Add(listaServicios[0].AbonoMensual.FormaPago);

            dgvDatosCliente.DataSource = ListaCliente;
            dgvDatosCliente.DataBind();

            DgvDomicilio.DataSource = domicilio;
            DgvDomicilio.DataBind();

            DgvPlan.DataSource = plan;
            DgvPlan.DataBind();

            DgvFormaPago.DataSource = formaPagos;
            DgvFormaPago.DataBind();


            //historial

            List<HistorialServicio> listaHistorialServicio = new List<HistorialServicio>();
            HistorialServicioNegocio historialServicioNegocio = new HistorialServicioNegocio();

            listaHistorialServicio = historialServicioNegocio.listar(IdServicio);

            dgvHistorialServicio.DataSource = listaHistorialServicio;
            dgvHistorialServicio.DataBind();

            // ddl
            if (!IsPostBack)
            {
                DDLModificaciones.Items.Add("Modificar Domicilio");
                DDLModificaciones.Items.Add("Modificar Plan");
                DDLModificaciones.Items.Add("Modificar Forma de Pago");
                DDLOtros.Items.Add("Historial Mantenimientos");
                DDLOtros.Items.Add("Agendar Mantenimiento");
                DDLOtros.Items.Add("Inhabilitar");
            }
            int Estado = int.Parse(Request.QueryString["Estado"]);
            if (Estado == 0)
            {
                lblSuccess.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Servicios.aspx");
        }             

        protected void btnGestionar_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            //Historial de mantenimientos
            if (DDLOtros.SelectedIndex == 0)
            {
                Response.Redirect("Mantenimientos.aspx");

            }
            //Mantenimiento
            if (DDLOtros.SelectedIndex == 1)
            {
                Response.Redirect("Reclamos.aspx?IdServicio=" + IdServicio);
            }

            if (DDLOtros.SelectedIndex == 2)
            {
                Response.Redirect("Modificaciones.aspx?Id=" + 4 + "&IdServicio=" + IdServicio);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            //Domicilio
            if (DDLModificaciones.SelectedIndex == 0)
            {

                Response.Redirect("Modificaciones.aspx?Id=" + 1 + "&IdServicio=" + IdServicio);
            }
            //Plan
            if (DDLModificaciones.SelectedIndex == 1)
            {
                Response.Redirect("Modificaciones.aspx?Id=" + 2 + "&IdServicio=" + IdServicio);
            }
            //Forma De pago
            if (DDLModificaciones.SelectedIndex == 2)
            {
                Response.Redirect("Modificaciones.aspx?Id=" + 3 + "&IdServicio=" + IdServicio);
            }
        }
    }
}