using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class FavoriteDependencyValidationException : Xeptions.Xeption
{
    public FavoriteDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
