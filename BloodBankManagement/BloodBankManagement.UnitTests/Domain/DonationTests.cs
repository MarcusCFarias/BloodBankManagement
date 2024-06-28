using BloodBankManagement.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.UnitTests.Domain
{
    public class DonationTests
    {
        public DonationTests()
        {

        }

        //Convenção de nome: MethodName_StateUnderTest_ExpectedBehavior
        [Fact]
        public void DonationConstructor_Initiate_ShouldReturnSameValues()
        {
            // Arrange
            int donorId = 123;
            int quantityMl = 450;
            var beforeConstruction = DateTime.Now;

            // Act
            var donation = new Donation(donorId, quantityMl);
            var afterConstruction = DateTime.Now;

            // Assert
            donation.DonorId.Should().Be(donorId);
            donation.QuantityMl.Should().Be(quantityMl);
            donation.DonationDate.Should().BeOnOrAfter(beforeConstruction);
            donation.DonationDate.Should().BeOnOrBefore(afterConstruction);
        }
    }
}
