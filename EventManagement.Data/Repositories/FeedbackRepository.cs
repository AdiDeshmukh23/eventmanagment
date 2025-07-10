using EventManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Implementation of the IFeedbackRepository interface for feedback data operations.
    /// </summary>
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public FeedbackRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets all feedback for a specific event.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns>A collection of feedback for the event.</returns>
        public async Task<IEnumerable<Feedback>> GetByEventIdAsync(int eventId)
        {
            return await _context.Set<Feedback>()
                .Where(f => f.EventID == eventId)
                .Include(f => f.User)
                .OrderByDescending(f => f.SubmittedTimestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Gets all feedback submitted by a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>A collection of feedback submitted by the user.</returns>
        public async Task<IEnumerable<Feedback>> GetByUserIdAsync(int userId)
        {
            return await _context.Set<Feedback>()
                .Where(f => f.UserID == userId)
                .Include(f => f.Event)
                .OrderByDescending(f => f.SubmittedTimestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Gets feedback for a specific event submitted by a specific user.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>The feedback if found, null otherwise.</returns>
        public async Task<Feedback> GetByEventAndUserIdAsync(int eventId, int userId)
        {
            return await _context.Set<Feedback>()
                .Where(f => f.EventID == eventId && f.UserID == userId)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the average rating for a specific event.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns>The average rating or null if no ratings exist.</returns>
        public async Task<double?> GetAverageRatingForEventAsync(int eventId)
        {
            var ratings = await _context.Set<Feedback>()
                .Where(f => f.EventID == eventId)
                .Select(f => f.Rating)
                .ToListAsync();

            if (!ratings.Any())
            {
                return null;
            }

            return ratings.Average();
        }
    }
} 