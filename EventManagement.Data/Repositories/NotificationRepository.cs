using EventManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository implementation for Notification entity operations.
    /// </summary>
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<Notification> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(n => n.User)
                .Include(n => n.Event)
                .FirstOrDefaultAsync(n => n.NotificationID == id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Notification>> GetByUserIdAsync(int userId, bool includeRead = true)
        {
            var query = _dbSet
                .Include(n => n.Event)
                .Where(n => n.UserID == userId);

            if (!includeRead)
            {
                query = query.Where(n => !n.IsRead);
            }

            return await query
                .OrderByDescending(n => n.SentTimestamp)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Notification>> GetByEventIdAsync(int eventId)
        {
            return await _dbSet
                .Include(n => n.User)
                .Where(n => n.EventID == eventId)
                .OrderByDescending(n => n.SentTimestamp)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Notification> MarkAsReadAsync(int id)
        {
            var notification = await _dbSet.FindAsync(id);
            if (notification == null)
            {
                return null;
            }

            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
            _context.Entry(notification).State = EntityState.Modified;
            
            return notification;
        }

        /// <inheritdoc/>
        public async Task<int> MarkAllAsReadAsync(int userId)
        {
            var unreadNotifications = await _dbSet
                .Where(n => n.UserID == userId && !n.IsRead)
                .ToListAsync();

            if (!unreadNotifications.Any())
            {
                return 0;
            }

            var now = DateTime.UtcNow;
            foreach (var notification in unreadNotifications)
            {
                notification.IsRead = true;
                notification.ReadAt = now;
                _context.Entry(notification).State = EntityState.Modified;
            }

            return unreadNotifications.Count;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int id)
        {
            var notification = await _dbSet.FindAsync(id);
            if (notification == null)
            {
                return false;
            }

            _dbSet.Remove(notification);
            return true;
        }
    }
} 