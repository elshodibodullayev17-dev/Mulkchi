using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Payments;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Payments;

public partial class PaymentServiceTests
{
    [Fact]
    public async Task ShouldRemovePaymentByIdAsync()
    {
        // given
        Payment randomPayment = CreateRandomPayment();
        Payment expectedPayment = randomPayment;

        this.storageBrokerMock.Setup(broker =>
            broker.DeletePaymentByIdAsync(randomPayment.Id))
                .ReturnsAsync(expectedPayment);

        // when
        Payment actualPayment = await this.paymentService.RemovePaymentByIdAsync(randomPayment.Id);

        // then
        actualPayment.Should().BeEquivalentTo(expectedPayment);

        this.storageBrokerMock.Verify(broker =>
            broker.DeletePaymentByIdAsync(randomPayment.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
