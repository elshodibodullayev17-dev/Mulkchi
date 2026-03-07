using Mulkchi.Api.Models.Foundations.SavedSearches;
using Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;
using Mulkchi.Api.Brokers.Storages;

namespace Mulkchi.Api.Services.Foundations.SavedSearches;

public partial class SavedSearchService : ISavedSearchService
{
    private readonly IStorageBroker storageBroker;

    public SavedSearchService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public ValueTask<SavedSearch> AddSavedSearchAsync(SavedSearch savedSearch) =>
        TryCatch(async () =>
        {
            ValidateSavedSearchOnAdd(savedSearch);
            return await this.storageBroker.InsertSavedSearchAsync(savedSearch);
        });

    public IQueryable<SavedSearch> RetrieveAllSavedSearches() =>
        TryCatch(() => this.storageBroker.SelectAllSavedSearches());

    public ValueTask<SavedSearch> RetrieveSavedSearchByIdAsync(Guid savedSearchId) =>
        TryCatch(async () =>
        {
            ValidateSavedSearchId(savedSearchId);
            SavedSearch maybeSavedSearch = await this.storageBroker.SelectSavedSearchByIdAsync(savedSearchId);

            if (maybeSavedSearch is null)
                throw new NotFoundSavedSearchException(savedSearchId);

            return maybeSavedSearch;
        });

    public ValueTask<SavedSearch> ModifySavedSearchAsync(SavedSearch savedSearch) =>
        TryCatch(async () =>
        {
            ValidateSavedSearchOnModify(savedSearch);
            return await this.storageBroker.UpdateSavedSearchAsync(savedSearch);
        });

    public ValueTask<SavedSearch> RemoveSavedSearchByIdAsync(Guid savedSearchId) =>
        TryCatch(async () =>
        {
            ValidateSavedSearchId(savedSearchId);
            return await this.storageBroker.DeleteSavedSearchByIdAsync(savedSearchId);
        });
}
