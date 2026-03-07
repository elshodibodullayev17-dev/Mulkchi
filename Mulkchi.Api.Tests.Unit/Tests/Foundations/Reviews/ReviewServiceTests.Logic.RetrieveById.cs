using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Reviews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Reviews;

public partial class ReviewServiceTests
{
    [Fact]
    public async Task ShouldRetrieveReviewByIdAsync()
    {
        // given
        Review randomReview = CreateRandomReview();
        Review expectedReview = randomReview;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectReviewByIdAsync(randomReview.Id))
                .ReturnsAsync(expectedReview);

        // when
        Review actualReview = await this.reviewService.RetrieveReviewByIdAsync(randomReview.Id);

        // then
        actualReview.Should().BeEquivalentTo(expectedReview);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectReviewByIdAsync(randomReview.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
