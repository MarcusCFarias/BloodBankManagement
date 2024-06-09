using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donations.Queries.GetDonorHistory
{
    public class GetDonationHistoryQuery : IRequest<Result<IEnumerable<GetDonationHistoryViewModel>>>
    {
        public GetDonationHistoryQuery()
        {

        }
    }
}
