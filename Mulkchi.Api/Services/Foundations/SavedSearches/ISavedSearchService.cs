using Mulkchi.Api.Models.Foundations.SavedSearches;

namespace Mulkchi.Api.Services.Foundations.SavedSearches;

public interface ISavedSearchService
{
    ValueTask<SavedSearch> AddSavedSearchAsync(SavedSearch savedSearch);
    IQueryable<SavedSearch> RetrieveAllSavedSearches();
    ValueTask<SavedSearch> RetrieveSavedSearchByIdAsync(Guid savedSearchId);
    ValueTask<SavedSearch> ModifySavedSearchAsync(SavedSearch savedSearch);
    ValueTask<SavedSearch> RemoveSavedSearchByIdAsync(Guid savedSearchId);
}
