using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Data.Models
{
    /// <summary>
    /// Represents user feedback for an event.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Gets or sets the unique identifier for the feedback.
        /// </summary>
        [Key]
        public int FeedbackID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the event this feedback is for.
        /// </summary>
        [Required]
        public int EventID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who provided this feedback.
        /// </summary>
        [Required]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the rating given by the user (1-5).
        /// </summary>
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the comments provided by the user.
        /// </summary>
        [StringLength(500)]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when this feedback was submitted.
        /// </summary>
        [Required]
        public DateTime SubmittedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the event this feedback is for.
        /// </summary>
        [ForeignKey("EventID")]
        public Event Event { get; set; }

        /// <summary>
        /// Gets or sets the user who provided this feedback.
        /// </summary>
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
} 