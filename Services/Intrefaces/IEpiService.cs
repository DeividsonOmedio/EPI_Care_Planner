using Epi_Care_Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Services.Intrefaces
{
    public interface IEpiService
    {
        Task<List<Epi>> GetEpi();
        Task<Epi> GetEpiByCode(string code);
        Task<Epi> GetEpiByName(string name);
        Task<Epi> AddEpi(Epi newEpi);
        Task<Epi> UpdateEpi(Epi epi); 
        Task<int> DeleteEpi(Epi epi);
        
    }
}
