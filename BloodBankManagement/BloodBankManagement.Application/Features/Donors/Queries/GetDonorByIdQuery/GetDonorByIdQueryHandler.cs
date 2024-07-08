using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, Result<DonorDetailViewModel>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetDonorByIdQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Result<DonorDetailViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id, cancellationToken);

            if (donor == null)
            {
                var errorType = ErrorEnum.NotFound;
                var error = new ErrorModel(errorType, errorType.ToString(), "Donor co uldn't be found.");
                return Result<DonorDetailViewModel>.Failure(error);
            }

            var viewModel = new DonorDetailViewModel(
                donor.FullName,
                donor.Email,
                donor.BirthDate,
                donor.Gender.ToString(),
                donor.Weight,
                donor.BloodType.ToString(),
                donor.RhFactor.ToString(),
                donor.Address);

            return Result<DonorDetailViewModel>.Success(viewModel);
        }
    }
}
