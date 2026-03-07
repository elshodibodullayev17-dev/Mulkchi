using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Discounts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Discounts;

public partial class DiscountServiceTests
{
    [Fact]
    public async Task ShouldAddDiscountAsync()
    {
        // given
        Discount randomDiscount = CreateRandomDiscount();
        Discount inputDiscount = randomDiscount;
        Discount expectedDiscount = inputDiscount;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertDiscountAsync(inputDiscount))
                .ReturnsAsync(expectedDiscount);

        // when
        Discount actualDiscount = await this.discountService.AddDiscountAsync(inputDiscount);

        // then
        actualDiscount.Should().BeEquivalentTo(expectedDiscount);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertDiscountAsync(inputDiscount),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
