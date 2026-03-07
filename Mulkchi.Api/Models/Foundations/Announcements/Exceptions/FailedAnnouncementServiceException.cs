using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class FailedAnnouncementServiceException : Xeptions.Xeption
{
    public FailedAnnouncementServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
