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
        public DateTime Fecha { get; set; }
        public string Cuenta { get; set; }
        public string Debito { get; set; }
        public string Credito { get; set; }
    }
}
