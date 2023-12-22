using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FormaPagoNegocio
    {
        public List<FormaPago> listar()
        {
            List<FormaPago> listaFP = new List<FormaPago>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select IdFormaPago, Nombre from FormaPago");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    FormaPago aux = new FormaPago();
                    aux.IdFormaPago = (int)datos.Lector["IdFormaPago"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    listaFP.Add(aux);
                }

                return listaFP;
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
    }
}
