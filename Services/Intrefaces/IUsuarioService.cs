using Epi_Care_Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Services.Intrefaces
{
    public interface IUsuarioService
    {
        Task InitializeAsync();
        Task <List<Usuario>> GetUsuarios();
        Task<Usuario> GetUserLogin(string name, string password);
        Task<Usuario> GetUserByMatricula(string matricula);
        Task<int> AddUser(Usuario newUser);
        Task<int> UpdateUser(Usuario usuario);
        Task<int> DeleteUser(Usuario usuario);
        
    }
}
