using BloodBankManagement.Application.Features.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donations.Commands.DonateBloodCommand
{
    public sealed record DonateBloodCommand(int DonorId, int QuantityMl) : IRequest<Result>;
}
