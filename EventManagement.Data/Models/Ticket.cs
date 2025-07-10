using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventManagement.Data.Enums;

namespace EventManagement.Data.Models
{
    /// <summary>
    /// Represents a ticket in the system.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ticket.
        /// </summary>
        [Key]
        public int TicketID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the event this ticket is for.
        /// </summary>
        [Required]
        public int EventID { get; set; }

        /// <summary>
        /// Gets or sets the Event entity this ticket is associated with.
        /// </summary>
        [ForeignKey("EventID")]
        public Event Event { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who purchased this ticket.
        /// </summary>
        [Required]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the type of ticket (e.g., VIP, Standard).
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// Gets or sets the price of the ticket.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was purchased.
        /// </summary>
        [Required]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was booked.
        /// </summary>
        [Required]
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the status of the ticket.
        /// </summary>
        [Required]
        public TicketStatus Status { get; set; } = TicketStatus.Reserved;

        /// <summary>
        /// Gets or sets any special notes or requirements for the ticket.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the user who booked this ticket.
        /// </summary>
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
} 