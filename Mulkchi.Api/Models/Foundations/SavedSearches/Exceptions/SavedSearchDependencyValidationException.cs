using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class SavedSearchDependencyValidationException : Xeptions.Xeption
{
    public SavedSearchDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
