using ApiPratica.Data;
using ApiPratica.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace ApiPratica.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiPraticaContext _db;
        internal DbSet<T> DbSet;

        public Repository(ApiPraticaContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _db.AddAsync(entity);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = DbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = DbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            DbSet.Remove(entity);
            await Save();

        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
