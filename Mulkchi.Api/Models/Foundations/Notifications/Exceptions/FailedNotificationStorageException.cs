using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Notifications.Exceptions;

public class FailedNotificationStorageException : Xeptions.Xeption
{
    public FailedNotificationStorageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
