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

            datos.setConsulta("select IdMantenimiento,IdServicio,Fecha,M.IdTecnico,T.Nombre as NombreTecnico,Descripcion,M.IdTipoMantenimiento,TM.Nombre as TipoMantenimiento,M.Comentarios,M.EstadoRealizacion from Mantenimiento M\r\ninner join Tecnico T on M.IdTecnico = T.IdTecnico\r\ninner join TipoMantenimiento TM on M.IdTipoMantenimiento = TM.IdTipoMantenimiento\r\n");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Mantenimiento aux = new Mantenimiento();

                aux.IdMantenimiento = (int)datos.Lector["IdMantenimiento"];
                aux.IdServicio = (int)datos.Lector["IdServicio"];
                aux.Fecha = (DateTime)datos.Lector["Fecha"];
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
    }
}
