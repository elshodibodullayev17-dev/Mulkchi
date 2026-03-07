using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class NullAnnouncementException : Xeptions.Xeption
{
    public NullAnnouncementException(string message)
        : base(message)
    { }
}
