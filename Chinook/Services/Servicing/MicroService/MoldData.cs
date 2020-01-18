using Chinook.Contracts.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services.Servicing.MicroService
{
    public class MoldData
    {
        public static async Task<IEnumerable<AlbumView>> Query (ChinookContext context)
        {
            return await context.Album.Include(s => s.Track)
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
                }).ToListAsync();
        }
    }
}
