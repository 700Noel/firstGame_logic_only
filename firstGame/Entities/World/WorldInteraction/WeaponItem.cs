using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World.WorldInteraction
{
    internal class WeaponItem : Item
    {
        Position position;

        public Weapon weapon;

        public WeaponItem(Position position, Weapon weapon) : base(position)
        {
            this.position = position;
            this.weapon = weapon;
        }

        public override void DestroyItem(Level level)
        {
            level.WeaponItems().Remove(this);
        }
    }
}
