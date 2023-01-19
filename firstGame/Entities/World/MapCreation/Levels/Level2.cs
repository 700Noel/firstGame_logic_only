using firstgame.Entities.LevelCreation;
using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstgame.Entities.Characters;

namespace firstgame.Entities.World.MapCreation.Levels
{
    internal class Level2
    {
        Fill fill = new Fill();
        Entrance entrance = new Entrance();
        public Level CreateLevel()
        {

            Level level = fill.CreateBorderLevel(1);
            entrance.CreateEntrance(Direction.Left, level);
            entrance.CreateEntrance(Direction.Right, level);
            level.positions[5, 3].State = PositionState.Obstacle;
            level.positions[5, 4].State = PositionState.Obstacle;
            level.positions[6, 3].State = PositionState.Obstacle;
            level.positions[6, 4].State = PositionState.Obstacle;
            level.positions[8, 1].State = PositionState.Enemy;

            Enemy enemy1 = new Enemy(1, 20, new Position(new Vector2(8,1), 2), 5);

            return level; 
        }
    }
}
