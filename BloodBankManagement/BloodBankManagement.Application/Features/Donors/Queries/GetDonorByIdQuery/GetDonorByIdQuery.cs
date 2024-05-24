using BloodBankManagement.Application.Features.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery
{
    public class GetDonorByIdQuery : IRequest<Result<DonorDetailViewModel>>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
