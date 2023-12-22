using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class Modificaciones : System.Web.UI.Page
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

            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List<Servicio> servicio = servicioNegocio.buscarServicio(IdServicio);
            if (!IsPostBack)
            {
                inputBarrio.Text = servicio[0].Domicilio.Barrio;
                inputCiudad.Text = servicio[0].Domicilio.Ciudad;
                inputComentarios.Text = servicio[0].Domicilio.Comentario;
                inputDireccion.Text = servicio[0].Domicilio.Direccion;
            }
            List<Servicio> lista = servicioNegocio.buscarServicio(IdServicio);
            DgvServicio.DataSource = lista;
            DgvServicio.DataBind();

        }


        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);

            Domicilio domicilio = new Domicilio();
            DomicilioNegocio DomNegocio = new DomicilioNegocio();
            ServicioNegocio servicioNegocio = new ServicioNegocio();

            List<Servicio> servicio = servicioNegocio.buscarServicio(IdServicio);

            servicio[0].Domicilio.Barrio = inputBarrio.Text;
            servicio[0].Domicilio.Ciudad = inputCiudad.Text;
            servicio[0].Domicilio.Comentario = inputComentarios.Text;
            servicio[0].Domicilio.Direccion = inputDireccion.Text;

            DomNegocio.modificarDomicilio(servicio[0].Domicilio);


            //guardo el historial de la modificacion de datos

            HistorialServicio historialServicio = new HistorialServicio();
            HistorialServicioNegocio historialServicioNegocio= new HistorialServicioNegocio();

            historialServicio.Fecha = DateTime.Now;
            historialServicio.IdServicio= IdServicio;
            historialServicio.TipoCambio = new TipoCambioHistorial();
            historialServicio.TipoCambio.Id = 3; //nro 3 modif datos

            historialServicioNegocio.guardar(historialServicio);

            Response.Redirect("GestionServicio.aspx?Estado=" + 0 + "&IdServicio=" + IdServicio);
        }

        protected void btnPlan_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);

            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List<Servicio> servicio = servicioNegocio.buscarServicio(IdServicio);

            int idPlan = int.Parse(inputIdPlan.Text.ToString());
            servicioNegocio.modificarPlan(IdServicio, idPlan);


            //guardo el historial de la modificacion de plan

            HistorialServicio historialServicio = new HistorialServicio();
            HistorialServicioNegocio historialServicioNegocio = new HistorialServicioNegocio();

            historialServicio.Fecha = DateTime.Now;
            historialServicio.IdServicio = IdServicio;
            historialServicio.TipoCambio = new TipoCambioHistorial();
            historialServicio.TipoCambio.Id = 4; //nro 4 modif plan

            historialServicioNegocio.guardar(historialServicio);

            Response.Redirect("GestionServicio.aspx?Estado=" + 0 + "&IdServicio=" + IdServicio);
        }

        protected void btnFDP_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);

            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List<Servicio> servicio = servicioNegocio.buscarServicio(IdServicio);

            int IdFormaPago = formaPagos[DDLMedioDePago.SelectedIndex].IdFormaPago;

            AbonoMensualNegocio abonoMensualNegocio = new AbonoMensualNegocio();
            abonoMensualNegocio.modificarFormaPago(servicio[0].AbonoMensual.IdAbonoMensual, IdFormaPago);


            //guardo el historial de la modificacion de forma de pago

            HistorialServicio historialServicio = new HistorialServicio();
            HistorialServicioNegocio historialServicioNegocio = new HistorialServicioNegocio();

            historialServicio.Fecha = DateTime.Now;
            historialServicio.IdServicio = IdServicio;
            historialServicio.TipoCambio = new TipoCambioHistorial();
            historialServicio.TipoCambio.Id = 5; //nro 5 modif forma pago

            historialServicioNegocio.guardar(historialServicio);

            Response.Redirect("GestionServicio.aspx?Estado=" + 0 + "&IdServicio=" + IdServicio);
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            ServicioNegocio servicioNegocio = new ServicioNegocio();
            servicioNegocio.EditarEstado(IdServicio, 4);

            lblInhabilitado.Visible= true;
            btnBaja.Visible= false;

            btnCancelar.Text = "Volver";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Servicios.aspx");
        }
    }
}