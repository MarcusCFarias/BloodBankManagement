using BloodBankManagement.Application.Features.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetDonorHistory
{
    public class GetDonorHistoryQuery : IRequest<Result<IEnumerable<GetDonorHistoryViewModel>>>
    {
        public GetDonorHistoryQuery(int donorId)
        {
            DonorId = donorId;
        }
        public int DonorId { get; set; }

    }
}
