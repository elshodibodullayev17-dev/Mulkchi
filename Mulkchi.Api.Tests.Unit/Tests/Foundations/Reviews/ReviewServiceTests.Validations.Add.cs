using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Reviews;
using Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Reviews;

public partial class ReviewServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullReview()
    {
        // given
        Review? inputReview = null;

        // when
        ValueTask<Review> addReviewTask =
            this.reviewService.AddReviewAsync(inputReview!);

        // then
        ReviewValidationException actualException =
            await Assert.ThrowsAsync<ReviewValidationException>(
                testCode: async () => await addReviewTask);

        actualException.InnerException.Should().BeOfType<NullReviewException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertReviewAsync(It.IsAny<Review>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        Review randomReview = CreateRandomReview();
        randomReview.Id = Guid.Empty;

        // when
        ValueTask<Review> addReviewTask =
            this.reviewService.AddReviewAsync(randomReview);

        // then
        await Assert.ThrowsAsync<ReviewValidationException>(
            testCode: async () => await addReviewTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertReviewAsync(It.IsAny<Review>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
