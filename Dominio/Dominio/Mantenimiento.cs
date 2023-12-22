using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public int IdServicio{ get; set; }
        public DateTime Fecha { get; set; }
        public Tecnico Tecnico{ get; set; }
        public string Descripcion { get; set; }
        public TipoMantenimiento TipoMantenimiento { get; set; }
        public string Comentarios { get; set; }
        public bool EstadoRealizacion { get; set; }
    }
}
