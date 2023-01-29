using firstgame.Entities.Enums;
using firstgame.Entities.World;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = firstgame.Entities.World.Vector2;

namespace firstgame.Entities.Characters.PlayerMechanics
{
    internal class PlayerMove
    {
        protected Vector2? PlayerPosition;

        public Map worldMap { get; private set; }

        public Position[,] positions { get; private set; }

        public Player fullPlayerData { get; private set; }

        public Vector2 size { get; private set; }

        public void getNecasseryData(Player player, Vector2 playerPosition, Vector2 size, Map map, Position[,] positions)
        {
            fullPlayerData = player;
            this.size = size;
            worldMap = map;
            this.positions = positions;
            this.PlayerPosition = playerPosition;
        }

        public void MovePlayer(Direction direction)
        {
            if (PlayerPosition is null) throw new Exception("Player Position was null");

            switch (direction)
            {
                case Direction.Left:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.x - 1 < 0)
                    {
                        PlayerPosition.x = size.x - 1;
                        worldMap.setCurrentLevel(-1);
                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x - 1, PlayerPosition.y)))
                    { PlayerPosition.x--; }
                    break;

                case Direction.Right:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.x + 1 >= size.x)
                    {
                        PlayerPosition.x = 0;
                        worldMap.setCurrentLevel(1);
                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x + 1, PlayerPosition.y)))
                    { PlayerPosition.x++; }
                    break;

                case Direction.Up:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.y - 1 < 0)
                    {
                        PlayerPosition.y = size.y - 1;
                        worldMap.setCurrentLevel(-3);
                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x, PlayerPosition.y - 1)))
                    { PlayerPosition.y--; }
                    break;

                case Direction.Down:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.y + 1 >= size.y)
                    {
                        PlayerPosition.y = 0;
                        worldMap.setCurrentLevel(3);

                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x, PlayerPosition.y + 1)))
                    { PlayerPosition.y++; }
                    break;
            }
        }



        public bool CheckCanMove(Vector2 position)
        {
            var state = positions[position.x, position.y].State;
            if (worldMap.currentLevel.CheckEnemyPosition(position.x, position.y))
            {
                fullPlayerData.EnemyContact();
                return false;
            }
            else if (state == World.PositionState.Empty || state == World.PositionState.Path)
            {
                return true;
            }
            return false;
        }

    }
}
