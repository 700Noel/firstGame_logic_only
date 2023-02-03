using firstgame.Entities.LevelCreation;
using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstgame.Entities.Characters;
using firstgame.Entities.World.WorldInteraction;
using System.Transactions;

namespace firstgame.Entities.World.MapCreation.Levels
{
    internal class Level2 : LevelCore
    {
        Fill fill = new Fill();
        Entrance entrance = new Entrance();
        Wall wall = new Wall();

        List<WeaponItem> weapons = new List<WeaponItem>();
        WeaponItem sword = new WeaponItem(new Position(new Vector2(4, 3), 5), Weapon.Sword);


        List<Enemy> enemies = new List<Enemy>();
        Enemy enemy1 = new Enemy(1, new Position(new Vector2(8, 1), 2), 0);
        Enemy enemy2 = new Enemy(1, new Position(new Vector2(10, 2), 2), 0);



        public override Level CreateLevel(int borderThickness)
        {

            Level level = fill.CreateBorderLevel(borderThickness);
            entrance.CreateEntranceWithPath(Direction.Left, level);
            entrance.CreateEntranceWithPath(Direction.Right, level);
            wall.CreateWall(5, 6, 3, 6, level);

            enemies.Add(enemy1);
            enemies.Add(enemy2);

            weapons.Add(sword);

            level.GenerateItems(weapons);

            level.GenerateEnemies(enemies, level);


            return level; 
        }

    }
}
