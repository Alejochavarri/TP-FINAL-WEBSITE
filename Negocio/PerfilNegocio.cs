using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PerfilNegocio
    {
        public Perfil ObtenerPerfil(string Usuario)
        {
            Perfil perfil = new Perfil();
            AccesoDatosL datos = new AccesoDatosL();

            datos.setConsulta("Select IdUsuario, Nombre, Apellido, Usuario, Mail, Telefono, TipoUsuario From Usuarios Where Usuario = @Usuario");
            datos.setearParametro("@Usuario", Usuario);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                perfil.IdUsuario = (int)datos.Lector["IdUsuario"];
                perfil.Nombre = (string)datos.Lector["Nombre"];
                perfil.Apellido = (string)datos.Lector["Apellido"];
                perfil.Usuario = (string)datos.Lector["Usuario"];
                perfil.Mail = (string)datos.Lector["Mail"];
                perfil.Telefono = (string)datos.Lector["Telefono"];
                perfil.TipoUsuario = (string)datos.Lector["TipoUsuario"];

            }

            datos.cerrarConexion();

            return perfil;
        }
    }
}
