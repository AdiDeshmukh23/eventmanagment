using EventManagement.Data.Models;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository interface for Event entity operations.
    /// </summary>
    public interface IEventRepository : IGenericRepository<Event>
    {
        /// <summary>
        /// Gets events organized by a specific user.
        /// </summary>
        /// <param name="organizerId">The organizer ID.</param>
        /// <returns>A collection of events organized by the specified user.</returns>
        Task<IEnumerable<Event>> GetEventsByOrganizerAsync(int organizerId);

        /// <summary>
        /// Gets events by category.
        /// </summary>
        /// <param name="category">The event category.</param>
        /// <returns>A collection of events in the specified category.</returns>
        Task<IEnumerable<Event>> GetEventsByCategoryAsync(string category);

        /// <summary>
        /// Gets events scheduled after a specific date.
        /// </summary>
        /// <param name="date">The date to filter events by.</param>
        /// <returns>A collection of events scheduled after the specified date.</returns>
        Task<IEnumerable<Event>> GetUpcomingEventsAsync(DateTime date);

        /// <summary>
        /// Searches for events based on a search term.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <returns>A collection of events matching the search term.</returns>
        Task<IEnumerable<Event>> SearchEventsAsync(string searchTerm);
    }
} 