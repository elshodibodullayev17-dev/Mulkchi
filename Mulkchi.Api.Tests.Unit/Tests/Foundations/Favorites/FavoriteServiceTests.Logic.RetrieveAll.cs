using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Favorites;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Favorites;

public partial class FavoriteServiceTests
{
    [Fact]
    public void ShouldRetrieveAllFavorites()
    {
        // given
        IQueryable<Favorite> randomFavorites = new List<Favorite>
        {
            CreateRandomFavorite(),
            CreateRandomFavorite(),
            CreateRandomFavorite()
        }.AsQueryable();

        IQueryable<Favorite> expectedFavorites = randomFavorites;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllFavorites())
                .Returns(expectedFavorites);

        // when
        IQueryable<Favorite> actualFavorites = this.favoriteService.RetrieveAllFavorites();

        // then
        actualFavorites.Should().BeEquivalentTo(expectedFavorites);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllFavorites(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
