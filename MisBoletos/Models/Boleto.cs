using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MisBoletos.Models
{
    public class Boleto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Numero { get; set; }
    }
}
