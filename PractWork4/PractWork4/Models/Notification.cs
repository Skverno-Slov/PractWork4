namespace PractWork4.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Priority { get; set; }
        public bool IsRead { get; set; }
    }
}
