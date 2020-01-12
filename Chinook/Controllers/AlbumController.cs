using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Contracts.Albums;
using Chinook.Models;
using Chinook.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ISupervisor _context;

        public AlbumController(ISupervisor context)
        {
            _context = context;
        }

        // GET: api/Album
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
    }
}