using Mulkchi.Api.Models.Foundations.Announcements;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Announcement> InsertAnnouncementAsync(Announcement announcement);
    IQueryable<Announcement> SelectAllAnnouncements();
    ValueTask<Announcement> SelectAnnouncementByIdAsync(Guid announcementId);
    ValueTask<Announcement> UpdateAnnouncementAsync(Announcement announcement);
    ValueTask<Announcement> DeleteAnnouncementByIdAsync(Guid announcementId);
}
