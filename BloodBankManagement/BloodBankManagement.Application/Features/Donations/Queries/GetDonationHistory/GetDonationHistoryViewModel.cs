using BloodBankManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donations.Queries.GetDonorHistory
{
    public record GetDonationHistoryViewModel(string FullName, BloodTypeEnum BloodType, 
        RhFactorEnum RhFactor, DateTime DonationDate, int QuantityMl);
}
