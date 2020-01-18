using Chinook.Contracts.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Models;
using Microsoft.AspNetCore.Http;

namespace Chinook.Services.Servicing
{
    public class CommandFactoryName : ICommandFactory
    {
        public ICommand create()
        {
            return new CommandName();
        }

        public bool createable(AlbumPost provided)
        {
            return provided.sortBy.Equals("name");
        }
    }
}
