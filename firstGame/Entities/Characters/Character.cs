using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters
{
    internal abstract class Character    
    {
        public int health { get; private set; }
        public int damage { get; private set; } 
        public Position position { get; private set; }

        public Character(Position position, int damage) 
        {  
            this.position = position;
            this.damage = damage;
        }
    }
}
