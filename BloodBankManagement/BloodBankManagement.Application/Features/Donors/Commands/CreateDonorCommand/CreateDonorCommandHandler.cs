using BloodBankManagement.Domain.Repositories;
using BloodBankManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankManagement.Domain.ValueObjects;

namespace BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IDonorRepository _donorRepository;
        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor(request.FullName,
                request.Email,
                request.BirthDate,
                request.Gender,
                request.Weight,
                request.BloodType,
                request.RhFactor,
                request.Address);

            var donorId = await _donorRepository.AddAsync(donor, cancellationToken);

            return donorId;
        }
    }
}
