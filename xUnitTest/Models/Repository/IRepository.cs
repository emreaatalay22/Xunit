using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xUnitTest.Models.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        bool Any(Func<TEntity, bool> predicate);
        Task Create(TEntity T);
        void Update(TEntity T);
        void Delete(TEntity T);
    }
}
