using firstgame.Entities.LevelCreation;
using firstgame.Entities.World.MapCreation.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.MapCreation
{
    internal class MapCreator
    {
        Map map = new Map(new List<Level>()
            {
               new StartingLevel1().CreateLevel(),
               new Level2().CreateLevel(),
            });

        public Map GetMap() { 
            return map; 
        }
    }
}
