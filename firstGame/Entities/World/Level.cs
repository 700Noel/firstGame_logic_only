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
using firstgame.Entities.Characters.EnemyMechanics;

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

        private List<Enemy> enemies = new List<Enemy>();

        private List<Enemy> backupEnemies = new List<Enemy>();

        private List<WeaponItem> weaponItems = new List<WeaponItem>();

        public List<HealthItem> healthItems = new List<HealthItem>();

        public Position GetPosition(int y, int x)
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

        public void RespawnEnemies()
        {

            enemies.Clear();
            foreach (Enemy enemy in backupEnemies)
            {
                enemies.Add(enemy.Clone());
            }
        }


        public void AddItem(HealthItem health)
        {
            healthItems.Add(health);
        }


        public void GenerateEnemies(List<Enemy> enemies, Level level)
        {
            foreach(Enemy enemy in enemies)
            {
                if (EnemyInEmpty(enemy.position.vector2.x, enemy.position.vector2.y, level)) {
                    this.enemies.Add(enemy);
                    backupEnemies.Add(enemy.Clone());
                }
            }
            //enemiesInLevel = new EnemiesInLevel(respawningEnemies);
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
            foreach(Enemy enemy in enemies) 
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

        public bool CheckHealthPosition(int x, int y)
        {
            foreach (HealthItem healthItem in healthItems)
            {
                int healthItemX = healthItem.position.vector2.x;
                int healthItemY = healthItem.position.vector2.y;
                if (healthItemX == x && healthItemY == y)
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
            return enemies;
        }

        public List<WeaponItem> WeaponItems()
        {
            return weaponItems;
        }

        public void Move(Direction direction)
        {
            playerMove.getNecasseryData(fullPlayerData, PlayerPosition, size, worldMap, positions, weaponItems, healthItems);
            playerMove.MovePlayer(direction);
        }

        public Level(Vector2 size, Position[,] positions)
        {
            this.size = size;
            this.positions = positions;
        }
    }
}
