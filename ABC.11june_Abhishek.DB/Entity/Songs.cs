using System.ComponentModel.DataAnnotations;

namespace ABC._11june_Abhishek.DB.Entity
{
    /// <summary>
    /// Songs
    /// </summary>
    public class Songs
    {
        /// <summary>
        /// Gets or sets the song identifier.
        /// </summary>
        /// <value>
        /// The song identifier.
        /// </value>
        [Key]
        public int SongId { get; set; }

        /// <summary>
        /// Gets or sets the song.
        /// </summary>
        /// <value>
        /// The song.
        /// </value>
        [Required]
        public string Song { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        public DateTime ReleaseDate  { get; set; }

        /// <summary>
        /// Gets or sets the sung by.
        /// </summary>
        /// <value>
        /// The sung by.
        /// </value>
        public virtual ICollection<SungBy> SungBy { get; set; }

    }
}
