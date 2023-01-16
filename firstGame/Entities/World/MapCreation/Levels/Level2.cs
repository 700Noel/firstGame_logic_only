using firstgame.Entities.LevelCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.MapCreation.Levels
{
    internal class Level2
    {
        Fill fill = new Fill();
        Entrance entrance = new Entrance();
        public Level CreateLevel()
        {

            Level level = fill.CreateBorderLevel(1);
            entrance.CreateEntrance(Enums.Direction.Left, level);
            entrance.CreateEntrance(Enums.Direction.Right, level);
            level.positions[5, 3].State = PositionState.Obstacle;
            level.positions[5, 4].State = PositionState.Obstacle;
            level.positions[6, 3].State = PositionState.Obstacle;
            level.positions[6, 4].State = PositionState.Obstacle;
            level.positions[8, 1].State = PositionState.Enemy;
            
            return level; 
        }
    }
}
