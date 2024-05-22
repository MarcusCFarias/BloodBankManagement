using BloodBankManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure.Persistence.Configuration
{
    internal class DonationConfiguration : BaseEntityConfiguration<Donation>
    {
        public override void Configure(EntityTypeBuilder<Donation> builder)
        {
            base.Configure(builder);

            builder.ToTable("Donation");

            builder.Property(p => p.DonationDate)
                .IsRequired();

            builder.Property(p => p.QuantityMl)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.DonorId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(p => p.Donor)
                .WithMany()
                .HasForeignKey(p => p.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(
            //    new Donation(1, 500));
        }
    }
}
