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
    public partial class AgregarTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            Tecnico tecnico = new Tecnico();
            TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();
            tecnico.Contacto = inputContacto.Text;
            tecnico.Nombre = inputNombre.Text;
            tecnico.FechaIncorporacion = Calendar1.SelectedDate;

            tecnico.IdTecnico = tecnicoNegocio.agregarTecnico(tecnico);

            //if (tecnico.IdTecnico != -1)
            //{
            //    lblTecnicoAgregado.Text = "El Cliente " + tecnico.Nombre + " fue agregado exitosamente";
            //}
            //else
            //{
            //    lblTecnicoAgregado.Text = "Se produjo un error";
            //}

            Response.Redirect("tecnicos.aspx");

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("tecnicos.aspx");

        }
    }
}