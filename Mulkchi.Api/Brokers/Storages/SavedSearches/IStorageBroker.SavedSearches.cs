using Mulkchi.Api.Models.Foundations.SavedSearches;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<SavedSearch> InsertSavedSearchAsync(SavedSearch savedSearch);
    IQueryable<SavedSearch> SelectAllSavedSearches();
    ValueTask<SavedSearch> SelectSavedSearchByIdAsync(Guid savedSearchId);
    ValueTask<SavedSearch> UpdateSavedSearchAsync(SavedSearch savedSearch);
    ValueTask<SavedSearch> DeleteSavedSearchByIdAsync(Guid savedSearchId);
}
