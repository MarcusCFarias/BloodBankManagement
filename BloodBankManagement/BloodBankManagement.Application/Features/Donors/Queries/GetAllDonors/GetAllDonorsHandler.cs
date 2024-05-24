using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Donors.Queries.GetAllDonor;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetAllDonors
{
    public class GetAllDonorsHandler : IRequestHandler<GetAllDonorsQuery, Result<List<GetAllDonorsViewModel>>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetAllDonorsHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Result<List<GetAllDonorsViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donorRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);

            var viewModel = donors.Select(d => new GetAllDonorsViewModel(
                d.Id,
                d.FullName, 
                d.BirthDate, 
                d.Gender.ToString(), 
                d.Weight, 
                d.BloodType.ToString(), 
                d.RhFactor.ToString()));

            if (!viewModel.Any())
            {
                var error = new ErrorModel(ErrorEnum.NotFound, ErrorEnum.NotFound.ToString(), "No donors found");
                return Result<List<GetAllDonorsViewModel>>.Failure(error);
            }

            return Result<List<GetAllDonorsViewModel>>.Success(viewModel.ToList());
        }
    }
}
