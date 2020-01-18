using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Contracts.Albums
{
    /// <summary>
    /// Posting a particular album for usage. 
    /// </summary>
    public class AlbumPost
    {
        /// <summary>
        /// For showing what the page size should be in reality. 
        /// </summary>
        public int pageSize { get; set; }
        public string sortBy { get; set; }
    }
}
