using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donations.Commands.DonateBloodCommand
{
    public class DonateBloodCommandHandler : IRequestHandler<DonateBloodCommand, Result>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IDonationRepository _donationRepository;
        private readonly IBloodStorageRepository _bloodBankRepository;
        public DonateBloodCommandHandler(IDonorRepository donorRepository,
            IDonationRepository donationRepository,
            IBloodStorageRepository bloodStorageRepository)
        {
            _donorRepository = donorRepository;
            _bloodBankRepository = bloodStorageRepository;
            _donationRepository = donationRepository;
        }

        public async Task<Result> Handle(DonateBloodCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorByIdWithDonations(request.DonorId, cancellationToken);

            if (donor is null)
            {
                var errorModel = new ErrorModel(ErrorEnum.NotFound, ErrorEnum.NotFound.ToString(), "Donor not found.");
                return Result.Failure(errorModel);
            }

            var canDonate = donor.CanDonateBlood(request.QuantityMl);

            if (!canDonate)
            {
                var errorModel = new ErrorModel(ErrorEnum.BadRequest, ErrorEnum.BadRequest.ToString(), "Donor can't donate blood.");
                return Result.Failure(errorModel);
            }

            var donation = new Donation(request.DonorId, request.QuantityMl);
            await _donationRepository.AddAsync(donation);

            var bloodStorage = new Domain.Entities.BloodStorage(donor.BloodType, donor.RhFactor, request.QuantityMl);
            await _bloodBankRepository.AddAsync(bloodStorage);

            return Result.Success();
        }
    }
}
