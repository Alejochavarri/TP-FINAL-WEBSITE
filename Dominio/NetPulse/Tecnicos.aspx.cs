using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TecnicoNegocio TecnicoNegocio = new TecnicoNegocio();
            dgvListaTecnicos.DataSource = TecnicoNegocio.listarTecnicos();
            dgvListaTecnicos.DataBind();
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarTecnico.aspx");
        }
    }
}