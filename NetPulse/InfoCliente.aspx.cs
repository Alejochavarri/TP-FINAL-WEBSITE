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
    public partial class InfoCliente : System.Web.UI.Page
    {
        int IdTecnico;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdTecnico = int.Parse(Request.QueryString["IdTecnico"]);

            ServicioNegocio servicioNegocio = new ServicioNegocio();
            List<Servicio> servicios = servicioNegocio.listarServicios();
            List<Servicio> listaServicios = new List<Servicio>();
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            foreach (var item in servicios)
            {
                if(item.IdServicio == IdServicio)
                {
                    listaServicios.Add(item);
                    dgvUsuario.DataSource = listaServicios;
                    dgvUsuario.DataBind();
                }

            }
            
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainTecnico.aspx?IdTecnico=" + IdTecnico);
        }
    }
}