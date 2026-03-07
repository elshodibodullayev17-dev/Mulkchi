using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Favorites;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Favorites;

public partial class FavoriteServiceTests
{
    [Fact]
    public async Task ShouldModifyFavoriteAsync()
    {
        // given
        Favorite randomFavorite = CreateRandomFavorite();
        Favorite inputFavorite = randomFavorite;
        Favorite expectedFavorite = inputFavorite;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateFavoriteAsync(inputFavorite))
                .ReturnsAsync(expectedFavorite);

        // when
        Favorite actualFavorite = await this.favoriteService.ModifyFavoriteAsync(inputFavorite);

        // then
        actualFavorite.Should().BeEquivalentTo(expectedFavorite);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateFavoriteAsync(inputFavorite),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
