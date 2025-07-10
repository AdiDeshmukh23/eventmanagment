using EventManagement.Data.Models;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository interface for notification data operations.
    /// </summary>
    public interface INotificationRepository
    {
        /// <summary>
        /// Gets a notification by its ID.
        /// </summary>
        /// <param name="id">The notification ID.</param>
        /// <returns>The notification if found, null otherwise.</returns>
        Task<Notification> GetByIdAsync(int id);

        /// <summary>
        /// Gets all notifications for a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="includeRead">Whether to include read notifications.</param>
        /// <returns>A collection of notifications for the user.</returns>
        Task<IEnumerable<Notification>> GetByUserIdAsync(int userId, bool includeRead = true);

        /// <summary>
        /// Gets all notifications related to a specific event.
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns>A collection of notifications related to the event.</returns>
        Task<IEnumerable<Notification>> GetByEventIdAsync(int eventId);

        /// <summary>
        /// Adds a new notification.
        /// </summary>
        /// <param name="notification">The notification to add.</param>
        /// <returns>The added notification.</returns>
        Task<Notification> AddAsync(Notification notification);

        /// <summary>
        /// Updates an existing notification.
        /// </summary>
        /// <param name="notification">The notification to update.</param>
        /// <returns>The updated notification.</returns>
        Notification Update(Notification notification);

        /// <summary>
        /// Marks a notification as read.
        /// </summary>
        /// <param name="id">The notification ID.</param>
        /// <returns>The updated notification if found, null otherwise.</returns>
        Task<Notification> MarkAsReadAsync(int id);

        /// <summary>
        /// Marks all notifications for a user as read.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>The number of notifications updated.</returns>
        Task<int> MarkAllAsReadAsync(int userId);

        /// <summary>
        /// Deletes a notification.
        /// </summary>
        /// <param name="id">The notification ID.</param>
        /// <returns>True if successful, false otherwise.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        /// <returns>True if successful, false otherwise.</returns>
        Task<bool> SaveChangesAsync();
    }
} 