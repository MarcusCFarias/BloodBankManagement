using BloodBankManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Donors.Queries.GetAllDonors
{
    public sealed record GetAllDonorsViewModel(int Id, string FullName, DateTime BirthDate, 
        string Gender, double Weight, string BloodType, string RhFactor);
}
