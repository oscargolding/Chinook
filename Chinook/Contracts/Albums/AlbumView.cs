using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Contracts.Albums
{
    /// <summary>
    /// Simplified overview of an album that's going to be used.
    /// Have a contract between the service and controller. 
    /// </summary>
    public class AlbumView
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<SimpleTrack> tracks { get; set; }
    }
}
