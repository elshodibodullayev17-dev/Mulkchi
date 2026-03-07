using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.Discounts;
using Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Discounts;

public partial class DiscountServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        Discount someDiscount = CreateRandomDiscount();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertDiscountAsync(It.IsAny<Discount>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addDiscountTask = async () =>
            await this.discountService.AddDiscountAsync(someDiscount);

        // then
        DiscountDependencyException actualException =
            await Assert.ThrowsAsync<DiscountDependencyException>(
                testCode: async () => await addDiscountTask());

        actualException.InnerException.Should().BeOfType<FailedDiscountStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertDiscountAsync(It.IsAny<Discount>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        Discount someDiscount = CreateRandomDiscount();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertDiscountAsync(It.IsAny<Discount>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addDiscountTask = async () =>
            await this.discountService.AddDiscountAsync(someDiscount);

        // then
        DiscountServiceException actualException =
            await Assert.ThrowsAsync<DiscountServiceException>(
                testCode: async () => await addDiscountTask());

        actualException.InnerException.Should().BeOfType<FailedDiscountServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertDiscountAsync(It.IsAny<Discount>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
