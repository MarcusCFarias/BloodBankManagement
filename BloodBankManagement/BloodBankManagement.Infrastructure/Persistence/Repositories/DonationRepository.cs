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
    internal class DonationRepository : Repository<Donation>, IDonationRepository
    {
        public DonationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Donation>> GetHistoryLast30DaysAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Donation>()
                .Where(x => x.DonationDate > DateTime.Now.AddDays(-30))
                .Include(x => x.Donor)
                .ToListAsync(cancellationToken);
        }
    }
}
