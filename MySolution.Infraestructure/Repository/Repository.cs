using Microsoft.EntityFrameworkCore;
using MySolution.Infraestructure.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Infraestructure.Repository
{
    public class Repository<IDbContext, TEntity> : IRepository<IDbContext, TEntity>
        where IDbContext : DbContext
        where TEntity : class
    {
        public IDbContext _context { get; private set; }

        public Repository(IDbContext context) 
        {
            _context = context;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity updated, object key)
        {
            TEntity existing = await _context.Set<TEntity>().FindAsync(key);

            if (existing != null) 
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.Entry(existing).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return existing;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

    }
}
