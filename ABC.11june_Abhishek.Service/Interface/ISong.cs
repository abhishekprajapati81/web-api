using ABC._11june_Abhishek.DB.DTO;

namespace ABC._11june_Abhishek.Service.Interface
{
    /// <summary>
    /// ISong
    /// </summary>
    public interface ISong
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<SongListDTO> GetAll();

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>
        /// Inserts the specified song upsert dto.
        /// </summary>
        /// <param name="songUpsertDTO">The song upsert dto.</param>
        //void Insert(SongUpsertDTO songUpsertDTO);
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<SongListDTO> GetById(int id);
    }
}
