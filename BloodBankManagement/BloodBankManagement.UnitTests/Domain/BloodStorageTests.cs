using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.Events;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.UnitTests.Domain
{
    public class BloodStorageTests
    {
        public BloodStorageTests()
        {
            
        }

        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var bloodType = BloodTypeEnum.A;
            var rhFactor = RhFactorEnum.Positive;
            int quantityMl = 500;

            // Act
            var bloodStorage = new BloodStorage(bloodType, rhFactor, quantityMl);

            // Assert
            bloodStorage.BloodType.Should().Be(bloodType);
            bloodStorage.RhFactor.Should().Be(rhFactor);
            bloodStorage.QuantityMl.Should().Be(quantityMl);
        }
        [Fact]
        public void AddQuantity_WhenAddingQuantity_ShouldIncreaseQuantityMl()
        {
            // Arrange
            var bloodType = BloodTypeEnum.A;
            var rhFactor = RhFactorEnum.Positive;
            int initialQuantityMl = 500;
            var bloodStorage = new BloodStorage(bloodType, rhFactor, initialQuantityMl);

            int quantityToAdd = 200;

            // Act
            bloodStorage.AddQuantity(quantityToAdd);

            // Assert
            bloodStorage.QuantityMl.Should().Be(initialQuantityMl + quantityToAdd);
        }

        [Fact]
        public void RemoveQuantity_QuantityAboveMinimum_ShouldDecreaseQuantityMl()
        {
            // Arrange
            var bloodType = BloodTypeEnum.A;
            var rhFactor = RhFactorEnum.Positive;
            int initialQuantityMl = 500;
            var bloodStorage = new BloodStorage(bloodType, rhFactor, initialQuantityMl);

            int quantityToRemove = 200;

            // Act
            bloodStorage.RemoveQuantity(quantityToRemove);

            // Assert
            bloodStorage.QuantityMl.Should().Be(initialQuantityMl - quantityToRemove);
        }

        [Fact]
        public void RemoveQuantity_QuantityBelowZero_ShouldThrowException()
        {
            // Arrange
            var bloodType = BloodTypeEnum.A;
            var rhFactor = RhFactorEnum.Positive;
            int initialQuantityMl = 500;
            var bloodStorage = new BloodStorage(bloodType, rhFactor, initialQuantityMl);

            int quantityToRemove = 600;

            // Act
            Action act = () => bloodStorage.RemoveQuantity(quantityToRemove);

            // Assert
            //Assert.Throws<Exception>(() => bloodStorage.RemoveQuantity(quantityToRemove));
            act.Should().Throw<Exception>().WithMessage("Cannot be negativa the storage");
        }

        [Fact]
        public void RemoveQuantity_QuantityBelowMinimum_ShouldRaiseEvent()
        {
            // Arrange
            var bloodType = BloodTypeEnum.A;
            var rhFactor = RhFactorEnum.Positive;
            int initialQuantityMl = 1001;
            var bloodStorage = new BloodStorage(bloodType, rhFactor, initialQuantityMl);

            int quantityToRemove = 2;

            // Act
            bloodStorage.RemoveQuantity(quantityToRemove);

            // Assert
            bloodStorage.DomainEvents.Should().ContainItemsAssignableTo<BloodStockBelowTheMinimunEvent>();
        }
    }
}
