using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Model
{
    [Table("emprestimos")]
    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }
        public string Epi { get; set; }
        public string Funcionario { get; set; }
        public string DataSolicitacao { get; set; }
        public string DataPrevisaoEmprestimo { get; set; }
        public string DataEmpretimo { get; set; }
        public string DataPrevisaoDevolucao { get; set; }
        public string DataDevolucao { get; set; }
        public string Status { get; set; }
        public string ComentarioFuncionario { get; set; }
        public string ComentarioAlmoxarife { get; set; }

    }
}