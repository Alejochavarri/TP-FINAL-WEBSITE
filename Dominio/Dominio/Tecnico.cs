using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tecnico
    {
        public int IdTecnico { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public bool Estado { get; set; }
    }
}
