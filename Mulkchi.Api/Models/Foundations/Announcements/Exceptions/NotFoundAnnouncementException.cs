using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Announcements.Exceptions;

public class NotFoundAnnouncementException : Xeptions.Xeption
{
    public NotFoundAnnouncementException(Guid announcementId)
        : base(message: $"Could not find announcement with id: {announcementId}")
    { }
}
