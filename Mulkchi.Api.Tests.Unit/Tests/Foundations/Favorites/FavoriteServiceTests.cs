using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Mulkchi.Api.Brokers.Storages;
using Mulkchi.Api.Models.Foundations.Favorites;
using Mulkchi.Api.Services.Foundations.Favorites;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Favorites;

public partial class FavoriteServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly IFavoriteService favoriteService;

    public FavoriteServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.favoriteService = new FavoriteService(this.storageBrokerMock.Object);
    }

    private static Favorite CreateRandomFavorite()
    {
        var filler = new Filler<Favorite>();
        filler.Setup()
            .OnType<DateTimeOffset>().Use(() => DateTimeOffset.UtcNow)
            .OnType<DateTimeOffset?>().Use(() => (DateTimeOffset?)DateTimeOffset.UtcNow);

        return filler.Create();
    }

    private static SqlException CreateSqlException() =>
        (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));
}
