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
    public partial class DetalleCliente : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            int IdCliente = int.Parse(Request.QueryString["IdCliente"]);

            List<Cliente> ListaClientes = new List<Cliente>();
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            ListaClientes = clienteNegocio.buscarCliente(IdCliente);

            dgvDatosCliente.DataSource = ListaClientes;
            dgvDatosCliente.DataBind();

            List<HistorialCliente> listaHistorialCliente = new List<HistorialCliente>();
            HistorialClienteNegocio historialClienteNegocio = new HistorialClienteNegocio();

            listaHistorialCliente = historialClienteNegocio.listar(IdCliente);

            dgvHistorialCliente.DataSource = listaHistorialCliente;
            dgvHistorialCliente.DataBind();
        }

        protected void dgvDatosCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvDatosCliente.Rows[rowIndex];

            string IdCliente = row.Cells[0].Text;


            if (e.CommandName == "Modificar_onClick")
            {
                Response.Redirect("ModificarCliente.aspx?IdCliente=" + IdCliente);

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}