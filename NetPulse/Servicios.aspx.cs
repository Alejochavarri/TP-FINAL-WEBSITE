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
    public partial class Servicios : System.Web.UI.Page
    {
        List<Servicio> listaServicios = new List<Servicio>();
        ServicioNegocio servicioNegocio = new ServicioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            listaServicios = servicioNegocio.listarServicios();
            
            List<Servicio> listaActivos = new List<Servicio>();
            List<Servicio> listaDesinstalados = new List<Servicio>();
            foreach (var item in listaServicios)
            {
 
                if (item.Estado.Id == 3 || item.Estado.Id == 3)
                {
                    listaActivos.Add(item);
                }
                if (item.Estado.Id == 6)
                {
                    listaDesinstalados.Add(item);
                }
            }

            dgvDesinstalados.DataSource = listaDesinstalados;
            dgvDesinstalados.DataBind();

            DgvListaActivos.DataSource = listaActivos;
            DgvListaActivos.DataBind();
        }
        protected void btnBuscarDni_Click(object sender, EventArgs e)
        {
            listaServicios = servicioNegocio.listarServicios();
            //hacer un servicio negocio que filtre por dni cliente para esta parte...
            List<Servicio> listaAux = new List<Servicio>();
            LabelEstado.Text = "Servicio No Encontrado";
            dgvServicioEncontrado.DataSource = null;
            dgvServicioEncontrado.DataBind();

            foreach (var item in listaServicios)
            {
                if (item.Cliente.Dni == inputDNI.Text && (item.Estado.Id == 2 || item.Estado.Id == 3))
                {
                    LabelEstado.Text = "Servicio Activo Encontrado";
                    listaAux.Add(item);

                    dgvServicioEncontrado.DataSource = listaAux;
                    dgvServicioEncontrado.DataBind();

                }
            }
        }

        protected void DgvListaServiciosEncontrados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvServicioEncontrado.Rows[rowIndex];

            string IdServicio = row.Cells[0].Text;

            if (e.CommandName == "Modificar_onClick")
            {
                Response.Redirect("GestionServicio.aspx?Estado=" + 1 + "&IdServicio=" + IdServicio);
                //Falta Implementacion
            }


        }

        protected void DgvListaServiciosActivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvListaActivos.Rows[rowIndex];

            string IdServicio = row.Cells[0].Text;

            if (e.CommandName == "btnGestionar_OnClick")
            {
                Response.Redirect("GestionServicio.aspx?Estado=" + 1 + "&IdServicio=" + IdServicio);
                //Falta Implementacion
            }


        }


        protected void dgvListaServicios_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*int IdEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdServicio").ToString());
                if(IdEstado == 1)
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                    e.Row.BackColor = System.Drawing.Color.Red;
                }*/
                if (e.Row.Cells[6].Text == "Pendiente a Activacion")
                {
                    //e.Row.BorderWidth = 5;
                    //e.Row.BorderColor = System.Drawing.Color.Green;
                }
            }
        }

      
    }
}
