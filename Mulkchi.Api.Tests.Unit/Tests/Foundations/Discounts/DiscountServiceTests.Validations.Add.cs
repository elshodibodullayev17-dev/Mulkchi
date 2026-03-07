using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Discounts;
using Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Discounts;

public partial class DiscountServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullDiscount()
    {
        // given
        Discount? inputDiscount = null;

        // when
        ValueTask<Discount> addDiscountTask =
            this.discountService.AddDiscountAsync(inputDiscount!);

        // then
        DiscountValidationException actualException =
            await Assert.ThrowsAsync<DiscountValidationException>(
                testCode: async () => await addDiscountTask);

        actualException.InnerException.Should().BeOfType<NullDiscountException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertDiscountAsync(It.IsAny<Discount>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        Discount randomDiscount = CreateRandomDiscount();
        randomDiscount.Id = Guid.Empty;

        // when
        ValueTask<Discount> addDiscountTask =
            this.discountService.AddDiscountAsync(randomDiscount);

        // then
        await Assert.ThrowsAsync<DiscountValidationException>(
            testCode: async () => await addDiscountTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertDiscountAsync(It.IsAny<Discount>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
