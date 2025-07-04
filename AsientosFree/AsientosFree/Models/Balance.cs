using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.Models
{
    public class Balance
    {
        public string Cuenta { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        
        private decimal? _saldoDebito;
        public decimal? SaldoDebito
        {
            get => _saldoDebito ?? 0;
            set => _saldoDebito = value;
        }

        private decimal? _saldoCredito;
        public decimal? SaldoCredito
        {
            get => _saldoCredito ?? 0;
            set => _saldoCredito = value;
        }

        public Color TotalColor => SaldoDebito == SaldoCredito ? Colors.Green : Colors.Red;

    }
}
