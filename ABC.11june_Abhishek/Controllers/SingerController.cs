using ABC._11june_Abhishek.DB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABC._11june_Abhishek.Controllers
{
    /// <summary>
    /// SingerController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly SongManagementContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingerController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SingerController(SongManagementContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all singer.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSinger")]
        public async Task<IActionResult> GetAllSinger()
        {
            var singer = await _context.Singer.ToListAsync();
            return Ok(singer);
        }
    }
}
