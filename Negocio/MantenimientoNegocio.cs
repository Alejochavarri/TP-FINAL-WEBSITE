using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MantenimientoNegocio
    {
        public List<Mantenimiento> listarMantenimientos()
        {

            List<Mantenimiento> lista = new List<Mantenimiento>();
            AccesoDatos datos = new AccesoDatos();

            datos.setConsulta("select IdMantenimiento,IdServicio,Fecha,FechaRealizado,M.IdTecnico,T.Nombre as NombreTecnico,Descripcion,M.IdTipoMantenimiento,TM.Nombre as TipoMantenimiento,M.Comentarios,M.EstadoRealizacion from Mantenimiento M\r\ninner join Tecnico T on M.IdTecnico = T.IdTecnico\r\ninner join TipoMantenimiento TM on M.IdTipoMantenimiento = TM.IdTipoMantenimiento\r\n");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Mantenimiento aux = new Mantenimiento();

                aux.IdMantenimiento = (int)datos.Lector["IdMantenimiento"];
                aux.IdServicio = (int)datos.Lector["IdServicio"];
                aux.Fecha = (DateTime)datos.Lector["Fecha"];
                aux.FechaRealizado = (DateTime)datos.Lector["FechaRealizado"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];
                aux.Comentarios = (string)datos.Lector["Comentarios"];
                aux.EstadoRealizacion = (bool)datos.Lector["EstadoRealizacion"];

                aux.Tecnico = new Tecnico();
                aux.Tecnico.IdTecnico = (int)datos.Lector["IdTecnico"];
                aux.Tecnico.Nombre = (string)datos.Lector["NombreTecnico"];

                aux.TipoMantenimiento = new TipoMantenimiento();
                aux.TipoMantenimiento.IdTipoMantenimiento = (int)datos.Lector["IdTipoMantenimiento"];
                aux.TipoMantenimiento.Nombre = (string)datos.Lector["TipoMantenimiento"];


                lista.Add(aux);

            }

            return lista;
        }
        public int agregarMantenimiento(Mantenimiento mantenimiento)
        {
            int idMantenimiento = -1;
            int IdServicio = mantenimiento.IdServicio;
            DateTime Fecha = mantenimiento.Fecha;
            DateTime FechaRealizado = mantenimiento.FechaRealizado;
            int IdTecnico = mantenimiento.Tecnico.IdTecnico;
            string Descripcion = mantenimiento.Descripcion;
            int IdTipoMantenimiento = mantenimiento.TipoMantenimiento.IdTipoMantenimiento;
            string Comentarios = mantenimiento.Comentarios;
            bool EstadoRealizacion = mantenimiento.EstadoRealizacion;

            string query = "insert into Mantenimiento(IdServicio,Fecha,FechaRealizado,IdTecnico,Descripcion,IdTipoMantenimiento,Comentarios,EstadoRealizacion) values(@IdServicio,@Fecha,@FechaRealizado,@IdTecnico,@Descripcion,@IdTipoMantenimiento,@Comentarios,@EstadoRealizacion)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(query);
                datos.setearParametro("@IdServicio", IdServicio);
                datos.setearParametro("@Fecha", Fecha);
                datos.setearParametro("@FechaRealizado", FechaRealizado);
                datos.setearParametro("@IdTecnico", IdTecnico);
                datos.setearParametro("@Descripcion", Descripcion);
                datos.setearParametro("@IdTipoMantenimiento", IdTipoMantenimiento);
                datos.setearParametro("@Comentarios", Comentarios);
                datos.setearParametro("@EstadoRealizacion", EstadoRealizacion);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idMantenimiento = (int)datos.Lector["ID"];
                }


                return idMantenimiento;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
        public List<Mantenimiento> listarMantenimientosPorTecnico(int IdTecnico)
        {

            List<Mantenimiento> lista = new List<Mantenimiento>();
            AccesoDatos datos = new AccesoDatos();

            datos.setConsulta("select IdMantenimiento,IdServicio,Fecha,FechaRealizado,M.IdTecnico,T.Nombre as NombreTecnico,Descripcion,M.IdTipoMantenimiento,TM.Nombre as TipoMantenimiento,M.Comentarios,M.EstadoRealizacion from Mantenimiento M inner join Tecnico T on M.IdTecnico = T.IdTecnico inner join TipoMantenimiento TM on M.IdTipoMantenimiento = TM.IdTipoMantenimiento where T.IdTecnico = @IdTecnico");
            datos.setearParametro("@IdTecnico", IdTecnico);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Mantenimiento aux = new Mantenimiento();

                aux.IdMantenimiento = (int)datos.Lector["IdMantenimiento"];
                aux.IdServicio = (int)datos.Lector["IdServicio"];
                aux.Fecha = (DateTime)datos.Lector["Fecha"];
                aux.FechaRealizado = (DateTime)datos.Lector["FechaRealizado"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];
                aux.Comentarios = (string)datos.Lector["Comentarios"];
                aux.EstadoRealizacion = (bool)datos.Lector["EstadoRealizacion"];

                aux.Tecnico = new Tecnico();
                aux.Tecnico.IdTecnico = (int)datos.Lector["IdTecnico"];
                aux.Tecnico.Nombre = (string)datos.Lector["NombreTecnico"];

                aux.TipoMantenimiento = new TipoMantenimiento();
                aux.TipoMantenimiento.IdTipoMantenimiento = (int)datos.Lector["IdTipoMantenimiento"];
                aux.TipoMantenimiento.Nombre = (string)datos.Lector["TipoMantenimiento"];


                lista.Add(aux);

            }

            return lista;
        }

        public void activarMantenimiento(int IdMantenimiento, string Comentarios)
        {
            try
            {
                DateTime FechaRealizado = DateTime.Now;
                AccesoDatos Datos = new AccesoDatos();
                Datos.setConsulta("update Mantenimiento set EstadoRealizacion = 1, Comentarios = @Comentarios, FechaRealizado = @FechaRealizado  where IdMantenimiento = @IdMantenimiento");
                Datos.setearParametro("@IdMantenimiento", IdMantenimiento);
                Datos.setearParametro("@Comentarios", Comentarios);
                Datos.setearParametro("@FechaRealizado",FechaRealizado);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
   


    }
}
