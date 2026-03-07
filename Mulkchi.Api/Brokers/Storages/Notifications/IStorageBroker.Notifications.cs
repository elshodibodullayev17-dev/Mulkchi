using Mulkchi.Api.Models.Foundations.Notifications;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Notification> InsertNotificationAsync(Notification notification);
    IQueryable<Notification> SelectAllNotifications();
    ValueTask<Notification> SelectNotificationByIdAsync(Guid notificationId);
    ValueTask<Notification> UpdateNotificationAsync(Notification notification);
    ValueTask<Notification> DeleteNotificationByIdAsync(Guid notificationId);
}
