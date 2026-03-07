using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class FavoriteValidationException : Xeptions.Xeption
{
    public FavoriteValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
