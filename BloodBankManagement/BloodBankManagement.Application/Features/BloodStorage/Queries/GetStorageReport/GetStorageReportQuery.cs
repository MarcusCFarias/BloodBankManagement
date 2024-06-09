using BloodBankManagement.Application.Features.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.BloodStorage.Queries.GetStorageReport
{
    public class GetStorageReportQuery : IRequest<Result<IEnumerable<GetStorageReportViewModel>>>
    {
        public GetStorageReportQuery() { }
    }
}
