using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios._04ClaseCuotas
{
    public class CuotaModelo
    {
        public int NumeroCuota { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal BalanceRestante { get; set; }
        public DateTime FechaCobro { get; set; }
    }
}
