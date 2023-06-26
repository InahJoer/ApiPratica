using ApiPratica.Data;
using ApiPratica.Models;
using ApiPratica.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiPratica.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiPraticaContext _db;
        public UsuarioRepository(ApiPraticaContext db)
        {
            _db = db;
        }
        public async Task<Usuario> GetUser(string nombreUsuario, string contra)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contra);
        }

        public bool IsUser(string nombreUsuario, string contra)
        {
            var usuarios = _db.Usuarios.ToList();
            return usuarios.Where(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contra).Count() > 0;
        }
    }
}
