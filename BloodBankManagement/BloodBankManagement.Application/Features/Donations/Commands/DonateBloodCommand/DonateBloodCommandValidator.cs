using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donations.Commands.DonateBloodCommand
{
    public class DonateBloodCommandValidator:AbstractValidator<DonateBloodCommand>
    {
        public DonateBloodCommandValidator()
        {
            RuleFor(p => p.DonorId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");

            RuleFor(p => p.QuantityMl)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");
        }
    }
}
