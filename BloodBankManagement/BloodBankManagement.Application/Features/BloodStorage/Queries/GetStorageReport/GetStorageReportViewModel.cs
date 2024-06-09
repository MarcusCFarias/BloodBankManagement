using BloodBankManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.BloodStorage.Queries.GetStorageReport
{
    public record GetStorageReportViewModel(BloodTypeEnum BloodType, 
        RhFactorEnum RhFactor, 
        int QuantityMl);
}
