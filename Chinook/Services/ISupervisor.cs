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
    public interface ISupervisor
    {
        Task<IEnumerable<AlbumView>> ReturnAlbums();
    }
}
