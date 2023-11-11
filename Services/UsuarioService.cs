using Epi_Care_Planner.Context;
using Epi_Care_Planner.Model;
using Epi_Care_Planner.Services.Intrefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace Epi_Care_Planner.Services 
{
    public class UsuarioService : IUsuarioService
    {
        private AppDbContext _context = new AppDbContext();

        public async Task InitializeAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddUser(Usuario newUser)
        {
            try
            {
             _context.users.Add(newUser);
             _context.SaveChanges();
            return newUser.Id;
            }
            catch
            {
                return 0;
            } 
        }

        public async Task<int> DeleteUser(Usuario usuario)
        {
            try
            {
                _context.users.Remove(usuario);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public Task<List<Usuario>> GetUsuarios()
        {
            return _context.users.ToListAsync();
        }

        public async Task<Usuario> GetUserLogin(string name, string password)
        {
            var usuario = _context.users.FirstOrDefault(x => x.Name == name && x.Senha == password);
            return usuario;
        }

        public async Task<Usuario> GetUserByMatricula(string matricula)
        {
            return _context.users.FirstOrDefault(x => x.Codigo == matricula);
        }


        public async Task<int> UpdateUser(Usuario usuario)
        {
            try
            {

                _context.users.Update(usuario);
                _context.SaveChanges();
                return usuario.Id;
            }
            catch
            {
                return 0;
            }

        }

        
    }
}
