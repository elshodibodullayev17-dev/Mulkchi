using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class FavoriteDependencyException : Xeptions.Xeption
{
    public FavoriteDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
