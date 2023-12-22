using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TecnicoNegocio
    {
        public List<Tecnico> listarTecnicos()
        {
            List<Tecnico> lista = new List<Tecnico>();
            AccesoDatos datos = new AccesoDatos();

            datos.setConsulta("select IdTecnico, Nombre, Contacto, FechaIncorporacion, Estado from Tecnico");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Tecnico aux = new Tecnico();
                aux.IdTecnico = (int)datos.Lector["IdTecnico"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Contacto = (string)datos.Lector["Contacto"];
                aux.FechaIncorporacion = (DateTime)datos.Lector["FechaIncorporacion"];
                aux.Estado = (bool)datos.Lector["Estado"];


                lista.Add(aux);
            }

            return lista;
        }
        public int agregarTecnico(Tecnico tecnico)
        {
            int idtecnico= -1;
            string nombre = tecnico.Nombre;
            string contacto = tecnico.Contacto;
            DateTime fechaalta = tecnico.FechaIncorporacion;
            bool activo = tecnico.Estado;

            string query = "insert into Tecnico(Nombre,Contacto,FechaIncorporacion,Estado) VALUES (@nombre,@contacto,@fechaalta,@activo)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(query);
                datos.setearParametro("@nombre", nombre);
                datos.setearParametro("@contacto", contacto);
                datos.setearParametro("@fechaalta", fechaalta);
                datos.setearParametro("@activo", activo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idtecnico = (int)datos.Lector["ID"];
                }


                return idtecnico;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
    }
}
