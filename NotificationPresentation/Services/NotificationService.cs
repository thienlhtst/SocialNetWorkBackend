using NotificationPresentation.Enitites;
using NotificationPresentation.Infrastucture;

namespace NotificationPresentation.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationDbContext _context;

        public NotificationService(NotificationDbContext context)
        {
            _context=context;
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            var result = _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateIsRead(string id)
        {
            var result = _context.Notifications.Find(id);
            result.IsRead = true;
            _context.Notifications.Update(result);
            await _context.SaveChangesAsync();
        }
    }
}