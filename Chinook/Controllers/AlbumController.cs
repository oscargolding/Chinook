using Chinook.Contracts.Albums;
using Chinook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.Controllers
{
    /// <summary>
    /// Very high level controller for the given application. 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _context;

        public AlbumController(IAlbumService context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the albums, and make sure that all possible items are being returned. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumView>>> GetAlbums()
        {
            var ret = await _context.ReturnAlbums();
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(ret);
            }
        }

        /// <summary>
        /// Get the page size, but do it in a default fashion based on name.
        /// Simplify the controller so that only core information is retained. 
        /// </summary>
        /// <param name="provided"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<AlbumView>>> PostAlbums(AlbumPost provided)
        {
            var ret = await _context.SortedAlbums(provided);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(ret);
            }
        }

        /// <summary>
        /// Sorting based on a route, perform the sort with an ascending name. 
        /// </summary>
        /// <param name="provided"></param>
        /// <returns></returns>
        [Route("sort/asc/name")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<AlbumView>>> PostSortingAlbs(AlbumPost provided)
        {
            var ret = await _context.SortName(provided.pageSize);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(ret);
            }
        }

        /// <summary>
        /// Doing a sort on the name, but now want the result in more of a descending order. 
        /// </summary>
        /// <param name="provided"></param>
        /// <returns></returns>
        [Route("sort/desc/name")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<AlbumView>>> PostSortingDescAlbs(AlbumPost provided)
        {
            var ret = await _context.SortNameDesc(provided.pageSize);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(ret);
            }
        }
    }
}