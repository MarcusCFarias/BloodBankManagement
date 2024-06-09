using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure.Persistence.Repositories
{
    internal class BloodStorageRepository : Repository<BloodStorage>, IBloodStorageRepository
    {
        public BloodStorageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<BloodStorage>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<BloodStorage>().ToListAsync(cancellationToken);
        }
    }
}
