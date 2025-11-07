using PractWork4.Models;

namespace PractWork4.Services
{
    public interface IServiceNotification<T>
    {
        IEnumerable<T> FilterAndSort(
        IEnumerable<T> notifications,
        NotificationFilterOptions options);
    }
}
