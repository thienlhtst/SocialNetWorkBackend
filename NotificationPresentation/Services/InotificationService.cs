using NotificationPresentation.Enitites;

namespace NotificationPresentation.Services
{
    public interface INotificationService
    {
        public Task<Notification> CreateNotification(Notification notification);

        public Task UpdateIsRead(string id);
    }
}