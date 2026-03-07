using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

public class NotificationValidationException : Xeptions.Xeption
{
    public NotificationValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
