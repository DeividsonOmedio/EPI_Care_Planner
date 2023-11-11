using Epi_Care_Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Services.Intrefaces
{
    public interface IEmprestimosService
    {
        Task<List<Emprestimo>> GetEmprestimo();
        Task<Emprestimo> GetEmprestimoById(int id);
        Task<Emprestimo> GetEmprestimoBystatus(string status);
        Task<Emprestimo> UpdateEmprestimo(Emprestimo emprestimo);
    }
}
