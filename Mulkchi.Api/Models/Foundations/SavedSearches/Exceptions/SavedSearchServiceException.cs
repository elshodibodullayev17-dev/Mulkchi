using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class SavedSearchServiceException : Xeptions.Xeption
{
    public SavedSearchServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
