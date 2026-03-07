using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

public class NotificationServiceException : Xeptions.Xeption
{
    public NotificationServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
