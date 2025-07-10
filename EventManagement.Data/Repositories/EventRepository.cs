using EventManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository implementation for Event entity operations.
    /// </summary>
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Event>> GetEventsByOrganizerAsync(int organizerId)
        {
            return await _dbSet
                .Where(e => e.OrganizerID == organizerId)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Event>> GetEventsByCategoryAsync(string category)
        {
            return await _dbSet
                .Where(e => e.Category.ToLower() == category.ToLower())
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync(DateTime date)
        {
            return await _dbSet
                .Where(e => e.Date > date)
                .OrderBy(e => e.Date)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Event>> SearchEventsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllAsync();
            }

            searchTerm = searchTerm.ToLower();

            return await _dbSet
                .Where(e => e.Name.ToLower().Contains(searchTerm) ||
                            e.Category.ToLower().Contains(searchTerm) ||
                            e.Location.ToLower().Contains(searchTerm))
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }
    }
} 