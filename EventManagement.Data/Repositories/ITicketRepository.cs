using EventManagement.Data.Models;
using EventManagement.Data.Enums;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository interface for ticket data operations.
    /// </summary>
    public interface ITicketRepository
    {
        /// <summary>
        /// Gets a ticket by its ID.
        /// </summary>
        /// <param name="id">The ticket ID.</param>
        /// <returns>The ticket if found, null otherwise.</returns>
        Task<Ticket> GetByIdAsync(int id);

        /// <summary>
        /// Gets all tickets for a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>A collection of tickets belonging to the user.</returns>
        Task<IEnumerable<Ticket>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Gets all tickets for a specific event.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns>A collection of tickets for the event.</returns>
        Task<IEnumerable<Ticket>> GetByEventIdAsync(int eventId);

        /// <summary>
        /// Adds a new ticket.
        /// </summary>
        /// <param name="ticket">The ticket to add.</param>
        /// <returns>The added ticket.</returns>
        Task<Ticket> AddAsync(Ticket ticket);

        /// <summary>
        /// Updates an existing ticket.
        /// </summary>
        /// <param name="ticket">The ticket to update.</param>
        /// <returns>The updated ticket.</returns>
        Ticket Update(Ticket ticket);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        /// <returns>True if successful, false otherwise.</returns>
        Task<bool> SaveChangesAsync();
    }
} 