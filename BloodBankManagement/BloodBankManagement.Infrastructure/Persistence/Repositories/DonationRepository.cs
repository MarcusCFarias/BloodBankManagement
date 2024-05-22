using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Repositories;
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
    }
}
