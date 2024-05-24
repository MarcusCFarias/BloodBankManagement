using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string publicArea, string city, string state, string cep)
        {
            if (string.IsNullOrWhiteSpace(publicArea)) throw new ArgumentException("PublicArea cannot be empty");
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be empty");
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentException("State cannot be empty");
            if (string.IsNullOrWhiteSpace(cep)) throw new ArgumentException("Cep cannot be empty");

            PublicArea = publicArea;
            City = city;
            State = state;
            Cep = cep;
        }
        public string PublicArea { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        //public string ZipCode { get; private set; }
        
        //brazilian way
        public string Cep { get; private set; }

        protected override bool EqualsCore(ValueObject other)
        {
            var otherAddress = (Address)other;
            return PublicArea == otherAddress.PublicArea &&
                   City == otherAddress.City &&
                   State == otherAddress.State &&
                   Cep == otherAddress.Cep;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(PublicArea, City, State, Cep);
        }
    }
}
