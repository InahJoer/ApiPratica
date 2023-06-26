using ApiPratica.Models;

namespace ApiPratica.Repository.IRepository
{
    public interface IMascotasRepository : IRepository<Mascotas>
    {
        Task<Mascotas> Update(Mascotas entity);
    }
}
