using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Donors.Queries.GetAllDonors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetAllDonor
{
    public class GetAllDonorsQuery : IRequest<Result<List<GetAllDonorsViewModel>>>
    {
        public GetAllDonorsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
    }
}
