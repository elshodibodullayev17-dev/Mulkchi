using Xeptions;

namespace Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

public class SavedSearchValidationException : Xeptions.Xeption
{
    public SavedSearchValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
