using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void agregarCliente_Click(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Today;
            if ((inputDNI.Text == "") || (inputEmail.Text == "") || (inputName.Text == "") || (inputTelefono.Text == ""))
            {
                lblclienteAgregado.Text = "No puede haber campos vacios";
                lblclienteAgregado.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = new Cliente();

                cliente.Nombre = inputName.Text;
                cliente.Telefono = inputTelefono.Text;
                cliente.Dni = inputDNI.Text;
                cliente.Activo = false;
                cliente.Mail = inputEmail.Text;
                cliente.FechaAlta = Calendar1.SelectedDate;

                cliente.IdCliente = negocio.agregarCliente(cliente);

                //guardo el historial del alta cliente 

                HistorialCliente historialCliente = new HistorialCliente();
                HistorialClienteNegocio historialClienteNegocio = new HistorialClienteNegocio();

                historialCliente.Fecha = Calendar1.SelectedDate;
                historialCliente.IdCliente = cliente.IdCliente;
                historialCliente.TipoCambio = new TipoCambioHistorial();
                historialCliente.TipoCambio.Id = 1;

                historialClienteNegocio.guardar(historialCliente);


                Response.Redirect("Default.aspx");
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }
    }
}