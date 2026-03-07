using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

public class NotificationDependencyException : Xeptions.Xeption
{
    public NotificationDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
