using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.RentalContracts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.RentalContracts;

public partial class RentalContractServiceTests
{
    [Fact]
    public void ShouldRetrieveAllRentalContracts()
    {
        // given
        IQueryable<RentalContract> randomRentalContracts = new List<RentalContract>
        {
            CreateRandomRentalContract(),
            CreateRandomRentalContract(),
            CreateRandomRentalContract()
        }.AsQueryable();

        IQueryable<RentalContract> expectedRentalContracts = randomRentalContracts;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllRentalContracts())
                .Returns(expectedRentalContracts);

        // when
        IQueryable<RentalContract> actualRentalContracts = this.rentalContractService.RetrieveAllRentalContracts();

        // then
        actualRentalContracts.Should().BeEquivalentTo(expectedRentalContracts);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllRentalContracts(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
