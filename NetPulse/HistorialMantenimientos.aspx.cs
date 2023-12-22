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
    public partial class HistorialMantenimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdServicio = int.Parse(Request.QueryString["IdServicio"]);
            MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
            List<Mantenimiento> listamantenimientos = mantenimientoNegocio.listarMantenimientos();
            List<Mantenimiento> listaAux = new List<Mantenimiento>();
            foreach (var item in listamantenimientos)
            {
                if (item.IdServicio == IdServicio)
                {
                    listaAux.Add(item);
                }

            }
            dgvListaHistorialMantenimientos.DataSource = listaAux;
            dgvListaHistorialMantenimientos.DataBind();
            
        }
    }
}