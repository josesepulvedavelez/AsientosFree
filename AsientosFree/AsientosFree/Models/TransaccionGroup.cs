using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.Models
{
    public class TransaccionGroup
    {
        public int No { get; set; }
        public ObservableCollection<Transaccion> Detalles { get; set; }

        public decimal TotalDebito => Detalles.Sum(t => t.Debito);
        public decimal TotalCredito => Detalles.Sum(t => t.Credito);
        public Color TotalColor => TotalDebito == TotalCredito ? Colors.Green : Colors.Red;
    }
}
