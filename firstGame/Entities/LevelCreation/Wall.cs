using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.LevelCreation
{
    internal class Wall
    {
        public void CreateWall(int fromX, int toX, int fromY, int toY, Level level)
        {
            for(int x = fromX; x <= toX; x++)
            {
                for (int y = fromY; y <= toY; y++)
                {
                    level.positions[x, y].State = Enums.PositionState.Obstacle;
                } 
            }
        }
    }
}
