using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class FavoriteServiceException : Xeptions.Xeption
{
    public FavoriteServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
