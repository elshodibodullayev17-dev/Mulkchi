using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class AnnouncementDependencyException : Xeptions.Xeption
{
    public AnnouncementDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
