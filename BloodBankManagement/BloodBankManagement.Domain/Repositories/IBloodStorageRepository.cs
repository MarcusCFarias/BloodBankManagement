using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Repositories
{
    public interface IBloodStorageRepository : IRepository<BloodStorage>
    {
        Task<IEnumerable<BloodStorage>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BloodStorage?> GetByBloodTypeAndRhFactor(BloodTypeEnum bloodTypeEnum, RhFactorEnum rhFactorEnum, CancellationToken cancellationToken = default);
    }
}
