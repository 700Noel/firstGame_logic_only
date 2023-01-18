using firstgame.Entities.Characters;
using firstgame.Entities.LevelCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.MapCreation.Levels
{
    internal class StartingLevel1
    {
        Fill fill = new Fill();
        Entrance entrance= new Entrance();
        public Level CreateLevel() { 
            
            Level level = fill.CreateBorderLevel(1);
            //entrance.CreateEntrance(Enums.Direction.Down, level);
            entrance.CreateEntrance(Enums.Direction.Right, level);
            //entrance.CreateEntrance(Enums.Direction.Left, level);
            //entrance.CreateEntrance(Enums.Direction.Up, level);
            return level;
        }
    }
}
