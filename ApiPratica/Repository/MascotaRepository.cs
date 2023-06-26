using ApiPratica.Data;
using ApiPratica.Models;
using ApiPratica.Repository.IRepository;

namespace ApiPratica.Repository
{
    public class MascotaRepository : Repository<Mascotas>, IMascotasRepository
    {
        private readonly ApiPraticaContext _db;

        public MascotaRepository(ApiPraticaContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<Mascotas> Update(Mascotas entity)
        {
            _db.Mascotas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
