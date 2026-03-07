using Mulkchi.Api.Models.Foundations.Favorites;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Favorite> InsertFavoriteAsync(Favorite favorite);
    IQueryable<Favorite> SelectAllFavorites();
    ValueTask<Favorite> SelectFavoriteByIdAsync(Guid favoriteId);
    ValueTask<Favorite> UpdateFavoriteAsync(Favorite favorite);
    ValueTask<Favorite> DeleteFavoriteByIdAsync(Guid favoriteId);
}
