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
    public partial class ServiciosMorosos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List<Servicio> listaServicios;
            
            List<Servicio> listaInhabilitados = new List<Servicio>();
            listaServicios = servicioNegocio.listarServicios();
            foreach (var item in listaServicios)
            {
                if (item.Estado.Id == 4)
                {
                    listaInhabilitados.Add(item);
                }
            }
            dgvListaDeudores.DataSource = listaInhabilitados;
            dgvListaDeudores.DataBind();

           
        }

        protected void btnBuscarDni_Click(object sender, EventArgs e)
        {

        }

        protected void dgvListaDeudores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvListaDeudores.Rows[rowIndex];

            string Id = row.Cells[0].Text;
            int IdServicio = int.Parse(Id);

            if (e.CommandName == "Activar_onClick")
            {
                List<Servicio> lista;
                ServicioNegocio servicioNegocio = new ServicioNegocio();
                lista = servicioNegocio.buscarServicio(IdServicio);
                dgvAuxiliar.DataSource = lista;
                dgvAuxiliar.DataBind();
                lblEstado.Text = "1";
                lblInhabilitado.Visible = true;
                servicioNegocio.EditarEstado(IdServicio, 3);
                //Falta Implementacion
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiciosMorosos.aspx");
        }
    }
}