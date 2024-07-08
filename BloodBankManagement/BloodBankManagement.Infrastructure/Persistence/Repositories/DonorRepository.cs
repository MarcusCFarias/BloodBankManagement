using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure.Persistence.Repositories
{
    internal class DonorRepository : Repository<Donor>, IDonorRepository
    {
        private readonly ILogger<DonorRepository> _logger;
        public DonorRepository(ApplicationDbContext dbContext, ILogger<DonorRepository> logger) : base(dbContext)
        {
            _logger = logger;
        }

        public async Task<bool> EmailAlreadyRegistered(string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("Checking if email is already registered...");
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
