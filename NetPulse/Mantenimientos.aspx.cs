using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class Mantenimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();


            List<Mantenimiento> listaInstalacionesPendientes = new List<Mantenimiento>();
            List<Mantenimiento> listaPendienteAltaPrioridad = new List<Mantenimiento>();
            List<Mantenimiento> listaPendientes = new List<Mantenimiento>();
            List<Mantenimiento> listaDesinstalacionesPendientes = new List<Mantenimiento>();
            List<Mantenimiento> listaRealizados = new List<Mantenimiento>();
            List<Mantenimiento> mantenimientos = mantenimientoNegocio.listarMantenimientos();

            foreach (var item in mantenimientos)
            {
                if (item.EstadoRealizacion == true)
                {
                    listaRealizados.Add(item);
                }
                else if (item.EstadoRealizacion == false && item.TipoMantenimiento.IdTipoMantenimiento == 1)
                {
                    listaPendienteAltaPrioridad.Add(item);
                }
                else if (item.EstadoRealizacion == false && item.TipoMantenimiento.IdTipoMantenimiento == 3)
                {
                    listaInstalacionesPendientes.Add(item);
                }
                else if (item.EstadoRealizacion == false && item.TipoMantenimiento.IdTipoMantenimiento == 5)
                {
                    listaDesinstalacionesPendientes.Add(item);
                }
                else if (item.EstadoRealizacion == false && (item.TipoMantenimiento.IdTipoMantenimiento == 4 || item.TipoMantenimiento.IdTipoMantenimiento == 2))
                {
                    listaPendientes.Add(item);
                }

            }

            dgvInstalacionesPendientes.DataSource = listaInstalacionesPendientes;
            dgvInstalacionesPendientes.DataBind();

            dgvMantenimientosAltaPrioridad.DataSource = listaPendienteAltaPrioridad;
            dgvMantenimientosAltaPrioridad.DataBind();

            DgvMantenimientosPendientes.DataSource = listaPendientes;
            DgvMantenimientosPendientes.DataBind();

            DgvDesinstalacionesPendientes.DataSource = listaDesinstalacionesPendientes;
            DgvDesinstalacionesPendientes.DataBind();

            DgvMantenimientosRealizados.DataSource = listaRealizados;
            DgvMantenimientosRealizados.DataBind();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnBuscarDni_Click(object sender, EventArgs e)
        {

            if(inputIdServicio.Text != "" && inputIdServicio.Text != null) // chequea si el input es nulo o vacio
            {
                int idServicio = int.Parse(inputIdServicio.Text); 

                MantenimientoNegocio mantenimientoNegocio = new MantenimientoNegocio();


                List<Mantenimiento> listaInstalacionesPendientes = new List<Mantenimiento>();
                List<Mantenimiento> listaPendienteAltaPrioridad = new List<Mantenimiento>();
                List<Mantenimiento> listaPendientes = new List<Mantenimiento>();
                List<Mantenimiento> listaDesinstalacionesPendientes = new List<Mantenimiento>();
                List<Mantenimiento> listaRealizados = new List<Mantenimiento>();
                List<Mantenimiento> mantenimientos = mantenimientoNegocio.listarMantenimientos();

                bool encontrado = false;

                foreach (var item in mantenimientos)
                {
                    if (item.IdServicio == idServicio)
                    {
                        encontrado = true;
                        if (item.EstadoRealizacion == true)
                        {
                            listaRealizados.Add(item);
                        }
                        else if (item.EstadoRealizacion == false && item.TipoMantenimiento.IdTipoMantenimiento == 1)
                        {
                            listaPendienteAltaPrioridad.Add(item);
                        }
                        else if (item.EstadoRealizacion == false && item.TipoMantenimiento.IdTipoMantenimiento == 3)
                        {
                            listaInstalacionesPendientes.Add(item);
                        }
                        else if (item.EstadoRealizacion == false && item.TipoMantenimiento.IdTipoMantenimiento == 5)
                        {
                            listaDesinstalacionesPendientes.Add(item);
                        }
                        else if (item.EstadoRealizacion == false && (item.TipoMantenimiento.IdTipoMantenimiento == 4 || item.TipoMantenimiento.IdTipoMantenimiento == 2))
                        {
                            listaPendientes.Add(item);
                        }
                    }



                    dgvInstalacionesPendientes.DataSource = listaInstalacionesPendientes;
                    dgvInstalacionesPendientes.DataBind();

                    dgvMantenimientosAltaPrioridad.DataSource = listaPendienteAltaPrioridad;
                    dgvMantenimientosAltaPrioridad.DataBind();

                    DgvMantenimientosPendientes.DataSource = listaPendientes;
                    DgvMantenimientosPendientes.DataBind();

                    DgvDesinstalacionesPendientes.DataSource = listaDesinstalacionesPendientes;
                    DgvDesinstalacionesPendientes.DataBind();

                    DgvMantenimientosRealizados.DataSource = listaRealizados;
                    DgvMantenimientosRealizados.DataBind();
                }

                if (encontrado == false)
                {
                    LabelServicioEncontrado.Text = "El Servicio buscado no corresponde a un servicio en sistema...";

                }
                else
                {
                    LabelServicioEncontrado.Text = "Servicio registrado en sistema...";

                }
            }
            else
            {
                LabelServicioEncontrado.Text = "Ingresar un Id de Servicio válido...";

            }

        }
    }
}