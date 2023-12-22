using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HistorialCliente
    {
        public int IdCliente{ get; set; }
        public TipoCambioHistorial TipoCambio{ get; set; }
        public DateTime Fecha { get; set; }
    }
}
