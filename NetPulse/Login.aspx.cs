using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetPulse
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreUsuario"] != null)
            {
                Session.Remove("NombreUsuario");
                Session.Remove("TipoUsuario");
            }
        }

        SqlConnection con = new SqlConnection("server=.\\SQLEXPRESS;database=UserLogin;integrated security=true");
        public void logear(string usuario, string contrasena)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select IdUsuario, Usuario, TipoUsuario From Usuarios Where Usuario = @usuario and Contraseña = @pass", con);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pass", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    int IdUsuario = int.Parse(dt.Rows[0]["IdUsuario"].ToString());
                    string nombreUsuario = dt.Rows[0]["Usuario"].ToString();
                    string tipoUsuario = dt.Rows[0]["TipoUsuario"].ToString();

                    Session["IdUsuario"] = IdUsuario;
                    Session["NombreUsuario"] = nombreUsuario;
                    Session["TipoUsuario"] = tipoUsuario;

                    if (tipoUsuario == "Admin")
                    {
                        //Response.Write("<script>alert('Ingresaste como Administrador');</script>");
                        Response.Redirect("Default.aspx");
                    }
                    else if (tipoUsuario == "Tecnico")
                    {
                        if(nombreUsuario == "TecPepe")
                        {
                            //Response.Write("<script>alert('Ingresaste como Usuario');</script>");
                            Response.Redirect("MainTecnico.aspx?IdTecnico=" + 1);
                        }
                        else if(nombreUsuario == "TecJose")
                        {
                            //Response.Write("<script>alert('Ingresaste como Usuario');</script>");
                            Response.Redirect("MainTecnico.aspx?IdTecnico=" + 2);
                        }
                        else if(nombreUsuario == "TecLuis")
                        {
                            //Response.Write("<script>alert('Ingresaste como Usuario');</script>");
                            Response.Redirect("MainTecnico.aspx?IdTecnico=" + 3);
                        }
                        
                    }

                }
                else
                {
                    Response.Write("<script>alert('Error, ingrese credenciales correctas');</script>");
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                //Agregar para ver el error de forma correcta ya que MessageBox no existe acá
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            logear(this.tbUser.Text, this.tbPass.Text);
        }
    }
}