using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.WorldInteraction
{
    internal class HealthItem : Item
    {
        Position position { get; set; }
        PositionState state { get; set; }

        int health = 20;
        public HealthItem(Position position, PositionState state) : base(position)
        {
            this.position = position;
            this.state = state;
        }

        public int GetHealth()
        { return health; }

        public override void DestroyItem(Level level)
        {
            level.healthItems.Remove(this);
        }
    }
}
