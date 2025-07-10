using System.Linq.Expressions;

namespace EventManagement.Data.Repositories
{
    /// <summary>
    /// Generic repository interface for data access operations.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A collection of all entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets all entities that satisfy the specified condition.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>A collection of filtered entities.</returns>
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Gets entities with optional filtering, ordering, and includes for navigation properties.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The ordering function.</param>
        /// <param name="includeProperties">Navigation properties to include.</param>
        /// <returns>A collection of filtered, ordered entities with included navigation properties.</returns>
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = "");

        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>The entity if found, null otherwise.</returns>
        Task<T> GetByIdAsync(object id);

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        T Update(T entity);

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        Task DeleteAsync(object id);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Checks if any entity satisfies the specified condition.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if any entity satisfies the condition, false otherwise.</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        /// <returns>True if changes were saved successfully, false otherwise.</returns>
        Task<bool> SaveChangesAsync();
    }
} 