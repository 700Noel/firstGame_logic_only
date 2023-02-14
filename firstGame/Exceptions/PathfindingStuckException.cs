using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Exceptions
{
    internal class PathfindingStuckException : Exception
    {
        public PathfindingStuckException() :base("Pathfinding loop stuck") 
        {
        
        }
    }
}
