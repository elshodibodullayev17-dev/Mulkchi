using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Discounts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Discounts;

public partial class DiscountServiceTests
{
    [Fact]
    public void ShouldRetrieveAllDiscounts()
    {
        // given
        IQueryable<Discount> randomDiscounts = new List<Discount>
        {
            CreateRandomDiscount(),
            CreateRandomDiscount(),
            CreateRandomDiscount()
        }.AsQueryable();

        IQueryable<Discount> expectedDiscounts = randomDiscounts;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllDiscounts())
                .Returns(expectedDiscounts);

        // when
        IQueryable<Discount> actualDiscounts = this.discountService.RetrieveAllDiscounts();

        // then
        actualDiscounts.Should().BeEquivalentTo(expectedDiscounts);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllDiscounts(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
