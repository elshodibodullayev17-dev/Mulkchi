using Mulkchi.Api.Models.Foundations.Announcements;

namespace Mulkchi.Api.Services.Foundations.Announcements;

public interface IAnnouncementService
{
    ValueTask<Announcement> AddAnnouncementAsync(Announcement announcement);
    IQueryable<Announcement> RetrieveAllAnnouncements();
    ValueTask<Announcement> RetrieveAnnouncementByIdAsync(Guid announcementId);
    ValueTask<Announcement> ModifyAnnouncementAsync(Announcement announcement);
    ValueTask<Announcement> RemoveAnnouncementByIdAsync(Guid announcementId);
}
