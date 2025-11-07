using PractWork4.Models;

namespace PractWork4.Services
{
    public class NotificationService : IServiceNotification
    {
        public IEnumerable<Notification> FilterAndSort(
        IEnumerable<Notification> notifications,
        NotificationFilterOptions options)
        {
            var filtered = ApplyFilters(notifications, options);

            var sorted = ApplySorting(filtered, options);

            return sorted.ToList();
        }

        private IQueryable<Notification> ApplyFilters(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            var query = notifications.AsQueryable();

            if (options.IsRead.HasValue)
                query = query.Where(n => n.IsRead == options.IsRead.Value);

            if (options.Types != null && options.Types.Any())
                query = query.Where(n => options.Types.Contains(n.Type));

            if (!string.IsNullOrEmpty(options.SearchText))
                query = query.Where(n => n.Title.Contains(options.SearchText, StringComparison.OrdinalIgnoreCase) ||
                                         n.Content != null && n.Content.Contains(options.SearchText, StringComparison.OrdinalIgnoreCase));

            if (options.MinPriority.HasValue)
                query = query.Where(n => n.Priority >= options.MinPriority.Value);

            return query;
        }

        private IEnumerable<Notification> ApplySorting(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            IOrderedEnumerable<Notification>? orderedQuery = null;

            switch (options.SortBy)
            {
                case SortNotificationBy.Date:
                    orderedQuery = options.Descending
                        ? notifications.OrderByDescending(n => n.CreatedAt)
                        : notifications.OrderBy(n => n.CreatedAt);
                    break;

                case SortNotificationBy.Priority:
                    orderedQuery = options.Descending
                        ? notifications.OrderByDescending(n => n.Priority)
                        : notifications.OrderBy(n => n.Priority);
                    break;

                case SortNotificationBy.Title:
                    orderedQuery = options.Descending
                        ? notifications.OrderByDescending(n => n.Title)
                        : notifications.OrderBy(n => n.Title);
                    break;
                default:
                    return notifications;
            }

            return orderedQuery;
        }
    }
}
