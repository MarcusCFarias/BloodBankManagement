using Bogus;
using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.ValueObjects;
using FluentAssertions;
using System.Security.Cryptography;
using System;



namespace BloodBankManagement.UnitTests.Domain
{
    public class DonorTests
    {
        //Convenção de nome: MethodName_StateUnderTest_ExpectedBehavior

        private readonly Faker _faker;
        private readonly Address _address;
        public DonorTests()
        {
            _faker = new Faker();
            _address = new Faker<Address>()
               .StrictMode(false)
               .CustomInstantiator(f => new Address(
                                         f.Address.StreetName(),
                                         f.Address.City(),
                                         f.Address.State(),
                                         f.Address.ZipCode())).Generate();
        }

        /*
        CanDonateBlood depende de:
            - Peso do doador
            - Idade do doador
            - Quantidade de sangue a ser doada
            - Data da última doação e gênero do doador
         */

        [Theory]
        [InlineData(419, 49, 17, false)]
        [InlineData(419, 49, 18, false)]
        [InlineData(419, 49, 19, false)]
        [InlineData(419, 50, 17, false)]
        [InlineData(419, 50, 18, false)]
        [InlineData(419, 50, 19, false)]
        [InlineData(419, 51, 17, false)]
        [InlineData(419, 51, 18, false)]
        [InlineData(419, 51, 19, false)]
        [InlineData(471, 49, 17, false)]
        [InlineData(471, 49, 18, false)]
        [InlineData(471, 49, 19, false)]
        [InlineData(471, 50, 17, false)]
        [InlineData(471, 50, 18, false)]
        [InlineData(471, 50, 19, false)]
        [InlineData(471, 51, 17, false)]
        [InlineData(471, 51, 18, false)]
        [InlineData(471, 51, 19, false)]
        [InlineData(450, 49, 17, false)]
        [InlineData(450, 49, 18, false)]
        [InlineData(450, 49, 19, false)]
        [InlineData(450, 50, 17, false)]
        [InlineData(450, 50, 18, true)]
        [InlineData(450, 50, 19, true)]
        [InlineData(450, 51, 17, false)]
        [InlineData(450, 51, 18, true)]
        [InlineData(450, 51, 19, true)]
        public void CanDonateBlood_AllConditions_ReturnExpectedResult(int quantityMl,
                                                                      double weight,
                                                                      int age,

                                                                      bool expectedResult)
        {
            //arrange
            var donor = new Faker<Donor>()
                .StrictMode(false)
                .CustomInstantiator(f => new Donor(
                                       f.Person.FullName,
                                       f.Person.Email,
                                       DateTime.Now.AddYears(-age),
                                       f.PickRandom<GenderEnum>(),
                                       weight,
                                       f.PickRandom<BloodTypeEnum>(),
                                       f.PickRandom<RhFactorEnum>(),
                                       _address
                                       )).Generate();

            //act
            var result = donor.CanDonateBlood(quantityMl);

            //assert
            result.Should().Be(expectedResult);
        }
    }
}
