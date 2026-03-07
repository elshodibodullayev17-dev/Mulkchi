using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class NullSavedSearchException : Xeptions.Xeption
{
    public NullSavedSearchException(string message)
        : base(message)
    { }
}
