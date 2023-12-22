using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Resolvers;

namespace NetPulse
{
    public partial class FormActivarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List < Servicio > listaServicios = servicioNegocio.buscarServicio(IdServicio);

            List<Cliente> ListaClientes = new List<Cliente>();
            List<Domicilio> domicilio = new List<Domicilio>();
            List<TPlan> plan = new List<TPlan>();
            ListaClientes.Add( listaServicios[0].Cliente);
            domicilio.Add(listaServicios[0].Domicilio);
            plan.Add(listaServicios[0].Plan);

            dgvDatosCliente.DataSource = ListaClientes;
            dgvDatosCliente.DataBind();

            DgvDomicilio.DataSource = domicilio;
            DgvDomicilio.DataBind();

            DgvPlan.DataSource = plan;
            DgvPlan.DataBind();
            

        }

        protected void btnActivarServicio_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);

            ServicioNegocio servicioNegocio = new ServicioNegocio();
            TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();
            MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
            TipoMantenimientoNegocio tipoMantenimientoNegocio = new TipoMantenimientoNegocio();

            List<Servicio> servicio = servicioNegocio.buscarServicio(IdServicio);

            //Edito el estado de servicio
            servicioNegocio.EditarEstado(IdServicio, 2);

            // Agendo mantenimiento de tipo instalacion
          
            Mantenimiento mantenimiento = new Mantenimiento();

            // datos del mantenimiento
            mantenimiento.TipoMantenimiento = tipoMantenimientoNegocio.buscarPorNombre("Instalacion");
            Tecnico tecnico = tecnicoNegocio.buscarPorId(tecnicoNegocio.TecnicoLibre());
            mantenimiento.Tecnico = tecnico;
            mantenimiento.IdServicio = IdServicio;
            mantenimiento.Fecha = System.DateTime.Today;
            mantenimiento.FechaRealizado = System.DateTime.Today;
            mantenimiento.Descripcion = "Instalacion";
            mantenimiento.Comentarios = "";
            mantenimiento.EstadoRealizacion = false;

            mantenimientoNegocio.agregarMantenimiento(mantenimiento);

            lblServicioActivo.Visible = true;
            lblInstalacion.Visible = true;
            lblInstalacion.Text += "Con el tecnico : " + tecnico.Nombre;        
        }

        protected void btnModificarServicio_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            Response.Redirect("GestionServicio.aspx?Estado=" + 1 + "&IdServicio=" + IdServicio);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEstados.aspx");
        }
    }
}