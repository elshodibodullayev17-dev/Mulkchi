using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class SavedSearchDependencyException : Xeptions.Xeption
{
    public SavedSearchDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
