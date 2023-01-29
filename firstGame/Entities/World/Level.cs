using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstgame.Entities.Enums;
using firstgame.Entities.World;
using firstgame.Entities.Characters;
using firstgame.Entities.Characters.PlayerMechanics;

namespace firstgame.Entities
{
    internal class Level
    {
        public Vector2 size { get; private set; }
        public Position[,] positions { get; private set; }

        protected Vector2? PlayerPosition;

        private Player fullPlayerData;

        private Direction playerDirection;

        private Map worldMap;

        PlayerMove playerMove = new PlayerMove();

        private List<Enemy> levelEnemies = new List<Enemy>();

        public Position GetPosition(int x, int y)
        {
            return positions[y, x];
        }

        public void SetPlayerData(Player player)
        {
            fullPlayerData = player;
            playerDirection = player.direction;
            PlayerPosition = player.position.worldPosition;
        }

        public void GiveMap(Map map)
        {
            worldMap = map;
        }

        public void GenerateEnemies(List<Enemy> enemies, Level level)
        {
            foreach(Enemy enemy in enemies)
            {
                if (EnemyInEmpty(enemy.enemyPosition.worldPosition.x, enemy.enemyPosition.worldPosition.y, level)) {
                    levelEnemies.Add(enemy);
                }
            }
        }

        public bool CheckEnemyPosition(int x, int y)
        {
            foreach(Enemy enemy in levelEnemies) {
                int EnemyX = enemy.position.worldPosition.x;
                int EnemyY = enemy.position.worldPosition.y;
               if (EnemyX == x && EnemyY == y )
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

        public void Move(Direction direction)
        {
            playerMove.getNecasseryData(fullPlayerData, PlayerPosition, size, worldMap, positions);
            playerMove.MovePlayer(direction);
        }

        
        

        public Level(Vector2 size, Position[,] positions)
        {
            this.size = size;
            this.positions = positions;
        }
    }
}
