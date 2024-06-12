using ABC._11june_Abhishek.DB.Data;
using ABC._11june_Abhishek.DB.Entity;
using ABC._11june_Abhishek.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ABC._11june_Abhishek.Repository.Implementation
{
    /// <summary>
    /// SongRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ABC._11june_Abhishek.Repository.Interface.ISongRepository&lt;T&gt;" />
    /// <seealso cref="ABC._11june_Abhishek.Repository.Interface.ISongRepository&lt;T&gt;" />
    public class SongRepository<T> : ISongRepository<T> where T : class
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly SongManagementContext _context;
        /// <summary>
        /// The database set
        /// </summary>
        private DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SongRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SongRepository(SongManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">Data Not Found</exception>
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                throw new Exception("Data Not Found");
            }
            _context.Remove(entity);
        }

        /// <summary>
        /// Gets the specified includes.
        /// </summary>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            return query;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _dbSet.Include(song => (song as Songs).SungBy).ToList(); 
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        void ISongRepository<T>.save()
        {
            _context.SaveChanges();
        }
    }
}
