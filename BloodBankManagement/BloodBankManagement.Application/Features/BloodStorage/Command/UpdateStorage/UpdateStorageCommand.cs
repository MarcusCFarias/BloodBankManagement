using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.BloodStorage.Command.UpdateStorage
{
    public sealed record UpdateStorageCommand(BloodTypeEnum BloodType, RhFactorEnum RhFactor, int QuantityMl) : IRequest<Result>;
}
