using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Donations.Commands.DonateBloodCommand;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.BloodStorage.Command.UpdateStorage
{
    public class UpdateStorageCommandHandler : IRequestHandler<UpdateStorageCommand, Result>
    {
        private readonly IBloodStorageRepository _bloodStorageRepository;
        public UpdateStorageCommandHandler(IBloodStorageRepository bloodStorageRepository)
        {
            _bloodStorageRepository = bloodStorageRepository;
        }
        public async Task<Result> Handle(UpdateStorageCommand request, CancellationToken cancellationToken)
        {
            var blood = await _bloodStorageRepository.GetByBloodTypeAndRhFactor(request.BloodType, request.RhFactor, cancellationToken);

            if (blood == null)
            {
                ErrorModel errorModel = new ErrorModel(ErrorEnum.NotFound, ErrorEnum.NotFound.ToString(), "Blood not found");
                return Result.Failure(errorModel);
            }

            blood.RemoveQuantity(request.QuantityMl);

            await _bloodStorageRepository.UpdateAsync(blood, cancellationToken);

            return Result.Success();
        }
    }
}
