using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetDonorHistory
{
    public record GetDonorHistoryViewModel(int DonorId, DateTime DonationDate, int QuantityMl);
}
