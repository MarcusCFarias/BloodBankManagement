using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Entities
{
    public class BloodStorage : BaseEntity
    {
        
        public BloodStorage(BloodTypeEnum bloodType, RhFactorEnum rhFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }
        public BloodTypeEnum BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public int QuantityMl { get; private set; }

        public void AddQuantity(int quantityMl)
        {
            QuantityMl += quantityMl;
        }
        public void RemoveQuantity(int quantityMl)
        {
            QuantityMl -= quantityMl;

            if (QuantityMl < 0)
                throw new Exception("Cannot be negativa the storage");

            int minimumQuantity = 1000;
            if (QuantityMl < minimumQuantity)
                AddDomainEvent(new BloodStockBelowTheMinimunEvent(Id));
        }
    }
}
