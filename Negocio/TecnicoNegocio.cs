using System;
using System.Collections;
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
        public Tecnico buscarPorNombre(string nombre)
        {
            AccesoDatos db = new AccesoDatos();
            Tecnico tecnico = new Tecnico();

            string query = "select IdTecnico,Nombre,Contacto,FechaIncorporacion,Estado from Tecnico where Nombre = '@nombre'";
            try
            {
                db.setConsulta(query);
                db.setearParametro("@nombre", nombre);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    if (!(db.Lector["IdTecnico"] is DBNull)) tecnico.IdTecnico = (int)db.Lector["IdTecnico"];
                    if (!(db.Lector["Nombre"] is DBNull)) tecnico.Nombre = (string)db.Lector["Nombre"];
                    if (!(db.Lector["Contacto"] is DBNull)) tecnico.Contacto = (string)db.Lector["Contacto"];
                    if (!(db.Lector["FechaIncorporacion"] is DBNull)) tecnico.FechaIncorporacion = (DateTime)db.Lector["FechaIncorporacion"];
                    if (!(db.Lector["Estado"] is DBNull)) tecnico.Estado = (bool)db.Lector["Estado"];
                }
                


                return tecnico;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { db.cerrarConexion(); }
        }

        public Tecnico buscarPorId(int IdTecnico)
        {
            AccesoDatos db = new AccesoDatos();
            Tecnico tecnico = new Tecnico();

            string query = "select IdTecnico,Nombre,Contacto,FechaIncorporacion,Estado from Tecnico where IdTecnico = @IdTecnico";
            try
            {
                db.setConsulta(query);
                db.setearParametro("@IdTecnico", IdTecnico);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    if (!(db.Lector["IdTecnico"] is DBNull)) tecnico.IdTecnico = (int)db.Lector["IdTecnico"];
                    if (!(db.Lector["Nombre"] is DBNull)) tecnico.Nombre = (string)db.Lector["Nombre"];
                    if (!(db.Lector["Contacto"] is DBNull)) tecnico.Contacto = (string)db.Lector["Contacto"];
                    if (!(db.Lector["FechaIncorporacion"] is DBNull)) tecnico.FechaIncorporacion = (DateTime)db.Lector["FechaIncorporacion"];
                    if (!(db.Lector["Estado"] is DBNull)) tecnico.Estado = (bool)db.Lector["Estado"];
                }



                return tecnico;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { db.cerrarConexion(); }
        }

        public int cantMantenimientosPendientes (int IdTecnico)
        {
            AccesoDatos db = new AccesoDatos();
            int cantMantPendientes = 0;
            try
            {
                db.setConsulta("select COUNT(*) as CantPendientes from Mantenimiento where EstadoRealizacion = 0 and IdTecnico = @IdTecnico group by IdTecnico");
                db.setearParametro("@IdTecnico", IdTecnico);
                db.ejecutarLectura();
                if (db.Lector.Read())
                {
                    cantMantPendientes = (int)db.lector["CantPendientes"];
                }
                    return cantMantPendientes;
            }
            catch (Exception ex)
            {
                return cantMantPendientes;
                throw ex;
            }
            finally { db.cerrarConexion(); }
         
        }

        public int TecnicoLibre()
        {
            AccesoDatos db = new AccesoDatos();
            int tecnico = 0;
            try
            {
                db.setConsulta("select top(1) IdTecnico, COUNT(*) as CantPendientes from Mantenimiento where EstadoRealizacion = 0 group by IdTecnico");
                
                db.ejecutarLectura();
                if (db.Lector.Read())
                {
                    tecnico = (int)db.lector["IdTecnico"];
                }
                return tecnico;
            }
            catch (Exception ex)
            {
                return tecnico;
                throw ex;
            }
            finally { db.cerrarConexion(); }
        }
    }
}
