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
    public partial class AgendarMantenimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();
            List<Tecnico> listaTecnicos = new List<Tecnico>();
            listaTecnicos = tecnicoNegocio.listarTecnicos();

            Tecnico aux = new Tecnico();

            TipoMantenimientoNegocio tipoMantenimientoNegocio = new TipoMantenimientoNegocio();
            List<TipoMantenimiento> listaTipoMantenimientos = new List<TipoMantenimiento>();
            listaTipoMantenimientos = tipoMantenimientoNegocio.listar();

            if (!IsPostBack)
            {
                foreach (var item in listaTecnicos)
                {
                    if(item.Estado == true) //mostramos solo tecnicos activos
                    {
                        DDLTecnicos.Items.Add(item.Nombre);
                    }
                }
                foreach (var item in listaTipoMantenimientos)
                {
                    if (item.IdTipoMantenimiento != 3) // para que no se muestre la instalacion
                    {
                        DDLTipoMantenimiento.Items.Add(item.Nombre);
                    }
                }

            }
        }

        protected void btnAgendarMantenimiento_Click(object sender, EventArgs e)
        {

            MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();
            Mantenimiento mantenimiento = new Mantenimiento();

            TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();
            List<Tecnico> listaTecnicos = new List<Tecnico>();
            listaTecnicos = tecnicoNegocio.listarTecnicos();

            mantenimiento.Tecnico = new Tecnico();
            foreach (var item in listaTecnicos)
            {
                if(item.Nombre == DDLTecnicos.SelectedValue.ToString())
                {
                    mantenimiento.Tecnico.Nombre = item.Nombre; 
                    mantenimiento.Tecnico.Contacto = item.Contacto; 
                    mantenimiento.Tecnico.Estado= item.Estado; 
                    mantenimiento.Tecnico.FechaIncorporacion= item.FechaIncorporacion; 
                    mantenimiento.Tecnico.IdTecnico= item.IdTecnico; 
                }
            }

            TipoMantenimientoNegocio tpm = new TipoMantenimientoNegocio();
            List<TipoMantenimiento> listaTM = new List<TipoMantenimiento>();
            listaTM = tpm.listar();
            mantenimiento.TipoMantenimiento = new TipoMantenimiento();
            foreach (var item in listaTM)
            {
                if(item.Nombre == DDLTipoMantenimiento.SelectedValue.ToString())
                {
                    mantenimiento.TipoMantenimiento.IdTipoMantenimiento = item.IdTipoMantenimiento;
                    mantenimiento.TipoMantenimiento.Nombre= item.Nombre;
                }
            }


            mantenimiento.Descripcion = inputDescripcionMantenimiento.Text;
            mantenimiento.Comentarios = ""; // esto considero que lo deberia agregar el tecnico una vez realizado el mantenimiento
            mantenimiento.EstadoRealizacion = false;
            mantenimiento.Fecha = DateTime.Now;
            mantenimiento.FechaRealizado = DateTime.Now;


            mantenimiento.IdServicio = int.Parse(Request.QueryString["IdServicio"]);

            mantenimiento.IdMantenimiento = mantenimientoNegocio.agregarMantenimiento(mantenimiento);

            Response.Redirect("AltaServicio.aspx");
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaServicio.aspx");
        }
    }
}