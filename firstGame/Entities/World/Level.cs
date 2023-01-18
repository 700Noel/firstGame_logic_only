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

        public Position GetPosition(int x, int y)
        {
            return positions[y, x];
        }

        public void SetplayerPosition(Player player)
        {
            PlayerPosition = player.position.worldPosition;
        }

        public void Move(Direction direction)
        {
            if (PlayerPosition is null) throw new Exception("Player Position was null");

            switch (direction)
            {
                case Direction.Left:
                    PlayerPosition.x--;
                    break;
                case Direction.Right:
                    PlayerPosition.x++;
                    break;
                case Direction.Up:
                    PlayerPosition.y--;
                    break;
                case Direction.Down:
                    PlayerPosition.y++;
                    break;
            }
        }

        public Level(Vector2 size, Position[,] positions)
        {
            this.size = size;
            this.positions = positions;
        }
    }
}
