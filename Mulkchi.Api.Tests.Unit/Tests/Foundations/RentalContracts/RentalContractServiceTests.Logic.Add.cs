using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.RentalContracts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.RentalContracts;

public partial class RentalContractServiceTests
{
    [Fact]
    public async Task ShouldAddRentalContractAsync()
    {
        // given
        RentalContract randomRentalContract = CreateRandomRentalContract();
        RentalContract inputRentalContract = randomRentalContract;
        RentalContract expectedRentalContract = inputRentalContract;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertRentalContractAsync(inputRentalContract))
                .ReturnsAsync(expectedRentalContract);

        // when
        RentalContract actualRentalContract = await this.rentalContractService.AddRentalContractAsync(inputRentalContract);

        // then
        actualRentalContract.Should().BeEquivalentTo(expectedRentalContract);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertRentalContractAsync(inputRentalContract),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
