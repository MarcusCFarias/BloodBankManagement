using BloodBankManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Events
{
    public class BloodStockBelowTheMinimunEvent : IDomainEvent
    {
        public BloodStockBelowTheMinimunEvent(int bloodStockId)
        {
            BloodStockId = bloodStockId;
        }
        public int BloodStockId { get; private set; }
    }
}
