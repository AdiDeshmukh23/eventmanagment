using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Data.Models
{
    /// <summary>
    /// Represents an event in the system.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the unique identifier for the event.
        /// </summary>
        [Key]
        public int EventID { get; set; }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of the event.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the location where the event will be held.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the event.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who organized this event.
        /// </summary>
        [Required]
        public int OrganizerID { get; set; }

        /// <summary>
        /// Gets or sets the user who organized this event.
        /// </summary>
        [ForeignKey("OrganizerID")]
        public User Organizer { get; set; }

        /// <summary>
        /// Gets or sets the collection of tickets associated with this event.
        /// </summary>
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        /// <summary>
        /// Gets or sets the collection of notifications associated with this event.
        /// </summary>
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        /// <summary>
        /// Gets or sets the collection of feedback associated with this event.
        /// </summary>
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
} 