using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery
{
    public sealed record DonorDetailViewModel(
        string FullName,
        string Email,
        DateTime BirthDate,
        string Gender,
        double Weight,
        string BloodType,
        string RhFactor,
        Address Address);
}
