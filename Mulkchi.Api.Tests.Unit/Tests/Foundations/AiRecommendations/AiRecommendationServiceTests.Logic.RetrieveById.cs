using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.AIs;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.AiRecommendations;

public partial class AiRecommendationServiceTests
{
    [Fact]
    public async Task ShouldRetrieveAiRecommendationByIdAsync()
    {
        // given
        AiRecommendation randomAiRecommendation = CreateRandomAiRecommendation();
        AiRecommendation expectedAiRecommendation = randomAiRecommendation;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAiRecommendationByIdAsync(randomAiRecommendation.Id))
                .ReturnsAsync(expectedAiRecommendation);

        // when
        AiRecommendation actualAiRecommendation = await this.aiRecommendationService.RetrieveAiRecommendationByIdAsync(randomAiRecommendation.Id);

        // then
        actualAiRecommendation.Should().BeEquivalentTo(expectedAiRecommendation);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAiRecommendationByIdAsync(randomAiRecommendation.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
