using BloodBankManagement.Application.Features.Common.Interfaces;
using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Commands.UpdateDonorCommand
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, Result>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IAddressService _addressService;

        public UpdateDonorCommandHandler(IDonorRepository donorRepository, IAddressService addressService)
        {
            _donorRepository = donorRepository;
            _addressService = addressService;
        }
        public async Task<Result> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);

            if (donor == null)
            {
                var errorModel = new ErrorModel(ErrorEnum.NotFound, ErrorEnum.NotFound.ToString(), "Donor not found.");
                return Result<int>.Failure(errorModel);
            }

            var boolRegisteredEmail = await _donorRepository.EmailAlreadyRegistered(request.Email);
            if (boolRegisteredEmail)
            {
                var errorModel = new ErrorModel(
                    ErrorEnum.AlreadyRegistered,
                    ErrorEnum.AlreadyRegistered.ToString(),
                    "Email already registered.");

                return Result<int>.Failure(errorModel);
            }

            var externalAddress = await _addressService.GetAddress(request.Cep);

            if (externalAddress.IsFailure)
                return Result<int>.Failure(externalAddress.Error);

            var address = externalAddress.Data;

            donor.UpdateDonor(request.Email, request.Weight, address);

            await _donorRepository.UpdateAsync(donor);

            return Result.Success();
        }
    }
}
