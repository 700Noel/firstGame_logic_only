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


        List<Enemy> enemies = new List<Enemy>();
        Enemy enemy1 = new Enemy(1, new Position(new Vector2(8, 1), 2));

        public Level CreateLevel()
        {

            Level level = fill.CreateBorderLevel(1);
            entrance.CreateEntrance(Direction.Left, level);
            entrance.CreateEntrance(Direction.Right, level);
            level.positions[5, 3].State = PositionState.Obstacle;
            level.positions[5, 4].State = PositionState.Obstacle;
            level.positions[6, 3].State = PositionState.Obstacle;
            level.positions[6, 4].State = PositionState.Obstacle;

            enemies.Add(enemy1);

            level.GenerateEnemies(enemies);


            return level; 
        }
    }
}
