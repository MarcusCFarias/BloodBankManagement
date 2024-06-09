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
    internal class DonorRepository : Repository<Donor>, IDonorRepository
    {
        public DonorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> EmailAlreadyRegistered(string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.Set<Donor>().Where(x => x.Email == email).AnyAsync(cancellationToken);
        }

        public async Task<Donor?> GetDonorByIdWithDonations(int donorId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Donor>()
                .Where(x => x.Id == donorId)
                .Include(x => x.Donations)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
