using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vencimentos_GM
{
    public class Faturas_Vencidas
    {
        public string nro_invoice { get; set; }
        public DateTime data_embarque { get; set; }
        public DateTime vencimento_invoice { get; set; }
        public double preco_total_item { get; set; }

    }
}
