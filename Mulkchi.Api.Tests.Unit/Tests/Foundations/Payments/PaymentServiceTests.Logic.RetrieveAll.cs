using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Payments;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Payments;

public partial class PaymentServiceTests
{
    [Fact]
    public void ShouldRetrieveAllPayments()
    {
        // given
        IQueryable<Payment> randomPayments = new List<Payment>
        {
            CreateRandomPayment(),
            CreateRandomPayment(),
            CreateRandomPayment()
        }.AsQueryable();

        IQueryable<Payment> expectedPayments = randomPayments;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllPayments())
                .Returns(expectedPayments);

        // when
        IQueryable<Payment> actualPayments = this.paymentService.RetrieveAllPayments();

        // then
        actualPayments.Should().BeEquivalentTo(expectedPayments);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllPayments(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
