using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.RentalContracts;
using Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.RentalContracts;

public partial class RentalContractServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullRentalContract()
    {
        // given
        RentalContract? inputRentalContract = null;

        // when
        ValueTask<RentalContract> addRentalContractTask =
            this.rentalContractService.AddRentalContractAsync(inputRentalContract!);

        // then
        RentalContractValidationException actualException =
            await Assert.ThrowsAsync<RentalContractValidationException>(
                testCode: async () => await addRentalContractTask);

        actualException.InnerException.Should().BeOfType<NullRentalContractException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertRentalContractAsync(It.IsAny<RentalContract>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        RentalContract randomRentalContract = CreateRandomRentalContract();
        randomRentalContract.Id = Guid.Empty;

        // when
        ValueTask<RentalContract> addRentalContractTask =
            this.rentalContractService.AddRentalContractAsync(randomRentalContract);

        // then
        await Assert.ThrowsAsync<RentalContractValidationException>(
            testCode: async () => await addRentalContractTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertRentalContractAsync(It.IsAny<RentalContract>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
