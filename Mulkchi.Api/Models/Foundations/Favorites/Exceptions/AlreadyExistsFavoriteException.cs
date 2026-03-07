using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class AlreadyExistsFavoriteException : Xeptions.Xeption
{
    public AlreadyExistsFavoriteException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
