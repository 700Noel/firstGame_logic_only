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

        public void CreateEntranceWithPath(Direction direction, Level level) {
            if(direction == Direction.Up)
            {
                for (int i = 0; i < 5; i++) {
                    level.positions[5, i].State = PositionState.Path;
                    level.positions[6, i].State = PositionState.Path;
                }
            }
            if (direction == Direction.Down)
            {
                for (int i = 3; i <= 7; i++)
                {
                    level.positions[5, i].State = PositionState.Path;
                    level.positions[6, i].State = PositionState.Path;
                }
            }
            if (direction == Direction.Left)
            {
                for (int i = 0; i <= 6; i++) {
                    level.positions[i, 3].State = PositionState.Path;
                    level.positions[i, 4].State = PositionState.Path;
                }
            }
            if (direction == Direction.Right)
            {
                for (int i = 5; i <= 11; i++) {
                    level.positions[i, 3].State = PositionState.Path;
                    level.positions[i, 4].State = PositionState.Path;
                }
            }
        }

        public void CreateEntrance(Direction direction, Level level, int howFar, int borderThickness)
        {
            if(howFar < 0)
            {
                howFar = 0;
            } else if(howFar > borderThickness)
            {
                howFar--;
            }
            if (direction == Direction.Up)
            {
                for (int i = 0; i < borderThickness; i++)
                {
                    if (i <= 0 - howFar + 1)
                    {
                        level.positions[5, i].State = PositionState.Path;
                        level.positions[6, i].State = PositionState.Path;
                    }
                    else
                    {
                        level.positions[5, i].State = PositionState.Empty;
                        level.positions[6, i].State = PositionState.Empty;
                    }
                }
            }
            if (direction == Direction.Down)
            {
                for (int i = 7; i >= 7 - borderThickness; i--)
                {
                    if (i > 7 - howFar)
                    {
                        level.positions[5, i].State = PositionState.Path;
                        level.positions[6, i].State = PositionState.Path;
                    }
                    else
                    {
                        level.positions[5, i].State = PositionState.Empty;
                        level.positions[6, i].State = PositionState.Empty;
                    }
                }
            }
            if (direction == Direction.Left)
            {
                for (int i = 0; i < borderThickness; i++)
                {
                    if (i <= 0 - howFar + 1) {
                        level.positions[i, 3].State = PositionState.Path;
                        level.positions[i, 4].State = PositionState.Path;
                    }
                    else
                    {
                        level.positions[i, 3].State = PositionState.Empty;
                        level.positions[i, 4].State = PositionState.Empty;
                    }
                }
            }
            if (direction == Direction.Right)
            {
                for (int i = 11; i > 11 - borderThickness; i--)
                {
                    if (i > 11 - howFar)
                    {
                        level.positions[i, 3].State = PositionState.Path;
                        level.positions[i, 4].State = PositionState.Path;
                    }
                    else
                    {
                        level.positions[i, 3].State = PositionState.Empty;
                        level.positions[i, 4].State = PositionState.Empty;
                    }
                }
            }
        }
    }
}
