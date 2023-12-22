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
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdCliente = int.Parse(Request.QueryString["IdCliente"]);
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = negocio.buscarCliente(IdCliente);
            if (!IsPostBack)
            {
                inputName.Text = lista[0].Nombre.ToString();
                inputDNI.Text = lista[0].Dni.ToString();
                inputEmail.Text = lista[0].Mail.ToString();
                inputTelefono.Text = lista[0].Telefono.ToString();
                Calendar1.SelectedDate = lista[0].FechaAlta;
            }
            
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            int IdCliente = int.Parse(Request.QueryString["IdCliente"]);

            Response.Redirect("DetalleCliente.aspx?IdCliente=" + IdCliente);

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            /*Capturar datos de el form*/
            int IdCliente = int.Parse(Request.QueryString["IdCliente"]);
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();

            cliente.Nombre = inputName.Text;
            cliente.Telefono = inputTelefono.Text;
            cliente.Dni = inputDNI.Text;
            cliente.Activo = true;
            cliente.Mail = inputEmail.Text;
            cliente.FechaAlta = Calendar1.SelectedDate;

            negocio.modificarCliente(IdCliente,cliente);

            //guardo el historial de modificacion del cliente 

            HistorialCliente historialCliente = new HistorialCliente();
            HistorialClienteNegocio historialClienteNegocio = new HistorialClienteNegocio();

            historialCliente.Fecha = Calendar1.SelectedDate;
            historialCliente.IdCliente = IdCliente;
            historialCliente.TipoCambio = new TipoCambioHistorial();
            historialCliente.TipoCambio.Id = 3; //tipo cambio nro 3 - modificacion de datos

            historialClienteNegocio.guardar(historialCliente);

            Response.Redirect("DetalleCliente.aspx?IdCliente=" + IdCliente);

        }
    }
}
