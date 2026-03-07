using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Reviews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Reviews;

public partial class ReviewServiceTests
{
    [Fact]
    public async Task ShouldModifyReviewAsync()
    {
        // given
        Review randomReview = CreateRandomReview();
        Review inputReview = randomReview;
        Review expectedReview = inputReview;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateReviewAsync(inputReview))
                .ReturnsAsync(expectedReview);

        // when
        Review actualReview = await this.reviewService.ModifyReviewAsync(inputReview);

        // then
        actualReview.Should().BeEquivalentTo(expectedReview);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateReviewAsync(inputReview),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
