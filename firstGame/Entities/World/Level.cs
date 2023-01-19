using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstgame.Entities.Enums;
using firstgame.Entities.World;
using firstgame.Entities.Characters;

namespace firstgame.Entities
{
    internal class Level
    {
        public Vector2 size { get; private set; }
        public Position[,] positions { get; private set; }

        protected Vector2? PlayerPosition;

        private Player fullPlayerData;

        private Map worldMap;

        private List<Enemy> levelEnemies = new List<Enemy>();

        public Position GetPosition(int x, int y)
        {
            return positions[y, x];
        }

        public void SetPlayerData(Player player)
        {
            fullPlayerData = player;
            PlayerPosition = player.position.worldPosition;
        }

        public void GiveMap(Map map)
        {
            worldMap = map;
        }

        public void GenerateEnemies(List<Enemy> enemies)
        {
            foreach(Enemy enemy in enemies)
            {
                levelEnemies.Add(enemy);
            }
        }

        public bool CheckEnemyPosition(int x, int y)
        {
            foreach(Enemy enemy in levelEnemies) {
                int EnemyX = enemy.position.worldPosition.x;
                int EnemyY = enemy.position.worldPosition.y;
               if (EnemyX == x && EnemyY == y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EnemyInEnmpty(int x, int y)
        {
            if (worldMap.currentLevel.positions[x,y].State == World.PositionState.Empty)
            {
                return true;
            }
            return false;
        }

        
        public void MovePlayer(Direction direction)
        {
            if (PlayerPosition is null) throw new Exception("Player Position was null");

            switch (direction)
            {
                case Direction.Left:
                    if (PlayerPosition.x - 1 < 0)
                    {
                        PlayerPosition.x = size.x - 1;
                        worldMap.setCurrentLevel(-1);
                    } else if (CheckCanMove(new Vector2(PlayerPosition.x - 1, PlayerPosition.y)))
                    { PlayerPosition.x--; }
                    break;

                case Direction.Right:
                    if (PlayerPosition.x + 1 >= size.x)
                    {
                        PlayerPosition.x = 0;
                        worldMap.setCurrentLevel(1);
                    } else if (CheckCanMove(new Vector2(PlayerPosition.x + 1, PlayerPosition.y)))
                    { PlayerPosition.x++; }
                    break;

                case Direction.Up:
                    if (PlayerPosition.y - 1 < 0)
                    {
                        PlayerPosition.y = size.y - 1;
                        worldMap.setCurrentLevel(-3);
                    } else if (CheckCanMove(new Vector2(PlayerPosition.x, PlayerPosition.y - 1)))
                    { PlayerPosition.y--; }
                    break;

                case Direction.Down:
                    if (PlayerPosition.y + 1 >= size.y)
                    {
                        PlayerPosition.y = 0;
                        worldMap.setCurrentLevel(3);

                    } else if (CheckCanMove(new Vector2(PlayerPosition.x, PlayerPosition.y + 1)))
                    { PlayerPosition.y++; }
                    break;
            }
        }



        public bool CheckCanMove(Vector2 position)
        {
            var state = positions[position.x, position.y].State;
            if (worldMap.currentLevel.CheckEnemyPosition(position.x, position.y)) {
                fullPlayerData.EnemyContact();
                return false;
            } else if (state == World.PositionState.Empty || state == World.PositionState.Path)
            {
                return true;
            }
            return false;
        }

        public Level(Vector2 size, Position[,] positions)
        {
            this.size = size;
            this.positions = positions;
        }
    }
}
