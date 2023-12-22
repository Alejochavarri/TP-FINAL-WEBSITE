using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio
{
    public class DomicilioNegocio
    {
        public int agregarDomicilio(Domicilio nuevo)
        {
            int iddomicilio = -1;
            string direccion = nuevo.Direccion;
            string barrio = nuevo.Barrio;
            string ciudad = nuevo.Ciudad;
            string comentario = nuevo.Comentario;


            string query = "insert into Domicilio(Direccion,Barrio,Ciudad,Comentario) values (@direccion,@barrio,@ciudad,@comentario)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(query);
                datos.setearParametro("@direccion", direccion);
                datos.setearParametro("@barrio", barrio);
                datos.setearParametro("@ciudad", ciudad);
                datos.setearParametro("@comentario", comentario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    iddomicilio = (int)datos.Lector["ID"];
                }


                return iddomicilio;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
        public void modificarDomicilio(Domicilio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            int IdDomicilio = nuevo.IdDomicilio;
            string direccion = nuevo.Direccion;
            string barrio = nuevo.Barrio;
            string ciudad = nuevo.Ciudad;
            string comentario = nuevo.Comentario;

            try
            {
                datos.setConsulta("update Domicilio set Direccion = @Direccion , Barrio = @Barrio, Ciudad = @Ciudad, Comentario =@Comentario where IdDomicilio = @IdDomicilio");
                datos.setearParametro("@Direccion", direccion);
                datos.setearParametro("@Barrio", barrio);
                datos.setearParametro("@Ciudad", ciudad);
                datos.setearParametro("@Comentario", comentario);
                datos.setearParametro("@IdDomicilio", IdDomicilio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}

