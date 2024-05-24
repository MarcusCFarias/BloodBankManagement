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
    public class CreateDonorCommand : IRequest<int>
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public double Weight { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RhFactorEnum RhFactor { get; set; }
        public Address Address { get; set; }
    }
}
