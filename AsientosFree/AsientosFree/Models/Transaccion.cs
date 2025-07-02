using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.Models
{
    public class Transaccion
    {
        [PrimaryKey, AutoIncrement]
        public int TransaccionId { get; set; }

        public int No { get; set; }

        public string Cuenta { get; set; }

        public decimal Debito { get; set; }

        public decimal Credito { get; set; }
    }
}
