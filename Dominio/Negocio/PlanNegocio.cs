using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PlanNegocio
    {
        public List<TPlan> listar()
        {
            List<TPlan> listaPlanes = new List<TPlan>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select IdPlan,CantidadMegas,Precio from TPlan");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TPlan aux = new TPlan();
                    aux.IdPlan = (int)datos.Lector["IdPlan"];
                    aux.CantidadMegas = (int)datos.Lector["CantidadMegas"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    listaPlanes.Add(aux);
                }

                return listaPlanes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int guardar(TPlan nuevo)
        {
            int idplan = -1;
            int cantidadMegas = nuevo.CantidadMegas;
            decimal precio = nuevo.Precio;
             
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setConsulta($"insert into TPlan(CantidadMegas,Precio) VALUES({cantidadMegas},{precio});" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;");
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    idplan = (int)db.Lector["ID"];
                }

                return idplan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }

        }

        public int modificar(int cantMegas, int idPlan,decimal precio)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "UPDATE TPlan set CantidadMegas = @cantMegas,Precio = @precio where IdPlan = @idPlan";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@cantMegas", cantMegas);
                db.setearParametro("@idPlan", idPlan);
                db.setearParametro("@precio", precio);
                rowsAffected = db.ejecutarAccion();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { db.cerrarConexion(); }
        }

        public int eliminar(int idplan)
        {
            AccesoDatos db = new AccesoDatos();

            string query = "delete from TPlan where IdPlan = @idplan  ";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idplan", idplan);
                rowsAffected = db.ejecutarAccion();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }
    }
}
