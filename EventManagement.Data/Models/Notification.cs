using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Data.Models
{
    /// <summary>
    /// Represents a notification in the system.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Gets or sets the unique identifier for the notification.
        /// </summary>
        [Key]
        public int NotificationID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who will receive this notification.
        /// </summary>
        [Required]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the User entity this notification is associated with.
        /// </summary>
        [ForeignKey("UserID")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the type of notification.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the title of the notification.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the notification.
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the ID of the event related to this notification, if any.
        /// </summary>
        public int? EventID { get; set; }

        /// <summary>
        /// Gets or sets the Event entity this notification is related to, if any.
        /// </summary>
        [ForeignKey("EventID")]
        public Event Event { get; set; }

        /// <summary>
        /// Gets or sets the date and time when this notification was created.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when this notification was sent.
        /// </summary>
        [Required]
        public DateTime SentTimestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets a value indicating whether this notification has been read.
        /// </summary>
        [Required]
        public bool IsRead { get; set; }

        /// <summary>
        /// Gets or sets the date and time when this notification was read.
        /// </summary>
        public DateTime? ReadAt { get; set; }
    }
} 