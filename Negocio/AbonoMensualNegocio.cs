using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AbonoMensualNegocio
    {
        public int agregarAbonoMensual(AbonoMensual nuevo)
        {
            int idAbonoMensual = -1;
            int IdFormaPago = nuevo.FormaPago.IdFormaPago;
            DateTime FechaVencimiento1 = nuevo.FechaVencimiento1;
            DateTime FechaVencimiento2 = nuevo.FechaVencimiento2;
            bool Pagado = nuevo.Pagado;

            string query = "insert into AbonoMensual(IdFormaPago,FechaVencimiento1,FechaVencimiento2,Pagado) values(@IdFormaPago,@FechaVencimiento1,@FechaVencimiento2,@Pagado)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(query);
                datos.setearParametro("@IdFormaPago", IdFormaPago);
                datos.setearParametro("@FechaVencimiento1", FechaVencimiento1);
                datos.setearParametro("@FechaVencimiento2", FechaVencimiento2);
                datos.setearParametro("@Pagado", Pagado);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idAbonoMensual = (int)datos.Lector["ID"];
                }


                return idAbonoMensual;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
        public void modificarFormaPago(int IdAbono, int IdFormaPago)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Update AbonoMensual set IdFormaPago = @IdFormaPago Where IdAbonoMensual = @IdAbono");
                datos.setearParametro("@IdFormaPago", IdFormaPago);
                datos.setearParametro("@IdAbono", IdAbono);
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
