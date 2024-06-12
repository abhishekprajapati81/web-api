using System.Linq.Expressions;

namespace ABC._11june_Abhishek.Repository.Interface
{
    /// <summary>
    /// ISongRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISongRepository<T> where T : class 
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void save();
        /// <summary>
        /// Gets the specified includes.
        /// </summary>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes);

    }
}
