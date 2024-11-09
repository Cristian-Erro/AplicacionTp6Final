using AplicacionTp6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.Services
{
    public interface IUsuarioService
    {
        //Servicio para traer usuarios
        Task<IEnumerable<Usuario>> GetUsersAsync();
        //Servicio para crear usuarios
        Task<Usuario> CreateUserAsync(Usuario usuario);
        //Editar
        Task<bool> UpdateUserAsync(int id, Usuario usuario);
        //Eliminar
        Task<bool> DeleteUserAsync(int id);
    }
}
