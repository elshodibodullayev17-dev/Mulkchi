using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

public class FailedNotificationServiceException : Xeptions.Xeption
{
    public FailedNotificationServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
