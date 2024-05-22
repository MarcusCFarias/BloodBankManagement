using BloodBankManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(int page, int pageSize = 10, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
