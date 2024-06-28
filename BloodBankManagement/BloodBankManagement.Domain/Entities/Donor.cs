using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.Repositories;
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
            Donations = new List<Donation>();
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
        public bool CanDonateBlood(int quantityMl)
        {
            if (!ValidQuantityToDonate(quantityMl))
                return false;

            if (!ValidWeightToDonate(Weight))
                return false;

            if (!ValidAgeToDonate(BirthDate))
                return false;
            
            //var lastDonation = Donations.LastOrDefault();
            //if (lastDonation != null)
            //{
            //    if (!ValidDonationInterval(lastDonation.DonationDate))
            //        return false;
            //}

            return true;
        }
        //private bool ValidDonationInterval(DateTime lastDonationDate)
        //{
        //    int minimumDaysBetweenDonations = Gender == GenderEnum.Male ? -60 : -90;
        //    return DateTime.Now.AddDays(minimumDaysBetweenDonations) > lastDonationDate;
        //}
        private bool ValidWeightToDonate(double weight)
        {
            double minimumWeight = 50;
            return weight >= minimumWeight;
        }
        private bool ValidAgeToDonate(DateTime birthDate)
        {
            int majorAge = 18;
            return (DateTime.Now.Year - birthDate.Year) >= majorAge;
        }
        private bool ValidQuantityToDonate(int quantityMl)
        {
            int minimumQuantityMl = 420;
            int maximumQuantityMl = 470;
            return quantityMl >= minimumQuantityMl && quantityMl <= maximumQuantityMl;
        }
    }
}
