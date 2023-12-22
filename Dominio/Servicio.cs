using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public Cliente Cliente { get; set; }
        public Domicilio Domicilio { get; set; }
        public TPlan Plan { get; set; }
        public AbonoMensual AbonoMensual { get; set; }
        public DateTime FechaAlta { get; set; }
        public EstadoServicio Estado { get; set; }
        public string Comentarios { get; set; }
    }
}
