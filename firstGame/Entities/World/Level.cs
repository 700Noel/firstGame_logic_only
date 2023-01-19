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

        private Player playerData;

        public Position GetPosition(int x, int y)
        {
            return positions[y, x];
        }

        public void SetPlayerData(Player player)
        {
            Player playerData = player;
            PlayerPosition = player.position.worldPosition;
        }

        public void MovePlayer(Direction direction)
        {
            Move(direction, PlayerPosition);
        }

        public void Move(Direction direction, Vector2 CharacterPosition)
        {
            if (CharacterPosition is null) throw new Exception("Player Position was null");

            switch (direction)
            {
                case Direction.Left:
                    if (CheckCanMove(new Vector2(CharacterPosition.x - 1, CharacterPosition.y)))
                    {
                        CharacterPosition.x--;
                    }
                    break;
                case Direction.Right:
                    if (CheckCanMove(new Vector2(CharacterPosition.x + 1, CharacterPosition.y)))
                    {
                        CharacterPosition.x++;
                    }
                    break;
                case Direction.Up:
                    if (CheckCanMove(new Vector2(CharacterPosition.x, CharacterPosition.y - 1)))
                    {
                        CharacterPosition.y--;
                    }
                    break;
                case Direction.Down:
                    if (CheckCanMove(new Vector2(CharacterPosition.x, CharacterPosition.y + 1)))
                    {
                        CharacterPosition.y++;
                    }
                    break;
            }
        }

        public bool CheckCanMove(Vector2 position)
        {
            var state = positions[position.x, position.y].State;
            if (state == World.PositionState.Enemy) {
                playerData.EnemyContact();
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
