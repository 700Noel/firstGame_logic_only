using firstgame.Entities.Enums;
using firstgame.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.WorldInteraction
{
    internal abstract class Item
    {

        public Position position { get; set; }

        public Item(Position position)
        {
            this.position = position;
        }

        public abstract void DestroyItem(Level level);

    }
}
