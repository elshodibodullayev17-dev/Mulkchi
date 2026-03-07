using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Discounts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Discounts;

public partial class DiscountServiceTests
{
    [Fact]
    public async Task ShouldRemoveDiscountByIdAsync()
    {
        // given
        Discount randomDiscount = CreateRandomDiscount();
        Discount expectedDiscount = randomDiscount;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteDiscountByIdAsync(randomDiscount.Id))
                .ReturnsAsync(expectedDiscount);

        // when
        Discount actualDiscount = await this.discountService.RemoveDiscountByIdAsync(randomDiscount.Id);

        // then
        actualDiscount.Should().BeEquivalentTo(expectedDiscount);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteDiscountByIdAsync(randomDiscount.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
