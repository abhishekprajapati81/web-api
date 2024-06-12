using Microsoft.EntityFrameworkCore;

namespace ABC._11june_Abhishek.DB.Data
{
    /// <summary>
    /// SongManagementContext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class SongManagementContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SongManagementContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SongManagementContext(DbContextOptions<SongManagementContext>options) : base(options) { }

        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        /// <value>
        /// The songs.
        /// </value>
        public DbSet<ABC._11june_Abhishek.DB.Entity.Songs> Songs { get; set; }
        /// <summary>
        /// Gets or sets the singer.
        /// </summary>
        /// <value>
        /// The singer.
        /// </value>
        public DbSet<ABC._11june_Abhishek.DB.Entity.Singer> Singer { get; set; }
        /// <summary>
        /// Gets or sets the sung by.
        /// </summary>
        /// <value>
        /// The sung by.
        /// </value>
        public DbSet<ABC._11june_Abhishek.DB.Entity.SungBy> SungBy { get; set; }

    }
}
