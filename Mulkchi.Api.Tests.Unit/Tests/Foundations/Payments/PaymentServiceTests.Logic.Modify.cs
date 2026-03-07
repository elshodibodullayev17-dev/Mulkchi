using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Payments;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Payments;

public partial class PaymentServiceTests
{
    [Fact]
    public async Task ShouldModifyPaymentAsync()
    {
        // given
        Payment randomPayment = CreateRandomPayment();
        Payment inputPayment = randomPayment;
        Payment expectedPayment = inputPayment;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdatePaymentAsync(inputPayment))
                .ReturnsAsync(expectedPayment);

        // when
        Payment actualPayment = await this.paymentService.ModifyPaymentAsync(inputPayment);

        // then
        actualPayment.Should().BeEquivalentTo(expectedPayment);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdatePaymentAsync(inputPayment),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
