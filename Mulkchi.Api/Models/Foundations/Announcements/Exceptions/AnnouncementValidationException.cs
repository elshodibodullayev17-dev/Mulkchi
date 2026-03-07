using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class AnnouncementValidationException : Xeptions.Xeption
{
    public AnnouncementValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
