using BloodBankManagement.Domain.Repositories;
using BloodBankManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankManagement.Domain.ValueObjects;
using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Common.Interfaces;

namespace BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, Result<int>>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IAddressService _addressService;
        public CreateDonorCommandHandler(IDonorRepository donorRepository, IAddressService addressService)
        {
            _donorRepository = donorRepository;
            _addressService = addressService;
        }

        public async Task<Result<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
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

            var donor = new Donor(request.FullName,
                request.Email,
                request.BirthDate,
                request.Gender,
                request.Weight,
                request.BloodType,
                request.RhFactor,
                address);

            var donorId = await _donorRepository.AddAsync(donor, cancellationToken);

            return Result<int>.Success(donorId);
        }
    }
}
