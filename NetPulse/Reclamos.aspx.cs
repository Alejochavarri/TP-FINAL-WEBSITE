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
    public partial class Reclamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();
            List<Tecnico> listaTecnicos = tecnicoNegocio.listarTecnicos();
            TipoMantenimientoNegocio tipoNegocio = new TipoMantenimientoNegocio();
            List<TipoMantenimiento> listaTipos = tipoNegocio.listar();
            int cant = 0;
            string aux;
            if (!IsPostBack)
            {
                foreach (var item in listaTipos)
                {
                    if (item.Nombre != "Instalacion")
                    {
                        DDLPrioridad.Items.Add(item.Nombre);
                    }
                }

                foreach (var item in listaTecnicos)
                {
                    aux = "";
                    cant = tecnicoNegocio.cantMantenimientosPendientes(item.IdTecnico);
                    aux = item.Nombre + " ( " + cant + " )";
                    DDLTecnicos.Items.Add(aux);
                }
            }
            if (cbxMantenimiento.Checked == true)
            {
                lblEstado.Text = "2";
                cbxResolucionTelefonica.Checked = false;
            }
            if (cbxMantenimiento.Checked == false)
            {
                lblEstado.Text = "1";

            }
            if (cbxResolucionTelefonica.Checked == true)
            {
                cbxMantenimiento.Checked = false;
            }
        }

        protected void btnReclamo_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);

            if (DDLPrioridad.SelectedIndex == 3)
            {
                lblSuccess.Visible = false;

                btnReclamos.Visible = false;

                btnVolver.Visible = false;

                btnCancelar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                Mantenimiento mantenimiento = new Mantenimiento();

                mantenimiento.IdServicio = IdServicio;

                mantenimiento.Fecha = System.DateTime.Today;
                mantenimiento.FechaRealizado = System.DateTime.Today;
                mantenimiento.Descripcion = inputReclamos.Text;
                mantenimiento.Comentarios = "";

                mantenimiento.EstadoRealizacion = false;
                TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();

                //Buscar Tecnico
                mantenimiento.Tecnico = tecnicoNegocio.buscarPorId(DDLTecnicos.SelectedIndex + 1);
                // Buscar Tipo Mantenimiento
                TipoMantenimientoNegocio TMNegocio = new TipoMantenimientoNegocio();

                mantenimiento.TipoMantenimiento = TMNegocio.buscarPorNombre(DDLPrioridad.SelectedValue);

                // Agendo Mantenimiento
                MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
                mantenimientoNegocio.agregarMantenimiento(mantenimiento);
                lblSuccess.Visible = true;

                //guardo registro de mantenimiento en el historial 
                HistorialServicio historialServicio = new HistorialServicio();
                HistorialServicioNegocio historialServicioNegocio = new HistorialServicioNegocio();

                historialServicio.Fecha = DateTime.Now;
                historialServicio.IdServicio = IdServicio;
                historialServicio.TipoCambio = new TipoCambioHistorial();
                historialServicio.TipoCambio.Id = 7; //nro 7 reclamo/mantenimiento

                historialServicioNegocio.guardar(historialServicio);

                //Response.Redirect("Reclamos.aspx");
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);

            Response.Redirect("GestionServicio.aspx?Estado=" + 1 + "&IdServicio=" + IdServicio);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EstadoConfirmacion.Text = "1";
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbxConfirmacion.Checked)
            {
                ServicioNegocio servicioNegocio = new ServicioNegocio();

                int IdServicio = int.Parse(Request.QueryString["IdServicio"]);

                servicioNegocio.EditarEstado(IdServicio, 5);

                Mantenimiento mantenimiento = new Mantenimiento();

                mantenimiento.IdServicio = IdServicio;

                mantenimiento.Fecha = System.DateTime.Today;
                mantenimiento.FechaRealizado = System.DateTime.Today;
                mantenimiento.Descripcion = inputReclamos.Text;
                mantenimiento.Comentarios = "";

                mantenimiento.EstadoRealizacion = false;
                TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();

                //Buscar Tecnico
                mantenimiento.Tecnico = tecnicoNegocio.buscarPorId(DDLTecnicos.SelectedIndex + 1);
                // Buscar Tipo Mantenimiento
                TipoMantenimientoNegocio TMNegocio = new TipoMantenimientoNegocio();

                mantenimiento.TipoMantenimiento = TMNegocio.buscarPorNombre(DDLPrioridad.SelectedValue);

                // Agendo Mantenimiento
                MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
                mantenimientoNegocio.agregarMantenimiento(mantenimiento);
                lblSuccessDelete.Visible = true;

                //guardo registro de mantenimiento en el historial 
                HistorialServicio historialServicio = new HistorialServicio();
                HistorialServicioNegocio historialServicioNegocio = new HistorialServicioNegocio();

                historialServicio.Fecha = DateTime.Now;
                historialServicio.IdServicio = IdServicio;
                historialServicio.TipoCambio = new TipoCambioHistorial();
                historialServicio.TipoCambio.Id = 7; //nro 7 reclamo/mantenimiento

                historialServicioNegocio.guardar(historialServicio);
                btnEliminar.Visible = false;
                EstadoConfirmacion.Text = "";
            }
            else
            {
                btnCancelar.Visible = true;
                btnCancelar.Text = "Volver";
                btnEliminar.Visible = true;
            }



        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Servicios.aspx");
        }
    }
}