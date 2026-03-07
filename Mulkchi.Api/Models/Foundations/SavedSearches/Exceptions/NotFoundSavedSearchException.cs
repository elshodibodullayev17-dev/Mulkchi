using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class NotFoundSavedSearchException : Xeptions.Xeption
{
    public NotFoundSavedSearchException(Guid savedSearchId)
        : base(message: $"Could not find saved search with id: {savedSearchId}")
    { }
}
