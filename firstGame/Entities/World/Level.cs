using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstgame.Entities.Enums;
using firstgame.Entities.World;
using firstgame.Entities.Characters;
using firstgame.Entities.Characters.PlayerMechanics;
using firstgame.Entities.World.WorldInteraction;

namespace firstgame.Entities
{
    internal class Level
    {
        public Vector2 size { get; private set; }
        public Position[,] positions { get; private set; }

        protected Vector2? PlayerPosition;

        private Player fullPlayerData;

        private Map worldMap;

        PlayerMove playerMove = new PlayerMove();

        private List<Enemy> levelEnemies = new List<Enemy>();

        private List<WeaponItem> weaponItems = new List<WeaponItem>();

        public Position GetPosition(int x, int y)
        {
            return positions[y, x];
        }

        public void SetPlayerData(Player player)
        {
            fullPlayerData = player;
            PlayerPosition = player.position.vector2;
        }

        public void SetMap(Map map)
        {
            worldMap = map;
        }

        public void GenerateEnemies(List<Enemy> enemies, Level level)
        {
            foreach(Enemy enemy in enemies)
            {
                if (EnemyInEmpty(enemy.enemyPosition.vector2.x, enemy.enemyPosition.vector2.y, level)) {
                    levelEnemies.Add(enemy);
                }
            }
        }

        public void GenerateItems(List<WeaponItem> weapons)
        {
            foreach (WeaponItem weaponItem in weapons)
            {
                weaponItems.Add(weaponItem);
            }
        }

        public bool CheckEnemyPosition(int x, int y)
        {
            foreach(Enemy enemy in levelEnemies) 
            {
                int EnemyX = enemy.position.vector2.x;
                int EnemyY = enemy.position.vector2.y;
                if (EnemyX == x && EnemyY == y )
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckItemPosition(int x, int y)
        {
            foreach(WeaponItem weaponItem in weaponItems)
            {
                int weaponItemX = weaponItem.position.vector2.x;
                int weaponItemY = weaponItem.position.vector2.y;
                if(weaponItemX == x && weaponItemY == y )
                {
                    return true;
                }
            }
            return false;
        }

        public bool EnemyInEmpty(int x, int y, Level level)
        {
            if (level.positions[x,y].State == PositionState.Empty)
            {
                return true;
            }
            return false;
        }

        public List<Enemy> Enemies()
        {
            return levelEnemies;
        }

        public List<WeaponItem> WeaponItems()
        {
            return weaponItems;
        }

        public void Move(Direction direction)
        {
            playerMove.getNecasseryData(fullPlayerData, PlayerPosition, size, worldMap, positions, weaponItems);
            playerMove.MovePlayer(direction);
        }

        
        

        public Level(Vector2 size, Position[,] positions)
        {
            this.size = size;
            this.positions = positions;
        }
    }
}
