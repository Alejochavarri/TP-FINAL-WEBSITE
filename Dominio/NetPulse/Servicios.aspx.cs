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
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioNegocio ServicioNegocio = new ServicioNegocio();
            dgvListaServicios.DataSource = ServicioNegocio.listarServicios();
            dgvListaServicios.DataBind();

            Session.Add("listaServicios", ServicioNegocio.listarServicios());
            
        }
    }
}