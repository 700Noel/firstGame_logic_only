using firstgame.Extensions;
using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World
{
    public class Position
    {
        public Vector2 vector2 { get; set; }

        public PositionState State { get; set; }

        public Position(Vector2 worldPosition, int state)
        {
            this.vector2 = worldPosition;
            State = PositionStateExtension.GetFromNumber(state);
        }
    }


}
