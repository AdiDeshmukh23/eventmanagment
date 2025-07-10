using EventManagement.Data.Models;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Repository interface for User entity operations.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <returns>The user if found, null otherwise.</returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Checks if an email is already in use.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <returns>True if the email is already in use, false otherwise.</returns>
        Task<bool> IsEmailInUseAsync(string email);
    }
} 