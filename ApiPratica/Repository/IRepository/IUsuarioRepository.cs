using ApiPratica.Models;

namespace ApiPratica.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        bool IsUser(string nombreUsuario, string contra);
        Task<Usuario> GetUser(string nombreUsuario, string contra);
    }
}
