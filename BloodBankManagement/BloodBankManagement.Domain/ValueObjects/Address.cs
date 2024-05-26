using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        //brazilian way
        public Address(string logradouro, string localidade, string uf, string cep)
        {
            //if (string.IsNullOrWhiteSpace(logradouro)) throw new ArgumentException("Logradouro cannot be empty");
            //if (string.IsNullOrWhiteSpace(localidade)) throw new ArgumentException("Localidade cannot be empty");
            //if (string.IsNullOrWhiteSpace(uf)) throw new ArgumentException("UF cannot be empty");
            if (string.IsNullOrWhiteSpace(cep)) throw new ArgumentException("Cep cannot be empty");

            Logradouro = logradouro;
            Localidade = localidade;
            Uf = uf;
            Cep = cep;
        }
        public string Logradouro { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }      
        public string Cep { get; private set; }

        protected override bool EqualsCore(ValueObject other)
        {
            var otherAddress = (Address)other;
            return Logradouro == otherAddress.Logradouro &&
                   Localidade == otherAddress.Localidade &&
                   Uf == otherAddress.Uf &&
                   Cep == otherAddress.Cep;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Logradouro, Localidade, Uf, Cep);
        }
    }
}
