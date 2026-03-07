using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class FailedFavoriteStorageException : Xeptions.Xeption
{
    public FailedFavoriteStorageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
