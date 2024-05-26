using BloodBankManagement.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Commands.UpdateDonorCommand
{
    public class UpdateDonorCommandValidator : AbstractValidator<UpdateDonorCommand>
    {
        public UpdateDonorCommandValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Weight)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");          

            RuleFor(p => p.Cep)
                .NotNull()
                .Length(8, 8)
                .WithMessage("{PropertyName} must be equal to 8.");

        }
    }
}
