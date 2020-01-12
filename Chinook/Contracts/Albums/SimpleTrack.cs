using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Contracts.Albums
{
    /// <summary>
    /// Similarly, have a contract between the service and the controller. 
    /// </summary>
    public class SimpleTrack
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
