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
    public partial class MainTecnico : System.Web.UI.Page
    {
        int IdTecnico;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdTecnico = int.Parse(Request.QueryString["IdTecnico"]);

            MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
            List<Mantenimiento> listaRealizados = new List<Mantenimiento>();
            List<Mantenimiento> listaPendienteAltaPrioridad = new List<Mantenimiento>();
            List<Mantenimiento> listaPendientes= new List<Mantenimiento>();
            List<Mantenimiento> listaPendienteInstalacion = new List<Mantenimiento>();
            List<Mantenimiento> listaPendienteDesinstalacion = new List<Mantenimiento>();

            List<Mantenimiento> mantenimientos = mantenimientoNegocio.listarMantenimientosPorTecnico(IdTecnico);

            foreach (var item in mantenimientos)
            {
                if (item.EstadoRealizacion == true)
                {
                    listaRealizados.Add(item);
                }
                if (item.EstadoRealizacion == false)
                {
                    if (item.TipoMantenimiento.IdTipoMantenimiento == 1)
                    {
                        listaPendienteAltaPrioridad.Add(item);
                    }
                    if ((item.TipoMantenimiento.IdTipoMantenimiento == 2) || (item.TipoMantenimiento.IdTipoMantenimiento == 4))
                    {
                        listaPendientes.Add(item);
                    }
                    if ( item.TipoMantenimiento.IdTipoMantenimiento == 5)
                    {
                        listaPendienteDesinstalacion.Add(item);
                    }
                    if (item.TipoMantenimiento.IdTipoMantenimiento == 3)
                    {
                        listaPendienteInstalacion.Add(item);
                    }

                }
            }
            dgvDesinstalacionesPendientes.DataSource = listaPendienteDesinstalacion;
            dgvDesinstalacionesPendientes.DataBind();

            dgvPendienteInstalacion.DataSource = listaPendienteInstalacion;
            dgvPendienteInstalacion.DataBind();

            dgvPrioridadAlta.DataSource = listaPendienteAltaPrioridad;
            dgvPrioridadAlta.DataBind();

            dgvPrioridadBaja.DataSource = listaPendientes;
            dgvPrioridadBaja.DataBind();

            dgvListaMantenimientosRealizados.DataSource = listaRealizados;
            dgvListaMantenimientosRealizados.DataBind();
        }


        protected void dgvListaMantenimientosPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvPrioridadAlta.Rows[rowIndex];

            // Accede a los datos de la fila utilizando los índices de las columnas
            string IdServicio = row.Cells[1].Text;
            string IdMantenimiento = row.Cells[0].Text;
            int IdTipoCambioHistorial = 8;

            if (e.CommandName == "Info_onClick")
            {
                Response.Redirect("InfoCliente.aspx?IdServicio=" + IdServicio + "&IdTecnico=" + IdTecnico);
            }
            if (e.CommandName == "Finalizar_onClick")
            {
                Response.Redirect("FinalizarMantenimiento.aspx?IdMantenimiento=" + IdMantenimiento + "&IdServicio=" + IdServicio + "&IdTipoCambioHistorial=" + IdTipoCambioHistorial + "&IdTecnico=" + IdTecnico);

            }
        }

        protected void dgvPendienteInstalacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvPendienteInstalacion.Rows[rowIndex];

            // Accede a los datos de la fila utilizando los índices de las columnas
            string IdServicio = row.Cells[1].Text;
            string IdMantenimiento = row.Cells[0].Text;
            int IdTipoCambioHistorial = 2;


            if (e.CommandName == "Info_onClick")
            {
                Response.Redirect("InfoCliente.aspx?IdServicio=" + IdServicio + "&IdTecnico=" + IdTecnico);
            }
            if (e.CommandName == "Finalizar_onClick")
            {
                Response.Redirect("FinalizarMantenimiento.aspx?IdMantenimiento=" + IdMantenimiento + "&IdServicio=" + IdServicio + "&IdTipoCambioHistorial=" + IdTipoCambioHistorial + "&IdTecnico=" + IdTecnico);

            }
        }

        protected void dgvDesinstalacionesPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvDesinstalacionesPendientes.Rows[rowIndex];

            // Accede a los datos de la fila utilizando los índices de las columnas
            string IdServicio = row.Cells[1].Text;
            string IdMantenimiento = row.Cells[0].Text;
            int IdTipoCambioHistorial = 9;


            if (e.CommandName == "Info_onClick")
            {
                Response.Redirect("InfoCliente.aspx?IdServicio=" + IdServicio + "&IdTecnico=" + IdTecnico);
            }
            if (e.CommandName == "Finalizar_onClick")
            {
                Response.Redirect("FinalizarMantenimiento.aspx?IdMantenimiento=" + IdMantenimiento + "&IdServicio=" + IdServicio + "&IdTipoCambioHistorial=" + IdTipoCambioHistorial + "&IdTecnico=" + IdTecnico);

            }
        }

        protected void dgvPrioridadBaja_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvPrioridadBaja.Rows[rowIndex];


            // Accede a los datos de la fila utilizando los índices de las columnas
            string IdServicio = row.Cells[1].Text;
            string IdMantenimiento = row.Cells[0].Text;
            int IdTipoCambioHistorial = 8;

            if (e.CommandName == "Info_onClick")
            {
                Response.Redirect("InfoCliente.aspx?IdServicio=" + IdServicio + "&IdTecnico=" + IdTecnico);
            }
            if (e.CommandName == "Finalizar_onClick")
            {
                Response.Redirect("FinalizarMantenimiento.aspx?IdMantenimiento=" + IdMantenimiento + "&IdServicio=" + IdServicio + "&IdTipoCambioHistorial=" + IdTipoCambioHistorial + "&IdTecnico=" + IdTecnico);

            }
        }
    }
}