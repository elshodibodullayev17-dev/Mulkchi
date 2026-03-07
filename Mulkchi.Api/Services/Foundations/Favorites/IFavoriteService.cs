using Mulkchi.Api.Models.Foundations.Favorites;

namespace Mulkchi.Api.Services.Foundations.Favorites;

public interface IFavoriteService
{
    ValueTask<Favorite> AddFavoriteAsync(Favorite favorite);
    IQueryable<Favorite> RetrieveAllFavorites();
    ValueTask<Favorite> RetrieveFavoriteByIdAsync(Guid favoriteId);
    ValueTask<Favorite> ModifyFavoriteAsync(Favorite favorite);
    ValueTask<Favorite> RemoveFavoriteByIdAsync(Guid favoriteId);
}
