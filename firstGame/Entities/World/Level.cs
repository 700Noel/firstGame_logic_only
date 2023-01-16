using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstgame.Entities.World;

namespace firstgame.Entities
{
    internal class Level
    {
        public Vector2 size { get; private set; }
        public Position[,] positions { get; private set; }

        public Position GetPosition(int x, int y)
        {
            return positions[y, x];
        }

        public Level(Vector2 size, Position[,] positions)
        {
            this.size = size;
            this.positions = positions;
        }
    }
}
