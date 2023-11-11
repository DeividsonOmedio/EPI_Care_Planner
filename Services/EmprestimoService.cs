using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Services
{
    public class EmprestimoService : IEmprestimosService
    {
        private AppDbContext _context = new AppDbContext();

        public Task<List<Emprestimo>> GetEmprestimo()
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimo> GetEmprestimoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimo> GetEmprestimoBystatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimo> UpdateEmprestimo(Emprestimo empres)
        {
            throw new NotImplementedException();
        }
    }
}
