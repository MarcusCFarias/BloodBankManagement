using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application.Features.Common.Interfaces
{
    public interface IAddressService
    {
        Task<Result<Address>> GetAddress(string cep);
    }
}
