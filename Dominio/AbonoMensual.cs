using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class AbonoMensual
    {
        public int IdAbonoMensual { get; set; }
        public FormaPago FormaPago { get; set; }
        public DateTime FechaVencimiento1 { get; set; }
        public DateTime FechaVencimiento2 { get; set; }
        public bool Pagado { get; set; }
    }
}
