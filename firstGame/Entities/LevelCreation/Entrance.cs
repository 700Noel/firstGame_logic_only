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
                level.positions[5, 0].State = World.PositionState.Path;
                level.positions[6, 0].State = World.PositionState.Path;
            }
            if (direction == Direction.Down)
            {
                level.positions[5, 7].State = World.PositionState.Path;
                level.positions[6, 7].State = World.PositionState.Path;
                
            }
            if (direction == Direction.Left)
            {
                level.positions[0, 3].State = World.PositionState.Path;
                level.positions[0, 4].State = World.PositionState.Path;
            }
            if (direction == Direction.Right)
            {
                level.positions[11, 3].State = World.PositionState.Path;
                level.positions[11, 4].State = World.PositionState.Path;
            }
        }
    }
}
