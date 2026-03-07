using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.Favorites;
using Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Favorites;

public partial class FavoriteServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        Favorite someFavorite = CreateRandomFavorite();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertFavoriteAsync(It.IsAny<Favorite>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addFavoriteTask = async () =>
            await this.favoriteService.AddFavoriteAsync(someFavorite);

        // then
        FavoriteDependencyException actualException =
            await Assert.ThrowsAsync<FavoriteDependencyException>(
                testCode: async () => await addFavoriteTask());

        actualException.InnerException.Should().BeOfType<FailedFavoriteStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertFavoriteAsync(It.IsAny<Favorite>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        Favorite someFavorite = CreateRandomFavorite();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertFavoriteAsync(It.IsAny<Favorite>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addFavoriteTask = async () =>
            await this.favoriteService.AddFavoriteAsync(someFavorite);

        // then
        FavoriteServiceException actualException =
            await Assert.ThrowsAsync<FavoriteServiceException>(
                testCode: async () => await addFavoriteTask());

        actualException.InnerException.Should().BeOfType<FailedFavoriteServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertFavoriteAsync(It.IsAny<Favorite>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
