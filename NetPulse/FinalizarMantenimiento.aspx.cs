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
    public partial class FinalizarMantenimiento : System.Web.UI.Page
    {
        MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
        int IdMantenimiento;
        int IdTipoCambioHistorial;
        int IdTecnico;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdTecnico = int.Parse(Request.QueryString["IdTecnico"]);
            IdMantenimiento = int.Parse(Request.QueryString["IdMantenimiento"]);
            IdTipoCambioHistorial = int.Parse(Request.QueryString["IdTipoCambioHistorial"]);
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            //cambio el estado

            mantenimientoNegocio.activarMantenimiento(IdMantenimiento, TextComentarios.Text);

            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List<Servicio> lista = servicioNegocio.buscarServicio(IdServicio);

            HistorialServicio historialServicio = new HistorialServicio();
            HistorialServicioNegocio historialServicioNegocio = new HistorialServicioNegocio();

            historialServicio.Fecha = DateTime.Now;
            historialServicio.IdServicio = IdServicio;
            historialServicio.TipoCambio = new TipoCambioHistorial();

            historialServicio.TipoCambio.Id = IdTipoCambioHistorial; //depende el tipo de cambio que recibe es lo que registra el historial


            historialServicioNegocio.guardar(historialServicio);



            Response.Redirect("MainTecnico.aspx?IdTecnico=" + IdTecnico);
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainTecnico.aspx?IdTecnico=" + IdTecnico);
        }
    }
}