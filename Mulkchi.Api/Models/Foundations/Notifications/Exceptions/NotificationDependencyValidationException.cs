using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

public class NotificationDependencyValidationException : Xeptions.Xeption
{
    public NotificationDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
