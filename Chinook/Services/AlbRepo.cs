using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Contracts.Albums;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    /// <summary>
    /// Implementation of physical class for doing queries.
    /// Program to an interface and not an implementation. 
    /// </summary>
    public class AlbRepo : ISupervisor
    {
        private readonly ChinookContext _context;

        public AlbRepo(ChinookContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Implementation, retrieving the required object for usage.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumView>> ReturnAlbums()
        {
            // A different approach that uses group join (good for when EF Core doesn't automatically do the connection
            // for you). 

            //var found = await _context.Album.GroupJoin(_context.Track,
            //    track => track.AlbumId,
            //    album => album.AlbumId,
            //    (alb, trackGroup) => new
            //    {
            //        id = alb.AlbumId,
            //        name = alb.Title,
            //        tracks = trackGroup.OrderBy(t => t.TrackId)
            //    }).OrderBy(b => b.id).ToListAsync();

            // Or we use an include to get a more nice result (considering the relations are already defined using ef core)

            return await _context.Album.Include(s => s.Track)
                .OrderBy(s => s.AlbumId)
                .Select(s => new AlbumView()
                {
                    id = s.AlbumId,
                    name = s.Title,
                    tracks = s.Track
                        .OrderBy(sa => sa.TrackId)
                        .Select(t => new SimpleTrack()
                        {
                            id = t.TrackId,
                            Name = t.Name
                        }).ToList()
                })
                .ToListAsync();
            //return found;
        }
    }
}
