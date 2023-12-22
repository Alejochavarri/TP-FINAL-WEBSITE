using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoMantenimientoNegocio
    {
        public List<TipoMantenimiento> listar()
        {
            List<TipoMantenimiento> listaTipoMantenimiento = new List<TipoMantenimiento>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select IdTipoMantenimiento, Nombre from TipoMantenimiento");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TipoMantenimiento aux = new TipoMantenimiento();
                    aux.IdTipoMantenimiento = (int)datos.Lector["IdTipoMantenimiento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    listaTipoMantenimiento.Add(aux);
                }

                return listaTipoMantenimiento;
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
        public TipoMantenimiento buscarPorNombre(string nombre)
        {
            AccesoDatos db = new AccesoDatos();
            TipoMantenimiento tipoMantenimiento = new TipoMantenimiento();

            string query = "select IdTipoMantenimiento, Nombre from TipoMantenimiento  where Nombre = @nombre";
            try
            {
                db.setConsulta(query);
                db.setearParametro("@nombre", nombre);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    if (!(db.Lector["IdTipoMantenimiento"] is DBNull)) tipoMantenimiento.IdTipoMantenimiento = (int)db.Lector["IdTipoMantenimiento"];
                    if (!(db.Lector["Nombre"] is DBNull)) tipoMantenimiento.Nombre = (string)db.Lector["Nombre"];
                }



                return tipoMantenimiento;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { db.cerrarConexion(); }
        }
    }
}