using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class PerfilTec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreUsuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            try
            {
                string Usuario = Session["NombreUsuario"].ToString();
                PerfilNegocio perfilNegocio = new PerfilNegocio();

                Dominio.Perfil perfil = new Dominio.Perfil();
                perfil = perfilNegocio.ObtenerPerfil(Usuario);
                lblNombre.Text = perfil.Nombre;
                lblApellido.Text = perfil.Apellido;
                lblUsuario.Text = perfil.Usuario;
                lblMail.Text = perfil.Mail;
                lblTelefono.Text = perfil.Telefono;
                lblTipo.Text = perfil.TipoUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}