using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC._11june_Abhishek.DB.Entity
{
    /// <summary>
    /// SungBy
    /// </summary>
    public class SungBy
    {
        /// <summary>
        /// Gets or sets the sung by identifier.
        /// </summary>
        /// <value>
        /// The sung by identifier.
        /// </value>
        [Key]
        public int SungById { get; set; }

        /// <summary>
        /// Gets or sets the singer identifier.
        /// </summary>
        /// <value>
        /// The singer identifier.
        /// </value>
        public int SingerId { get; set; }

        /// <summary>
        /// Gets or sets the song identifier.
        /// </summary>
        /// <value>
        /// The song identifier.
        /// </value>
        public int SongId { get; set; }

        /// <summary>
        /// Gets or sets the singer.
        /// </summary>
        /// <value>
        /// The singer.
        /// </value>
        [ForeignKey("SingerId")]
        public virtual Singer Singer { get; set; }

        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        /// <value>
        /// The songs.
        /// </value>
        [ForeignKey("SongId")]
        public virtual Songs Songs { get; set; }
    }
}
