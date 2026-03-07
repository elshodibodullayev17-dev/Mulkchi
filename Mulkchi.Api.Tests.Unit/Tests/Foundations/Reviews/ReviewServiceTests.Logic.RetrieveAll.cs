using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Reviews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Reviews;

public partial class ReviewServiceTests
{
    [Fact]
    public void ShouldRetrieveAllReviews()
    {
        // given
        IQueryable<Review> randomReviews = new List<Review>
        {
            CreateRandomReview(),
            CreateRandomReview(),
            CreateRandomReview()
        }.AsQueryable();

        IQueryable<Review> expectedReviews = randomReviews;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllReviews())
                .Returns(expectedReviews);

        // when
        IQueryable<Review> actualReviews = this.reviewService.RetrieveAllReviews();

        // then
        actualReviews.Should().BeEquivalentTo(expectedReviews);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllReviews(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
