using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Commands.UpdateDonorCommand
{
    public sealed record UpdateDonorCommand(
        int Id,
        string Email,
        double Weight,
        string Cep) : IRequest<Result>;
}
