using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.Payments;
using Mulkchi.Api.Models.Foundations.Payments.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Payments;

public partial class PaymentServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        Payment somePayment = CreateRandomPayment();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addPaymentTask = async () =>
            await this.paymentService.AddPaymentAsync(somePayment);

        // then
        PaymentDependencyException actualException =
            await Assert.ThrowsAsync<PaymentDependencyException>(
                testCode: async () => await addPaymentTask());

        actualException.InnerException.Should().BeOfType<FailedPaymentStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()),
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
        Payment somePayment = CreateRandomPayment();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addPaymentTask = async () =>
            await this.paymentService.AddPaymentAsync(somePayment);

        // then
        PaymentServiceException actualException =
            await Assert.ThrowsAsync<PaymentServiceException>(
                testCode: async () => await addPaymentTask());

        actualException.InnerException.Should().BeOfType<FailedPaymentServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
