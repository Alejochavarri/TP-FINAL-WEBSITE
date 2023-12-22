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
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void agregarCliente_Click(object sender, EventArgs e)
        {
            /*Capturar datos de el form*/
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();

            cliente.Nombre = inputName.Text;
            cliente.Telefono = inputTelefono.Text;
            cliente.Dni = inputDNI.Text;
            cliente.Activo = chbActivo.Checked;
            cliente.Mail = inputEmail.Text;
            cliente.FechaAlta = Calendar1.SelectedDate;

            cliente.IdCliente = negocio.agregarCliente(cliente);

            /*Agregar a Clientes*/

            //if (cliente.IdCliente != -1)
            //{
            //    lblclienteAgregado.Text = "El Cliente " + cliente.Nombre +" fue agregado exitosamente";
            //}
            //else
            //{
            //    lblclienteAgregado.Text = "Se produjo un error";
            //}
            


            //Response.Redirect("AltaServicio.aspx");
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaServicio.aspx");

        }
    }
}