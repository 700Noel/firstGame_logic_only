using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.MapCreation.Levels
{
    internal abstract class LevelCore
    {
        public abstract Level CreateLevel(int borderThickness);

    }
}
