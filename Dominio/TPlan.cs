using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TPlan
    {
        public int IdPlan { get; set; }
        public string Nombre { get; set; }
        public int CantidadMegas { get; set; }
        public decimal Precio { get; set; }
    }
}
