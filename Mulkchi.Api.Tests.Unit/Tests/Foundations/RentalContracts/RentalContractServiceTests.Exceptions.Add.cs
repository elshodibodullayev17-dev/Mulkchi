using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.RentalContracts;
using Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.RentalContracts;

public partial class RentalContractServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        RentalContract someRentalContract = CreateRandomRentalContract();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertRentalContractAsync(It.IsAny<RentalContract>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addRentalContractTask = async () =>
            await this.rentalContractService.AddRentalContractAsync(someRentalContract);

        // then
        RentalContractDependencyException actualException =
            await Assert.ThrowsAsync<RentalContractDependencyException>(
                testCode: async () => await addRentalContractTask());

        actualException.InnerException.Should().BeOfType<FailedRentalContractStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertRentalContractAsync(It.IsAny<RentalContract>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        RentalContract someRentalContract = CreateRandomRentalContract();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertRentalContractAsync(It.IsAny<RentalContract>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addRentalContractTask = async () =>
            await this.rentalContractService.AddRentalContractAsync(someRentalContract);

        // then
        RentalContractServiceException actualException =
            await Assert.ThrowsAsync<RentalContractServiceException>(
                testCode: async () => await addRentalContractTask());

        actualException.InnerException.Should().BeOfType<FailedRentalContractServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertRentalContractAsync(It.IsAny<RentalContract>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
