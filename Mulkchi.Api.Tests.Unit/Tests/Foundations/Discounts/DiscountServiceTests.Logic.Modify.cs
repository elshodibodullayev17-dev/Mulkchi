using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Discounts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Discounts;

public partial class DiscountServiceTests
{
    [Fact]
    public async Task ShouldModifyDiscountAsync()
    {
        // given
        Discount randomDiscount = CreateRandomDiscount();
        Discount inputDiscount = randomDiscount;
        Discount expectedDiscount = inputDiscount;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateDiscountAsync(inputDiscount))
                .ReturnsAsync(expectedDiscount);

        // when
        Discount actualDiscount = await this.discountService.ModifyDiscountAsync(inputDiscount);

        // then
        actualDiscount.Should().BeEquivalentTo(expectedDiscount);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateDiscountAsync(inputDiscount),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
