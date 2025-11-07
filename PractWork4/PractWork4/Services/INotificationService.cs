using PractWork4.Models;

namespace PractWork4.Services
{
    public interface INotificationService
    {
        IEnumerable<Notification> FilterAndSort(
        IEnumerable<Notification> notifications,
        NotificationFilterOptions options);
    }
}
