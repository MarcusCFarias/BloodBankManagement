using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.Repositories;
using BloodBankManagement.Infrastructure.Persistence.Extensions;
using MediatR;
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
        private readonly IMediator _mediator;
        public BloodStorageRepository(ApplicationDbContext dbContext, IMediator mediator) : base(dbContext)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<BloodStorage>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<BloodStorage>().ToListAsync(cancellationToken);
        }

        public async Task<BloodStorage?> GetByBloodTypeAndRhFactor(BloodTypeEnum bloodTypeEnum, RhFactorEnum rhFactorEnum, CancellationToken cancellationToken = default)
        {
            return await _context.Set<BloodStorage>()
                .SingleOrDefaultAsync(x => x.BloodType == bloodTypeEnum
                                           && x.RhFactor == rhFactorEnum,
                                           cancellationToken);
        }

        public async override Task UpdateAsync(BloodStorage bloodStorage, CancellationToken cancellationToken = default)
        {
            _context.Set<BloodStorage>().Update(bloodStorage);

            _mediator.DispatchDomainEvents(_context);

            await SaveChangesAsync(cancellationToken);
        }
    }
}
