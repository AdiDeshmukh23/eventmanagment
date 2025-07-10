using EventManagement.Data.Models;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository interface for feedback data operations.
    /// </summary>
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        /// <summary>
        /// Gets all feedback for a specific event.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns>A collection of feedback for the event.</returns>
        Task<IEnumerable<Feedback>> GetByEventIdAsync(int eventId);

        /// <summary>
        /// Gets all feedback submitted by a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>A collection of feedback submitted by the user.</returns>
        Task<IEnumerable<Feedback>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Gets feedback for a specific event submitted by a specific user.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>The feedback if found, null otherwise.</returns>
        Task<Feedback> GetByEventAndUserIdAsync(int eventId, int userId);

        /// <summary>
        /// Gets the average rating for a specific event.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns>The average rating or null if no ratings exist.</returns>
        Task<double?> GetAverageRatingForEventAsync(int eventId);
    }
} 