using BloodBankManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Repositories
{
    public interface IDonationRepository : IRepository<Donation>
    {
        public Task<IEnumerable<Donation>> GetHistoryLast30DaysAsync(CancellationToken cancellationToken = default);
    }
}
