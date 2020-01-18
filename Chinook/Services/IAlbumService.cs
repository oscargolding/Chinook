using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Contracts.Albums;

namespace Chinook.Services
{
    /// <summary>
    /// Simply, have a class that performs supervision on other classes that are present.
    /// </summary>
    public interface IAlbumService
    {
        /// <summary>
        /// Get all the possible albums and do a return on them. 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AlbumView>> ReturnAlbums();

        /// <summary>
        /// Get all the possible albums, but make sure that they are limited in size. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        Task<IEnumerable<AlbumView>> LimitedAlbums(int amount);

        /// <summary>
        /// Sort by the name of the album, specifically a part of the route. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        Task<IEnumerable<AlbumView>> SortName(int amount);

        /// <summary>
        /// Want to sort by the album name in more of a descending fashion. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        Task<IEnumerable<AlbumView>> SortNameDesc(int amount);

        /// <summary>
        /// Get the albums in a sorted order, according to the requirements. 
        /// </summary>
        /// <param name="given"></param>
        /// <returns></returns>
        Task<IEnumerable<AlbumView>> SortedAlbums(AlbumPost given);
    }
}
