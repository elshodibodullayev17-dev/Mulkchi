using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.RentalContracts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.RentalContracts;

public partial class RentalContractServiceTests
{
    [Fact]
    public async Task ShouldRemoveRentalContractByIdAsync()
    {
        // given
        RentalContract randomRentalContract = CreateRandomRentalContract();
        RentalContract expectedRentalContract = randomRentalContract;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteRentalContractByIdAsync(randomRentalContract.Id))
                .ReturnsAsync(expectedRentalContract);

        // when
        RentalContract actualRentalContract = await this.rentalContractService.RemoveRentalContractByIdAsync(randomRentalContract.Id);

        // then
        actualRentalContract.Should().BeEquivalentTo(expectedRentalContract);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteRentalContractByIdAsync(randomRentalContract.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
