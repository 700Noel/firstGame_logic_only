using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters
{
    internal class Enemy : Character
    {
        public int damage { get; private set; }

        public byte id { get; private set; }
        public Enemy(byte id, int health, Position position, int damage)
            : base(health, position)
        {
            this.damage = damage;
            this.id = id;
        }
        
    }
}
