using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstgame.Entities.World;

namespace firstgame.Entities.LevelCreation
{

    internal class Fill
    {
        Checker checker = new Checker();
        const int WIDTH = 12;
        const int HEIGHT = 8;
        public Level CreateEmptyLevel()
        {
            Level level = new Level(new Vector2(WIDTH, HEIGHT), FillingPositions(0));
            return level;
        }

        public Level CreateBorderLevel(int borderThickness)
        {
            Level level = new Level(new Vector2(WIDTH, HEIGHT), FillingPositions(borderThickness));
            return level;
        }


        internal Position[,] FillingPositions(int borderThickness)
        {
            Position[,] positions = new Position[WIDTH, HEIGHT];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (borderThickness > 0 && (checker.TicknessHorizontal(borderThickness, i, HEIGHT) || checker.TicknessHorizontal(borderThickness, j, WIDTH)))
                    {
                        positions[j, i] = new Position(new Vector2(j, i), 3);
                    }
                    else
                    {
                        positions[j, i] = new Position(new Vector2(j, i), 0);
                    }
                }
            }
            return positions;
        }
    }
}
