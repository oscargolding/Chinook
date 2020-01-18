using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Contracts.Albums;
using Chinook.Models;
using Chinook.Services.Servicing.MicroService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services.Servicing
{
    public class CommandName : Exception, ICommand
    {
        /// <summary>
        /// Do a simple sort by the name parameter (in an ascending fashion).  
        /// </summary>
        /// <param name="chin"></param>
        /// <param name="prov"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AlbumView>> execute(ChinookContext chin, AlbumPost prov)
        {
            var got = await MoldData.Query(chin);
            return got.ToList().OrderBy(x => x.name);
        }
    }
}
