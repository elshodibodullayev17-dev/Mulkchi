using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class InvalidFavoriteException : Xeptions.Xeption
{
    public InvalidFavoriteException(string message)
        : base(message)
    { }

    public InvalidFavoriteException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
