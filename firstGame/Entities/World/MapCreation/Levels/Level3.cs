using firstgame.Entities.Characters;
using firstgame.Entities.LevelCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.MapCreation.Levels
{
    internal class Level3
    {
        Fill fill = new Fill();
        Entrance entrance = new Entrance();

        List<Enemy> enemies = new List<Enemy>();
        Enemy enemy1 = new Enemy(1, new Position(new Vector2(8,2), 2));
        Enemy enemy2 = new Enemy(1, new Position(new Vector2(8, 2), 2));

        public Level CreateLevel()
        {
            Level level = fill.CreateBorderLevel(2);
            entrance.CreateEntrance(Enums.Direction.Left, level);


            level.positions[4, 3].State = PositionState.Empty;
            level.positions[4, 4].State = PositionState.Empty;
            level.positions[5, 3].State = PositionState.Empty;
            level.positions[5, 4].State = PositionState.Empty;
            level.positions[6, 3].State = PositionState.Empty;
            level.positions[6, 4].State = PositionState.Empty;

            return level;
        }
    }
}
