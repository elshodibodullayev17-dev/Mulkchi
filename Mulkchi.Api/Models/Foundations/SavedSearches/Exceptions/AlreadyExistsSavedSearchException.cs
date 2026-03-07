using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class AlreadyExistsSavedSearchException : Xeptions.Xeption
{
    public AlreadyExistsSavedSearchException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
