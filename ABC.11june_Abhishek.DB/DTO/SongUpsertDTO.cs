namespace ABC._11june_Abhishek.DB.DTO
{
    /// <summary>
    /// SongUpsertDTO
    /// </summary>
    public class SongUpsertDTO
    {
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
        /// Gets or sets the selected song.
        /// </summary>
        /// <value>
        /// The selected song.
        /// </value>
        public List<int> SelectedSong { get; set; }
    }
}
