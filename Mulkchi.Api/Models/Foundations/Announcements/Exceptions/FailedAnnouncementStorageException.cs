using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class FailedAnnouncementStorageException : Xeptions.Xeption
{
    public FailedAnnouncementStorageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
