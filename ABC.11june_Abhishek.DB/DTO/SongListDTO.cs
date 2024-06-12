namespace ABC._11june_Abhishek.DB.DTO
{
    /// <summary>
    /// SongListDTO
    /// </summary>
    public class SongListDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the song.
        /// </summary>
        /// <value>
        /// The song.
        /// </value>
        public string Song { get; set; }
        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the singer count.
        /// </summary>
        /// <value>
        /// The singer count.
        /// </value>
        public int SingerCount  { get; set; }
        /// <summary>
        /// Gets or sets the selected song.
        /// </summary>
        /// <value>
        /// The selected song.
        /// </value>
        public List<int> SelectedSong { get; set; }
    }
}
