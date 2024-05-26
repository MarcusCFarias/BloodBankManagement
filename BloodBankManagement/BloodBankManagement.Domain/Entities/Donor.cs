using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Entities
{
    public class Donor : BaseEntity
    {
        //EF needs a parameterless constructor to instantiate the object before setting the property values
        private Donor() { }
        public Donor(string fullName, string email, DateTime birthDate, GenderEnum gender,
            double weight, BloodTypeEnum bloodType, RhFactorEnum rhFactor, Address address)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public GenderEnum Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodTypeEnum BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Donation> Donations { get; private set; }
        public void UpdateDonor(string email, double weight, Address address)
        {
            Email = email;
            Weight = weight;
            Address = address;
        }
    }
}
