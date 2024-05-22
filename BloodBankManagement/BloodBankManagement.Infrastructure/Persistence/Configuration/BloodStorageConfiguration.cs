using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure.Persistence.Configuration
{
    internal class BloodStorageConfiguration : BaseEntityConfiguration<BloodStorage>
    {
        public override void Configure(EntityTypeBuilder<BloodStorage> builder)
        {
            base.Configure(builder);

            builder.ToTable("BloodStorage");

            builder.Property(e => e.BloodType)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.RhFactor)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.QuantityMl)
                .HasColumnType("int")
                .IsRequired();

            //builder.HasData(
            //    new BloodStorage(BloodTypeEnum.O, RhFactorEnum.Negative, 500));
        }
    }
}
