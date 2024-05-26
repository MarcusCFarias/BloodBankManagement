using BloodBankManagement.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand
{
    public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorCommandValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThan(DateTime.Now).WithMessage("{PropertyName} must be a date in the past.");

            RuleFor(x => x.Gender)
                .Must(x => Enum.IsDefined(typeof(GenderEnum), x))
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Weight)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(x => x.BloodType)
                .Must(x => Enum.IsDefined(typeof(BloodTypeEnum), x))
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.RhFactor)
                .Must(x => Enum.IsDefined(typeof(RhFactorEnum), x))
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Cep)
                .NotNull()
                .Length(8, 8)
                .WithMessage("{PropertyName} must be equal to 8.");
                
        }
    }
}
