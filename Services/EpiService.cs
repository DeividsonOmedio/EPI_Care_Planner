using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Services.Intrefaces;
using Microsoft.EntityFrameworkCore;
using System;


namespace Epi_Care_Planner.Services
{
    public class EpiService : IEpiService
    {
        private AppDbContext _context = new AppDbContext();
        public async Task<Epi> AddEpi(Epi newEpi)
        {
            try
            {
                _context.epis.Add(newEpi);
                _context.SaveChanges();
                return newEpi;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<int> DeleteEpi(Epi epi)
        {
            try
            {
                _context.epis.Remove(epi);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<Epi>> GetEpi()
        {
            return await _context.epis.ToListAsync();
        }

        public Task<Epi> GetEpiByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Epi> GetEpiByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Epi> UpdateEpi(Epi epi)
        {
            throw new NotImplementedException();
        }
    }
}
