using EventManagement.Data.Models;
using EventManagement.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository implementation for Ticket entity operations.
    /// </summary>
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TicketRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(t => t.Event)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.TicketID == id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Ticket>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(t => t.Event)
                .Where(t => t.UserID == userId)
                .OrderByDescending(t => t.BookingDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Ticket>> GetByEventIdAsync(int eventId)
        {
            return await _dbSet
                .Include(t => t.User)
                .Where(t => t.EventID == eventId)
                .OrderByDescending(t => t.BookingDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Ticket>> GetTicketsByUserAsync(int userId)
        {
            return await GetByUserIdAsync(userId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Ticket>> GetTicketsByEventAsync(int eventId)
        {
            return await GetByEventIdAsync(eventId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(TicketStatus status)
        {
            return await _dbSet
                .Include(t => t.Event)
                .Include(t => t.User)
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.BookingDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateTicketStatusAsync(int ticketId, TicketStatus status)
        {
            var ticket = await _dbSet.FindAsync(ticketId);
            
            if (ticket == null)
            {
                return false;
            }

            ticket.Status = status;
            _context.Entry(ticket).State = EntityState.Modified;
            
            return await SaveChangesAsync();
        }
    }
} 