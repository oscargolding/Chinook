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
    public class AlbumService : IAlbumService
    {
        private readonly ChinookContext _context;
        private readonly ICommandFactory _commandFact;

        public AlbumService(ChinookContext context, ICommandFactory given)
        {
            _context = context;
            _commandFact = given;
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
        }

        /// <summary>
        /// Simply use a previous service, but have a limit on the amount that's provided. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumView>> LimitedAlbums(int amount)
        {
            if (amount <= 0) return null;
            var found = await ReturnAlbums();
            return found.ToList().Take(amount);
        }

        /// <summary>
        /// For the sorting of specific albums. This is done on a parameter type Album
        /// with the implementation defaulting to the use of a command factory to instantiate
        /// specific objects for usage. The purpose is to simplify the responsibilities of an
        /// individual service that's in operation. 
        /// </summary>
        /// <param name="given"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumView>> SortedAlbums(AlbumPost given)
        {
            if (!_commandFact.createable(given))
                return null;
            var retrieve = _commandFact.create();
            var got = await retrieve.execute(_context, given);
            // NB -> we cannot take a sample until all the filtering and sorting is done on the data. 
            return got.ToList().Take(given.pageSize);
        }

        /// <summary>
        /// Sort by the name of the album, as appropriate. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumView>> SortName(int amount)
        {
            var found = await LimitedAlbums(amount);
            return found.ToList().OrderBy(album => album.name);
        }

        /// <summary>
        /// Now do a sort in the descending order (as opposed to an ascending order sort). 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumView>> SortNameDesc(int amount)
        {
            var found = await LimitedAlbums(amount);
            return found.ToList().OrderByDescending(album => album.name);
        }
    }
}
