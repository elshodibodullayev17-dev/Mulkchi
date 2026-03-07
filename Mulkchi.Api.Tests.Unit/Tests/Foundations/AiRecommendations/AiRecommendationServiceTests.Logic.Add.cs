using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.AIs;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.AiRecommendations;

public partial class AiRecommendationServiceTests
{
    [Fact]
    public async Task ShouldAddAiRecommendationAsync()
    {
        // given
        AiRecommendation randomAiRecommendation = CreateRandomAiRecommendation();
        AiRecommendation inputAiRecommendation = randomAiRecommendation;
        AiRecommendation expectedAiRecommendation = inputAiRecommendation;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertAiRecommendationAsync(inputAiRecommendation))
                .ReturnsAsync(expectedAiRecommendation);

        // when
        AiRecommendation actualAiRecommendation = await this.aiRecommendationService.AddAiRecommendationAsync(inputAiRecommendation);

        // then
        actualAiRecommendation.Should().BeEquivalentTo(expectedAiRecommendation);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAiRecommendationAsync(inputAiRecommendation),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
