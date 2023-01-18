using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.LevelCreation
{
    internal class Entrance
    {

        public void CreateEntrance(Direction direction, Level level) {
            if(direction == Direction.Up)
            {
                for (int i = 0; i < 5; i++) {
                    level.positions[5, i].State = World.PositionState.Path;
                    level.positions[6, i].State = World.PositionState.Path;
                }
            }
            if (direction == Direction.Down)
            {
                for (int i = 3; i <= 7; i++)
                {
                    level.positions[5, i].State = World.PositionState.Path;
                    level.positions[6, i].State = World.PositionState.Path;
                }
            }
            if (direction == Direction.Left)
            {
                for (int i = 0; i <= 6; i++) {
                    level.positions[i, 3].State = World.PositionState.Path;
                    level.positions[i, 4].State = World.PositionState.Path;
                }
            }
            if (direction == Direction.Right)
            {
                for (int i = 5; i <= 11; i++) {
                    level.positions[i, 3].State = World.PositionState.Path;
                    level.positions[i, 4].State = World.PositionState.Path;
                }
            }
        }
    }
}
