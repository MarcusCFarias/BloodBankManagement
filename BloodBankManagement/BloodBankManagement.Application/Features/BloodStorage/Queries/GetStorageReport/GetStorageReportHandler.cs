using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.BloodStorage.Queries.GetStorageReport
{
    public class GetStorageReportHandler : IRequestHandler<GetStorageReportQuery, Result<IEnumerable<GetStorageReportViewModel>>>
    {
        private readonly IBloodStorageRepository _bloodStorageRepository;
        public GetStorageReportHandler(IBloodStorageRepository bloodStorageRepository)
        {
            _bloodStorageRepository = bloodStorageRepository;
        }
        public async Task<Result<IEnumerable<GetStorageReportViewModel>>> Handle(GetStorageReportQuery request, CancellationToken cancellationToken)
        {
            var bloodStorage = await _bloodStorageRepository.GetAllAsync();

            var bloodStorageViewModel = bloodStorage.Select(x => new GetStorageReportViewModel(x.BloodType, x.RhFactor, x.QuantityMl)).ToList();

            return Result<IEnumerable<GetStorageReportViewModel>>.Success(bloodStorageViewModel);
        }
    }
}
