using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.AIs;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.AiRecommendations;

public partial class AiRecommendationServiceTests
{
    [Fact]
    public async Task ShouldModifyAiRecommendationAsync()
    {
        // given
        DateTimeOffset randomDateTimeOffset = DateTimeOffset.UtcNow;
        AiRecommendation randomAiRecommendation = CreateRandomAiRecommendation();
        AiRecommendation inputAiRecommendation = randomAiRecommendation;
        inputAiRecommendation.UpdatedDate = randomDateTimeOffset;
        AiRecommendation expectedAiRecommendation = inputAiRecommendation;

        this.dateTimeBrokerMock.Setup(broker =>
            broker.GetCurrentDateTimeOffset())
                .Returns(randomDateTimeOffset);

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateAiRecommendationAsync(inputAiRecommendation))
                .ReturnsAsync(expectedAiRecommendation);

        // when
        AiRecommendation actualAiRecommendation = await this.aiRecommendationService.ModifyAiRecommendationAsync(inputAiRecommendation);

        // then
        actualAiRecommendation.Should().BeEquivalentTo(expectedAiRecommendation);

        this.dateTimeBrokerMock.Verify(broker =>
            broker.GetCurrentDateTimeOffset(),
            Times.Once);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateAiRecommendationAsync(inputAiRecommendation),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
