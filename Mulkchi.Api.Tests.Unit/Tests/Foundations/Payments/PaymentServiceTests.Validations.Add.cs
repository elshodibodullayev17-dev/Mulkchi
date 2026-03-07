using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Payments;
using Mulkchi.Api.Models.Foundations.Payments.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Payments;

public partial class PaymentServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullPayment()
    {
        // given
        Payment? inputPayment = null;

        // when
        ValueTask<Payment> addPaymentTask =
            this.paymentService.AddPaymentAsync(inputPayment!);

        // then
        PaymentValidationException actualException =
            await Assert.ThrowsAsync<PaymentValidationException>(
                testCode: async () => await addPaymentTask);

        actualException.InnerException.Should().BeOfType<NullPaymentException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        Payment randomPayment = CreateRandomPayment();
        randomPayment.Id = Guid.Empty;

        // when
        ValueTask<Payment> addPaymentTask =
            this.paymentService.AddPaymentAsync(randomPayment);

        // then
        await Assert.ThrowsAsync<PaymentValidationException>(
            testCode: async () => await addPaymentTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
