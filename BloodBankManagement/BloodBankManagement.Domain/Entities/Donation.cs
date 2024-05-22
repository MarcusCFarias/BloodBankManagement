using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(int donorId, int quantityMl)
        {
            DonorId = donorId;
            DonationDate = DateTime.Now;
            QuantityMl = quantityMl;
        }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityMl { get; private set; }
        public Donor Donor { get; private set; }
    }
}
