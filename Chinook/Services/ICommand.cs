using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Contracts.Albums;
using Chinook.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Services
{
    public interface ICommand
    {
        /// <summary>
        /// Get the album views for proper usage. 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AlbumView>> execute(ChinookContext chin, AlbumPost prov);
    }
}
