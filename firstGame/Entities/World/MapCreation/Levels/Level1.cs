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
    internal class Level1 : LevelCore
    {
        Fill fill = new Fill();
        Entrance entrance= new Entrance();
        List<Enemy> enemies = new List<Enemy>();
        Enemy enemy = new Enemy(1, new Position(new Vector2(3, 5), 2), 0);
        public override Level CreateLevel(int borderThickness) { 
            
            Level level = fill.CreateBorderLevel(borderThickness);
            //entrance.CreateEntrance(Enums.Direction.Down, level);
            entrance.CreateEntranceWithPath(Enums.Direction.Right, level);
            //entrance.CreateEntrance(Enums.Direction.Left, level);
            //entrance.CreateEntrance(Enums.Direction.Up, level);

            //level.GetPosition(3, 4).State = PositionState.Obstacle;

            //enemies.Add(enemy);
            //level.GenerateEnemies(enemies, level);
            return level;
        }
    }
}
