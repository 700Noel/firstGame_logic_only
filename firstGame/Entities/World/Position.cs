using firstgame.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World
{
    public class Position
    {
        public Vector2 worldPosition { get; set; }

        public PositionState State { get; set; }

        public Position(Vector2 worldPosition, int state)
        {
            this.worldPosition = worldPosition;
            State = PositionStateExtension.GetFromNumber(state);
        }
    }

    public enum PositionState
    {
        Empty,
        Player,
        Enemy,
        Obstacle,
        Path

    }
}
