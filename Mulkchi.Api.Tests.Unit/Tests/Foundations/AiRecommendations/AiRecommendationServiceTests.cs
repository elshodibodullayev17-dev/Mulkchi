using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Mulkchi.Api.Brokers.Storages;
using Mulkchi.Api.Models.Foundations.AIs;
using Mulkchi.Api.Services.Foundations.AiRecommendations;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.AiRecommendations;

public partial class AiRecommendationServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly IAiRecommendationService aiRecommendationService;

    public AiRecommendationServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.aiRecommendationService = new AiRecommendationService(this.storageBrokerMock.Object);
    }

    private static AiRecommendation CreateRandomAiRecommendation()
    {
        var filler = new Filler<AiRecommendation>();
        filler.Setup()
            .OnType<DateTimeOffset>().Use(() => DateTimeOffset.UtcNow)
            .OnType<DateTimeOffset?>().Use(() => (DateTimeOffset?)DateTimeOffset.UtcNow);

        return filler.Create();
    }

    private static SqlException CreateSqlException() =>
        (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));
}
