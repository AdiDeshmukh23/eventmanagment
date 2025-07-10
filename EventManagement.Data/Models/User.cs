using System.ComponentModel.DataAnnotations;
using EventManagement.Data.Enums;

namespace EventManagement.Data.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash of the user.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the contact number of the user.
        /// </summary>
        [StringLength(20)]
        public string ContactNumber { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        [Required]
        public UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the collection of events organized by this user.
        /// </summary>
        public virtual ICollection<Event> OrganizedEvents { get; set; } = new List<Event>();

        /// <summary>
        /// Gets or sets the collection of tickets booked by this user.
        /// </summary>
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        /// <summary>
        /// Gets or sets the collection of notifications for this user.
        /// </summary>
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        /// <summary>
        /// Gets or sets the collection of feedback provided by this user.
        /// </summary>
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
} 