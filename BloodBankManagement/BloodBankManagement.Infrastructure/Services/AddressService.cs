using BloodBankManagement.Application.Features.Common.Interfaces;
using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        //arrumar classe para testes, achei q ficou bagunçada

        private readonly IHttpClientFactory _clientFactory;
        private const string _url = "https://viacep.com.br/ws/{0}/json/";
        private readonly ErrorModel ErrorMessage = new ErrorModel(ErrorEnum.NotFound, ErrorEnum.NotFound.ToString(), "Cep not found.");
        public AddressService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<Result<Address>> GetAddress(string cep)
        {
            var urlComplete = string.Format(_url, cep);

            HttpResponseMessage response = await _clientFactory.CreateClient().GetAsync(urlComplete);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var addressModel = JsonSerializer.Deserialize<AddressModel>(jsonResponse);

                if (!addressModel.erro)
                {
                    var newCep = cep.Replace("-", "");

                    var address = new Address(addressModel.logradouro, addressModel.localidade, addressModel.uf, newCep);
                    return Result<Address>.Success(address);
                }
            }

            return Result<Address>.Failure(ErrorMessage);
        }
    }

    internal class AddressModel
    {
        public string logradouro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public bool erro { get; set; }
    }
}
