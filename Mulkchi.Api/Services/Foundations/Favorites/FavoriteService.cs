using Mulkchi.Api.Models.Foundations.Favorites;
using Mulkchi.Api.Models.Foundations.Favorites.Exceptions;
using Mulkchi.Api.Brokers.Storages;

namespace Mulkchi.Api.Services.Foundations.Favorites;

public partial class FavoriteService : IFavoriteService
{
    private readonly IStorageBroker storageBroker;

    public FavoriteService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public ValueTask<Favorite> AddFavoriteAsync(Favorite favorite) =>
        TryCatch(async () =>
        {
            ValidateFavoriteOnAdd(favorite);
            return await this.storageBroker.InsertFavoriteAsync(favorite);
        });

    public IQueryable<Favorite> RetrieveAllFavorites() =>
        TryCatch(() => this.storageBroker.SelectAllFavorites());

    public ValueTask<Favorite> RetrieveFavoriteByIdAsync(Guid favoriteId) =>
        TryCatch(async () =>
        {
            ValidateFavoriteId(favoriteId);
            Favorite maybeFavorite = await this.storageBroker.SelectFavoriteByIdAsync(favoriteId);

            if (maybeFavorite is null)
                throw new NotFoundFavoriteException(favoriteId);

            return maybeFavorite;
        });

    public ValueTask<Favorite> ModifyFavoriteAsync(Favorite favorite) =>
        TryCatch(async () =>
        {
            ValidateFavoriteOnModify(favorite);
            return await this.storageBroker.UpdateFavoriteAsync(favorite);
        });

    public ValueTask<Favorite> RemoveFavoriteByIdAsync(Guid favoriteId) =>
        TryCatch(async () =>
        {
            ValidateFavoriteId(favoriteId);
            return await this.storageBroker.DeleteFavoriteByIdAsync(favoriteId);
        });
}
