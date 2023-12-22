using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class HistorialServicioNegocio
    {
        public List<HistorialServicio> listar(int idServicio)
        {
            List<HistorialServicio> lista = new List<HistorialServicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select HS.IdServicio,HS.Fecha,HS.IdTipoCambio,TCH.Descripcion from HistorialServicio HS inner join Tipo_Cambio_Historial TCH on HS.IdTipoCambio = TCH.ID where IdServicio = @idServicio");
                datos.setearParametro("@idServicio", idServicio);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    HistorialServicio aux = new HistorialServicio();
                    aux.IdServicio = idServicio;
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.TipoCambio = new TipoCambioHistorial();
                    aux.TipoCambio.Id = (int)datos.Lector["IdTipoCambio"];
                    aux.TipoCambio.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
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
        public int guardar(HistorialServicio nuevo)
        {
            int idhistorial = -1;

            int IdServicio = nuevo.IdServicio;
            DateTime Fecha = nuevo.Fecha;
            int IdTipoCambio = nuevo.TipoCambio.Id;
            string query = "insert into HistorialServicio(IdServicio,Fecha,IdTipoCambio) VALUES(@IdServicio,@Fecha,@IdTipoCambio);" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;";
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setConsulta(query);
                db.setearParametro("Fecha", Fecha);
                db.setearParametro("IdTipoCambio", IdTipoCambio);
                db.setearParametro("IdServicio", IdServicio);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    idhistorial = (int)db.Lector["ID"];
                }

                return idhistorial;
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
