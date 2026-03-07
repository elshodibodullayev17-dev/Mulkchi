using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class AnnouncementServiceException : Xeptions.Xeption
{
    public AnnouncementServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
