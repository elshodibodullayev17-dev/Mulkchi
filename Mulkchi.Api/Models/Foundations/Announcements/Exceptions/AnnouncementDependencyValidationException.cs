using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class AnnouncementDependencyValidationException : Xeptions.Xeption
{
    public AnnouncementDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
