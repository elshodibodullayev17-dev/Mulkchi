using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.AIs;
using Mulkchi.Api.Models.Foundations.AIs.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.AiRecommendations;

public partial class AiRecommendationServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        AiRecommendation someAiRecommendation = CreateRandomAiRecommendation();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertAiRecommendationAsync(It.IsAny<AiRecommendation>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addAiRecommendationTask = async () =>
            await this.aiRecommendationService.AddAiRecommendationAsync(someAiRecommendation);

        // then
        AiRecommendationDependencyException actualException =
            await Assert.ThrowsAsync<AiRecommendationDependencyException>(
                testCode: async () => await addAiRecommendationTask());

        actualException.InnerException.Should().BeOfType<FailedAiRecommendationStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAiRecommendationAsync(It.IsAny<AiRecommendation>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        AiRecommendation someAiRecommendation = CreateRandomAiRecommendation();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertAiRecommendationAsync(It.IsAny<AiRecommendation>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addAiRecommendationTask = async () =>
            await this.aiRecommendationService.AddAiRecommendationAsync(someAiRecommendation);

        // then
        AiRecommendationServiceException actualException =
            await Assert.ThrowsAsync<AiRecommendationServiceException>(
                testCode: async () => await addAiRecommendationTask());

        actualException.InnerException.Should().BeOfType<FailedAiRecommendationServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertAiRecommendationAsync(It.IsAny<AiRecommendation>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
