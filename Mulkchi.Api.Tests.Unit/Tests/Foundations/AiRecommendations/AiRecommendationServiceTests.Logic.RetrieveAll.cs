using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.AIs;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.AiRecommendations;

public partial class AiRecommendationServiceTests
{
    [Fact]
    public void ShouldRetrieveAllAiRecommendations()
    {
        // given
        IQueryable<AiRecommendation> randomAiRecommendations = new List<AiRecommendation>
        {
            CreateRandomAiRecommendation(),
            CreateRandomAiRecommendation(),
            CreateRandomAiRecommendation()
        }.AsQueryable();

        IQueryable<AiRecommendation> expectedAiRecommendations = randomAiRecommendations;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllAiRecommendations())
                .Returns(expectedAiRecommendations);

        // when
        IQueryable<AiRecommendation> actualAiRecommendations = this.aiRecommendationService.RetrieveAllAiRecommendations();

        // then
        actualAiRecommendations.Should().BeEquivalentTo(expectedAiRecommendations);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllAiRecommendations(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
