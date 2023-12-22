using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class HistorialClienteNegocio
    {
        public List<HistorialCliente> listar(int idCliente)
        {
            List<HistorialCliente> lista= new List<HistorialCliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select HC.IdCliente,HC.Fecha,HC.IdTipoCambio,TCH.Descripcion from HistorialCliente HC\r\ninner join Tipo_Cambio_Historial TCH on HC.IdTipoCambio = TCH.ID\r\n where IdCliente = @idCliente\r\n");
                datos.setearParametro("@idCliente", idCliente);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    HistorialCliente aux = new HistorialCliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
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
        public int guardar(HistorialCliente nuevo)
        {
            int idhistorial = -1;

            int IdCliente = nuevo.IdCliente;
            DateTime Fecha = nuevo.Fecha;
            int IdTipoCambio = nuevo.TipoCambio.Id;
            string query = "insert into HistorialCliente(IdCliente,Fecha,IdTipoCambio) VALUES(@IdCliente,@Fecha,@IdTipoCambio);" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;";
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setConsulta(query);
                db.setearParametro("IdCliente", IdCliente);
                db.setearParametro("Fecha", Fecha);
                db.setearParametro("IdTipoCambio", IdTipoCambio);
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
