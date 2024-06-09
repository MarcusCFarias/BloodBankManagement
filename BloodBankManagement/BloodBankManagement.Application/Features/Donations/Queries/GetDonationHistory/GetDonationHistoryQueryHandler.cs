using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donations.Queries.GetDonorHistory
{
    public class GetDonationHistoryQueryHandler : IRequestHandler<GetDonationHistoryQuery, Result<IEnumerable<GetDonationHistoryViewModel>>>
    {
        private readonly IDonationRepository _donationRepository;
        public GetDonationHistoryQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<Result<IEnumerable<GetDonationHistoryViewModel>>> Handle(GetDonationHistoryQuery request, CancellationToken cancellationToken)
        {
            var donorHistory = await _donationRepository.GetHistoryLast30DaysAsync();

            if (!donorHistory.Any())
            {
                var errorType = ErrorEnum.NotFound;
                var error = new ErrorModel(errorType, errorType.ToString(), "Donor couldn't be found.");
                return Result<IEnumerable<GetDonationHistoryViewModel>>.Failure(error);
            }

            var donorHistoryViewModel = donorHistory.Select(d => new GetDonationHistoryViewModel(
                                                                    d.Donor.FullName,
                                                                    d.Donor.BloodType,
                                                                    d.Donor.RhFactor,
                                                                    d.DonationDate,
                                                                    d.QuantityMl));

            return Result<IEnumerable<GetDonationHistoryViewModel>>.Success(donorHistoryViewModel);
        }
    }
}
