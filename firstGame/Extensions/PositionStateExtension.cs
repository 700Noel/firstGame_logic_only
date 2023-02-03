using firstgame.Entities.World;
using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Extensions
{
    internal static class PositionStateExtension
    {
        internal static string AsString(this PositionState state)
        {
            return state switch
            {
                PositionState.Empty => ". ",
                PositionState.Player => "O ",
                PositionState.Enemy => "X ",
                PositionState.Obstacle => "T ",
                PositionState.Path => "_ ",
                PositionState.Weapon => "W ",
                PositionState.Health => "H ",
                _ => ""
            };
        }
        internal static PositionState GetFromNumber(int number)
        {
            return number switch
            {
                0 => PositionState.Empty,
                1 => PositionState.Player,
                2 => PositionState.Enemy,
                3 => PositionState.Obstacle,
                4 => PositionState.Path,
                5 => PositionState.Weapon,
                6 => PositionState.Health,
                _ => throw new NotImplementedException()
            };
        }

        internal static int ReturnNumber(this PositionState state)
        {
            return state switch
            {
                PositionState.Empty => 0,
                PositionState.Player => 1,
                PositionState.Enemy => 2,
                PositionState.Obstacle => 3,
                PositionState.Path => 4,
                PositionState.Weapon => 5,
                PositionState.Health => 6,
            };
        }
    }
}
