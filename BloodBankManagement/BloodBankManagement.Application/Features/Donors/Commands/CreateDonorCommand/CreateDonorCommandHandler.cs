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

namespace BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, Result<int>>
    {
        private readonly IDonorRepository _donorRepository;
        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
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

            //adicionar validação de CEP dos correios

            var donor = new Donor(request.FullName,
                request.Email,
                request.BirthDate,
                request.Gender,
                request.Weight,
                request.BloodType,
                request.RhFactor,
                request.Address);

            var donorId = await _donorRepository.AddAsync(donor, cancellationToken);

            return Result<int>.Success(donorId);
        }
    }
}
