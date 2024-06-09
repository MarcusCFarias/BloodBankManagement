using BloodBankManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Repositories
{
    public interface IDonorRepository : IRepository<Donor>
    {
        Task<bool> EmailAlreadyRegistered(string email, CancellationToken cancellationToken = default(CancellationToken));
        Task<Donor?> GetDonorByIdWithDonations(int donorId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
