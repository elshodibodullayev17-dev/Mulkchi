using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Favorites.Exceptions;

public class NullFavoriteException : Xeptions.Xeption
{
    public NullFavoriteException(string message)
        : base(message)
    { }
}
