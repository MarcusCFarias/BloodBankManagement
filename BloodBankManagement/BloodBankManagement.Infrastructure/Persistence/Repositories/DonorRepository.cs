﻿using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Repositories;
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
    }
}
