using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World
{
    public class Vector2
    {
        private int X, Y;

        public int x
        {
            get => X;
        }

        public int y
        {
            get => Y;
        }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left.x == right.x && left.y == right.y);

        }
    }
}