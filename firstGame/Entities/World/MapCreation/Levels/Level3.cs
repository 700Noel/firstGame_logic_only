using firstgame.Entities.Characters;
using firstgame.Entities.LevelCreation;
using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.MapCreation.Levels
{
    internal class Level3 : LevelCore
    {
        Fill fill = new Fill();
        Entrance entrance = new Entrance();
        Wall wall = new Wall();

        List<Enemy> enemies = new List<Enemy>();
        Enemy enemy1 = new Enemy(1, new Position(new Vector2(5, 6), 2), 0);
        Enemy enemy2 = new Enemy(1, new Position(new Vector2(6, 6), 2), 0);

        public override Level CreateLevel(int borderThickness)
        {
            Level level = fill.CreateBorderLevel(borderThickness);
            entrance.CreateEntranceWithPath(Direction.Left, level);
            entrance.CreateEntrance(Direction.Down, level, 1, borderThickness);

            enemies.Add(enemy1);
            enemies.Add(enemy2);

            level.GenerateEnemies(enemies, level);

            return level;
        }
    }
}
