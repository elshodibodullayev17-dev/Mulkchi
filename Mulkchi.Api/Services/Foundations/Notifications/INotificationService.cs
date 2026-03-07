using Mulkchi.Api.Models.Foundations.Notifications;

namespace Mulkchi.Api.Services.Foundations.Notifications;

public interface INotificationService
{
    ValueTask<Notification> AddNotificationAsync(Notification notification);
    IQueryable<Notification> RetrieveAllNotifications();
    ValueTask<Notification> RetrieveNotificationByIdAsync(Guid notificationId);
    ValueTask<Notification> ModifyNotificationAsync(Notification notification);
    ValueTask<Notification> RemoveNotificationByIdAsync(Guid notificationId);
}
