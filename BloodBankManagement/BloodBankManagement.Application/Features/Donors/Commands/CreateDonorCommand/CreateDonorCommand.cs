using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand
{
    public sealed record CreateDonorCommand(
        string FullName, 
        string Email,
        DateTime BirthDate, 
        GenderEnum Gender, 
        double Weight,
        BloodTypeEnum BloodType,
        RhFactorEnum RhFactor,
        Address Address
        ) : IRequest<Result<int>>;
}
