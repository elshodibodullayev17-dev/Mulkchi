using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.RentalContracts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.RentalContracts;

public partial class RentalContractServiceTests
{
    [Fact]
    public async Task ShouldRetrieveRentalContractByIdAsync()
    {
        // given
        RentalContract randomRentalContract = CreateRandomRentalContract();
        RentalContract expectedRentalContract = randomRentalContract;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectRentalContractByIdAsync(randomRentalContract.Id))
                .ReturnsAsync(expectedRentalContract);

        // when
        RentalContract actualRentalContract = await this.rentalContractService.RetrieveRentalContractByIdAsync(randomRentalContract.Id);

        // then
        actualRentalContract.Should().BeEquivalentTo(expectedRentalContract);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectRentalContractByIdAsync(randomRentalContract.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
