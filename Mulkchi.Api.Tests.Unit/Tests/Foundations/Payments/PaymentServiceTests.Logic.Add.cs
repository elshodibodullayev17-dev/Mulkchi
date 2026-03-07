using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Payments;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Payments;

public partial class PaymentServiceTests
{
    [Fact]
    public async Task ShouldAddPaymentAsync()
    {
        // given
        Payment randomPayment = CreateRandomPayment();
        Payment inputPayment = randomPayment;
        Payment expectedPayment = inputPayment;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPaymentAsync(inputPayment))
                .ReturnsAsync(expectedPayment);

        // when
        Payment actualPayment = await this.paymentService.AddPaymentAsync(inputPayment);

        // then
        actualPayment.Should().BeEquivalentTo(expectedPayment);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(inputPayment),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
