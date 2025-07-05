using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.Models
{
    public class Puc
    {
        [PrimaryKey]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Naturaleza { get; set; }
        public string DisplayText => $"{Codigo} {Nombre}";
        public Color TotalColor => Naturaleza == "Debito" ? Colors.Blue : Colors.Pink;                
    }
}
