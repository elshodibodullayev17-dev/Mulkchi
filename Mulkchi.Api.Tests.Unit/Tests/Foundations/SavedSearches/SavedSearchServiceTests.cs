using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Mulkchi.Api.Brokers.Storages;
using Mulkchi.Api.Models.Foundations.SavedSearches;
using Mulkchi.Api.Services.Foundations.SavedSearches;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.SavedSearches;

public partial class SavedSearchServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly ISavedSearchService savedSearchService;

    public SavedSearchServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.savedSearchService = new SavedSearchService(this.storageBrokerMock.Object);
    }

    private static SavedSearch CreateRandomSavedSearch()
    {
        var filler = new Filler<SavedSearch>();
        filler.Setup()
            .OnType<DateTimeOffset>().Use(() => DateTimeOffset.UtcNow)
            .OnType<DateTimeOffset?>().Use(() => (DateTimeOffset?)DateTimeOffset.UtcNow);

        return filler.Create();
    }

    private static SqlException CreateSqlException() =>
        (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));
}
