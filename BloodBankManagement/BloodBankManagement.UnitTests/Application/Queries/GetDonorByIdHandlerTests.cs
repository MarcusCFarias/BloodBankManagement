using BloodBankManagement.Application.Features.Common.Result;
using BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery;
using BloodBankManagement.Domain.Entities;
using BloodBankManagement.Domain.Enums;
using BloodBankManagement.Domain.Repositories;
using BloodBankManagement.Domain.ValueObjects;
using Bogus;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.UnitTests.Application.Queries
{
    public class GetDonorByIdHandlerTests
    {
        //Convenção de nome: MethodName_StateUnderTest_ExpectedBehavior
        private readonly Donor _donor;
        private readonly Address _address;
        private readonly Mock<IDonorRepository> _mock;
        public GetDonorByIdHandlerTests()
        {
            _mock = new Mock<IDonorRepository>();

            _address = new Faker<Address>()
               .StrictMode(false)
               .CustomInstantiator(f => new Address(
                                         f.Address.StreetName(),
                                         f.Address.City(),
                                         f.Address.State(),
                                         f.Address.ZipCode())).Generate();
            _donor = new Faker<Donor>()
                 .StrictMode(false)
                 .CustomInstantiator(f => new Donor(
                                        f.Person.FullName,
                                        f.Person.Email,
                                        f.Date.Recent(),
                                        f.PickRandom<GenderEnum>(),
                                        f.Random.Int(),
                                        f.PickRandom<BloodTypeEnum>(),
                                        f.PickRandom<RhFactorEnum>(),
                                        _address
                                        )).Generate();
        }

        [Fact]
        public async Task Handle_WhenDonorExists_ReturnsDonorDetailViewModel()
        {
            //Arrange

            var donorId = It.IsAny<int>();
            _mock.Setup(x => x.GetByIdAsync(donorId, default)).ReturnsAsync(_donor);

            var handler = new GetDonorByIdQueryHandler(_mock.Object);

            //Act
            var result = await handler.Handle(new GetDonorByIdQuery(donorId), default);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.FullName.Should().Be(_donor.FullName);
            result.Data.Email.Should().Be(_donor.Email);
            result.Data.BirthDate.Should().Be(_donor.BirthDate);
            result.Data.Gender.Should().Be(_donor.Gender.ToString());
            result.Data.Weight.Should().Be(_donor.Weight);
            result.Data.BloodType.Should().Be(_donor.BloodType.ToString());
            result.Data.RhFactor.Should().Be(_donor.RhFactor.ToString());
            result.Data.Address.Should().Be(_donor.Address);
        }

        [Fact]
        public async Task Handle_WhenDonorNotExists_ReturnsError()
        {
            //Arrange
            var donorId = 1;
            _mock.Setup(x => x.GetByIdAsync(donorId, default)).ReturnsAsync(() => null);

            var handler = new GetDonorByIdQueryHandler(_mock.Object);

            //Act
            var result = await handler.Handle(new GetDonorByIdQuery(donorId), default);

            //Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().NotBeNull();
            result.Error.Should().BeEquivalentTo(new ErrorModel(ErrorEnum.NotFound, ErrorEnum.NotFound.ToString(), "Donor couldn't be found."));   
        }
    }
}
