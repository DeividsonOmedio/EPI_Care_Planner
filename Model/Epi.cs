using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Model
{
    [Table("epis")]
    public class Epi
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeAtual { get; set; }





    }
}
