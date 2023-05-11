using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Infraestructure.Infraestructure
{
    public interface IRepository<IDbContext, TEntity>
        where IDbContext : DbContext
        where TEntity : class
    {
        IDbContext _context { get; }
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity updated, object key);
        Task<int> DeleteAsync(TEntity entity);

    }
}
