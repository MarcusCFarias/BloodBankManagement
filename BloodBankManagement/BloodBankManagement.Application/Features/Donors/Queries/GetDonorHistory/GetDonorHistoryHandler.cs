using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Donations.Queries.GetDonorHistory;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetDonorHistory
{
    public class GetDonorHistoryHandler : IRequestHandler<GetDonorHistoryQuery, Result<IEnumerable<GetDonorHistoryViewModel>>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetDonorHistoryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<Result<IEnumerable<GetDonorHistoryViewModel>>> Handle(GetDonorHistoryQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorByIdWithDonations(request.DonorId);

            if (donor == null)
            {
                var errorType = ErrorEnum.NotFound;
                var error = new ErrorModel(errorType, errorType.ToString(), "Donor couldn't be found.");
                return Result<IEnumerable<GetDonorHistoryViewModel>>.Failure(error);
            }

            var donorHistoryViewModel = donor.Donations.Select(d => new GetDonorHistoryViewModel(d.DonorId, d.DonationDate, d.QuantityMl));

            return Result<IEnumerable<GetDonorHistoryViewModel>>.Success(donorHistoryViewModel);
        }
    }
}
