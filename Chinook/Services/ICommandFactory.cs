using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Contracts.Albums;
using Chinook.Models;

namespace Chinook.Services
{
    /// <summary>
    /// Interface is a factory that deals with execution details. 
    /// </summary>
    public interface ICommandFactory
    {

        /// <summary>
        /// With the given command, is it possible to use this factory?
        /// </summary>
        /// <param name="provided"></param>
        /// <returns></returns>
        Boolean createable(AlbumPost provided);

        /// <summary>
        /// Create a command to handle some details. 
        /// </summary>
        /// <param name="provided"></param>
        /// <returns></returns>
        ICommand create();
    }
}
