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
        Enemy enemy1 = new Enemy(1, new Position(new Vector2(8, 1), 2), 0);
        Enemy enemy2 = new Enemy(1, new Position(new Vector2(8, 2), 2), 0);

        public Level CreateLevel()
        {

            Level level = fill.CreateBorderLevel(1);
            entrance.CreateEntrance(Direction.Left, level);
            entrance.CreateEntrance(Direction.Right, level);
            level.positions[5, 3].State = PositionState.Obstacle;
            level.positions[5, 4].State = PositionState.Obstacle;
            level.positions[6, 3].State = PositionState.Obstacle;
            level.positions[6, 4].State = PositionState.Obstacle;
            level.positions[5, 5].State = PositionState.Obstacle;
            level.positions[5, 6].State = PositionState.Obstacle;
            level.positions[6, 5].State = PositionState.Obstacle;
            level.positions[6, 6].State = PositionState.Obstacle;

            enemies.Add(enemy1);
            enemies.Add(enemy2);

            level.GenerateEnemies(enemies, level);


            return level; 
        }
    }
}
