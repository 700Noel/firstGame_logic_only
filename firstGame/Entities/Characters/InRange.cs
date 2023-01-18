using firstgame.Entities.Enums;
using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters
{
    internal class Range
    {
        int range;

        public bool InRange(Position playerPosition, Position enemyPosition, Weapon weapon) 
        {
            if (weapon == Weapon.Speer)
            {
                range = 2;
            } else
            {
                range = 1;
            }
            if(Math.Abs(playerPosition.worldPosition.x - enemyPosition.worldPosition.x) == range || Math.Abs(playerPosition.worldPosition.y - enemyPosition.worldPosition.y) == range) {
                return true;
            }
            return false;
        }

    }
}
