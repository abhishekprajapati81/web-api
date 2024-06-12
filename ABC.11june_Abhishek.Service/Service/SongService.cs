using ABC._11june_Abhishek.DB.DTO;
using ABC._11june_Abhishek.DB.Entity;
using ABC._11june_Abhishek.Repository.Interface;
using ABC._11june_Abhishek.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ABC._11june_Abhishek.Service.Service
{
    /// <summary>
    /// SongService
    /// </summary>
    /// <seealso cref="ABC._11june_Abhishek.Service.Interface.ISong" />
    public class SongService : ISong
    {
        /// <summary>
        /// The song repository
        /// </summary>
        private readonly ISongRepository<Songs> _songRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SongService" /> class.
        /// </summary>
        /// <param name="songRepository">The song repository.</param>
        public SongService(ISongRepository<Songs> songRepository)
        {
            _songRepository = songRepository;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            _songRepository.Delete(id);
            _songRepository.save();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<SongListDTO> GetAll()
        {
            var song = _songRepository.GetAll().Select(x => new SongListDTO
            {
                Id = x.SongId,
                ReleaseDate = x.ReleaseDate,
                Song = x.Song,
                SingerCount = x.SungBy.Count
            }).ToList();
            return song;
        }

        public Task<SongListDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        //public void Insert(SongUpsertDTO songUpsertDTO)
        //{
        //        Songs song = new Songs()
        //        {
        //            ReleaseDate = songUpsertDTO.ReleaseDate,
        //            Song = songUpsertDTO.Song,
        //        };
  
        //        if (songUpsertDTO.SelectedSong.Count > 0)
        //        {
        //            foreach (var songs in songUpsertDTO.SelectedSong)
        //            {
        //            _songRepository.GetAll().(new SungBy()
        //            {
        //                SongId = song.SongId,
        //                SingerId = songs

        //            });
        //            }
        //    _songRepository.Add(song);
        //    _songRepository.save();
        //        }

        //}
    }
    }

