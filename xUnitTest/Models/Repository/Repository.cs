using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xUnitTest.Models.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UnitTestContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(UnitTestContext context)
        {
            _context = context;

            _dbSet = _context.Set<TEntity>();
        }

        public bool Any(Func<TEntity, bool> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public async Task Create(TEntity T)
        {
            await _dbSet.AddAsync(T);
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity T)
        {
            _dbSet.Remove(T);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Update(TEntity T)
        {
            _context.Entry(T).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
