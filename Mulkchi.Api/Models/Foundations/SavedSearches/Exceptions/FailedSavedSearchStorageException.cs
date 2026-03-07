using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class FailedSavedSearchStorageException : Xeptions.Xeption
{
    public FailedSavedSearchStorageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
