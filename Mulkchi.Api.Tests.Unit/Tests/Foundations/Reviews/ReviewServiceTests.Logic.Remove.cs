using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Reviews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Reviews;

public partial class ReviewServiceTests
{
    [Fact]
    public async Task ShouldRemoveReviewByIdAsync()
    {
        // given
        Review randomReview = CreateRandomReview();
        Review expectedReview = randomReview;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteReviewByIdAsync(randomReview.Id))
                .ReturnsAsync(expectedReview);

        // when
        Review actualReview = await this.reviewService.RemoveReviewByIdAsync(randomReview.Id);

        // then
        actualReview.Should().BeEquivalentTo(expectedReview);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteReviewByIdAsync(randomReview.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
