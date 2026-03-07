using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Favorites;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Favorites;

public partial class FavoriteServiceTests
{
    [Fact]
    public async Task ShouldRemoveFavoriteByIdAsync()
    {
        // given
        Favorite randomFavorite = CreateRandomFavorite();
        Favorite expectedFavorite = randomFavorite;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteFavoriteByIdAsync(randomFavorite.Id))
                .ReturnsAsync(expectedFavorite);

        // when
        Favorite actualFavorite = await this.favoriteService.RemoveFavoriteByIdAsync(randomFavorite.Id);

        // then
        actualFavorite.Should().BeEquivalentTo(expectedFavorite);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteFavoriteByIdAsync(randomFavorite.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
