using BloodBankManagement.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");

            RuleFor(p => p.PublicArea)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");

            RuleFor(p => p.Cep)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Length(8, 8).WithMessage("{PropertyName} must be equal 8 characters.");
        }
    }
}
