using ABC._11june_Abhishek.DB.Data;
using ABC._11june_Abhishek.DB.DTO;
using ABC._11june_Abhishek.DB.Entity;
using ABC._11june_Abhishek.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABC._11june_Abhishek.Controllers
{
    /// <summary>
    /// SongController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly SongManagementContext _context;
        /// <summary>
        /// The isong
        /// </summary>
        private readonly ISong _Isong;

        /// <summary>
        /// Initializes a new instance of the <see cref="SongController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="Isong">The isong.</param>
        public SongController(SongManagementContext context, ISong Isong)
        {
            _context = context;
            _Isong = Isong;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> index()
        {
            try
            {
                var song = _Isong.GetAll();
                return Ok(song);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Creates the specified song upsert dto.
        /// </summary>
        /// <param name="songUpsertDTO">The song upsert dto.</param>
        /// <returns></returns>
        [HttpPost("Insert")]
        public async Task<IActionResult> Create([FromForm] SongUpsertDTO songUpsertDTO)
        {
            if (ModelState.IsValid)
            {
                Songs song = new Songs()
                {
                    ReleaseDate = songUpsertDTO.ReleaseDate,
                    Song = songUpsertDTO.Song,
                };
                _context.Add(song);
                _context.SaveChanges();

                if (songUpsertDTO.SelectedSong.Count > 0)
                {
                    foreach (var songs in songUpsertDTO.SelectedSong)
                    {
                        _context.SungBy.Add(new SungBy()
                        {
                            SongId = song.SongId,
                            SingerId = songs

                        });
                        await _context.SaveChangesAsync();
                    }
                    return Ok();
                }
            }
            return BadRequest();
        }


        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="songUpsertDTO">The song upsert dto.</param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] SongUpsertDTO songUpsertDTO)
        {
            var song = await _context.Songs.Where(x => x.SongId == id).FirstOrDefaultAsync();
            if (song == null)
            {
                return BadRequest("Data not Found");
            }
            if (songUpsertDTO != null)
            {
                song.Song = songUpsertDTO.Song;
                song.ReleaseDate = songUpsertDTO.ReleaseDate;
            };
            if (songUpsertDTO.SelectedSong != null)
            {
                var existingData = _context.SungBy.Where(x => x.SongId == id).ToList();
                if (existingData != null)
                {
                    _context.RemoveRange(existingData);
                    _context.SaveChanges();
                }
                if (songUpsertDTO.SelectedSong.Count > 0)
                {
                    foreach (var songs in songUpsertDTO.SelectedSong)
                    {
                        _context.SungBy.Add(new SungBy()
                        {
                            SingerId = songs,
                            SongId = id
                        });
                    }
                }
            }
            _context.Songs.Update(song);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _Isong.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var songData = await _context.Songs.Include("SungBy").FirstOrDefaultAsync(x => x.SongId == id);
            if (songData == null)
            {
                return BadRequest("Data Not Found");
            }
            var getByIdData = new SongListDTO()
            {
                Id = songData.SongId,
                Song = songData.Song,
                ReleaseDate = songData.ReleaseDate,
                SingerCount = songData.SungBy.Count,
                SelectedSong = songData.SungBy.Select(song => song.SongId).ToList()
            };
            return Ok(getByIdData);
        }
    }
}






///////    public async Task<IActionResult> index(string? searchTerm, int pageNumber = 1, int pageSize = 9)
//{
//    var query = _context.Songs.AsQueryable();
//    if (!string.IsNullOrEmpty(searchTerm))
//    {
//        query = query.Where(song => song.Song != null && song.Song.Contains(searchTerm));
//    }
//    var total = await query.CountAsync();
//    int totalPage = (int)Math.Ceiling(total / (double)pageSize);
//    var songList = await query
//        .Skip((pageNumber -1) * pageSize)
//        .Take(pageSize)
//        .Select(x => new SongListDTO
//    {
//        Id = x.SongId,
//        ReleaseDate = x.ReleaseDate,
//        Song = x.Song,
//        SingerCount = x.SungBy.Count    
//    }).ToListAsync();


//    var result = new
//    {
//        Total = total,
//        TotalPage = totalPage,
//        CurrentPage = pageNumber,
//        PageSize = pageSize,
//        Song = songList
//    };
//    return Ok(result);
//}