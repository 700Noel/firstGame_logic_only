using firstgame.Entities.World;
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
                PositionState.Empty => ".",
                PositionState.Player => "O",
                PositionState.Enemy => "X",
                PositionState.Obstacle => "T",
                PositionState.Path => "_",
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
                _ => throw new NotImplementedException()
            };
        }
    }
}
