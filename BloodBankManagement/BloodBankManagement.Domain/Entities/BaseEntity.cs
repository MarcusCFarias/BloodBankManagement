using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
    }
}
