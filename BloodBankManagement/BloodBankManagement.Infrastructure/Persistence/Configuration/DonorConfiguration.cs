using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure.Persistence.Configuration
{
    internal class DonorConfiguration : BaseEntityConfiguration<Donor>
    {
        public override void Configure(EntityTypeBuilder<Donor> builder)
        {
            base.Configure(builder);

            builder.ToTable("Donor");

            builder.Property(p => p.FullName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.BirthDate)
                .IsRequired();

            builder.Property(p => p.Gender)
                .IsRequired();

            builder.Property(p => p.Weight)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(p => p.BloodType)
                .IsRequired();

            builder.Property(p => p.RhFactor)
                .IsRequired();

            builder.HasMany(p => p.Donations)
                .WithOne(p => p.Donor)
                .HasForeignKey(p => p.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(p => p.City).HasMaxLength(25).IsRequired();
                address.Property(p => p.PublicArea).HasMaxLength(50).IsRequired();
                address.Property(p => p.State).HasMaxLength(25).IsRequired();
                address.Property(p => p.ZipCode).HasMaxLength(9).IsRequired();
            });

            //builder.HasData(
            //    new Donor("Marcus", "marcus@marcus.com", DateTime.Now, GenderEnum.Male, 70, BloodTypeEnum.O, RhFactorEnum.Negative, new Address("xxxxxxxx", "yyyyyyyy", "zzzzzzzz", ".........")));
        }
    }
}
