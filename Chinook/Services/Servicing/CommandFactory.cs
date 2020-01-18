using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Contracts.Albums;
using Chinook.Models;

namespace Chinook.Services.Servicing
{
    public class CommandFactory : ICommandFactory
    {
        private readonly List<ICommandFactory> _factories =
            new List<ICommandFactory>(new ICommandFactory[] {new CommandFactoryName()});

        private AlbumPost caught;
        
        /// <summary>
        /// Check if what we have is createable or not. 
        /// </summary>
        /// <param name="provided"></param>
        /// <returns></returns>
        public bool createable(AlbumPost provided)
        {
            caught = provided;
            var res = _factories.FirstOrDefault(x => x.createable(provided));
            return res != null;
        }

        /// <summary>
        /// Get what we have, so long as the fields are fine. 
        /// </summary>
        /// <returns></returns>
        public ICommand create()
        {
            var ret = _factories.FirstOrDefault(x => x.createable(this.caught));
            return ret?.create();
        }
    }
}
