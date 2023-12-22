using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HistorialServicio
    {
        public int IdServicio { get; set; }
        public TipoCambioHistorial TipoCambio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
