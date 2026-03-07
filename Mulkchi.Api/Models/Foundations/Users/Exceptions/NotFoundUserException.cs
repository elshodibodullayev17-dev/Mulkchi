using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class NotFoundUserException : Xeptions.Xeption
{
    public NotFoundUserException(Guid userId)
        : base(message: $"Could not find user with id: {userId}")
    { }
}
