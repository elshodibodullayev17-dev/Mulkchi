using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.AIs;
using Mulkchi.Api.Models.Foundations.AIs.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.AiRecommendations;

public partial class AiRecommendationServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullAiRecommendation()
    {
        // given
        AiRecommendation? inputAiRecommendation = null;

        // when
        ValueTask<AiRecommendation> addAiRecommendationTask =
            this.aiRecommendationService.AddAiRecommendationAsync(inputAiRecommendation!);

        // then
        AiRecommendationValidationException actualException =
            await Assert.ThrowsAsync<AiRecommendationValidationException>(
                testCode: async () => await addAiRecommendationTask);

        actualException.InnerException.Should().BeOfType<NullAiRecommendationException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAiRecommendationAsync(It.IsAny<AiRecommendation>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        AiRecommendation randomAiRecommendation = CreateRandomAiRecommendation();
        randomAiRecommendation.Id = Guid.Empty;

        // when
        ValueTask<AiRecommendation> addAiRecommendationTask =
            this.aiRecommendationService.AddAiRecommendationAsync(randomAiRecommendation);

        // then
        await Assert.ThrowsAsync<AiRecommendationValidationException>(
            testCode: async () => await addAiRecommendationTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAiRecommendationAsync(It.IsAny<AiRecommendation>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
