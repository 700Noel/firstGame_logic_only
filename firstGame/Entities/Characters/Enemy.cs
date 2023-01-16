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
        public Enemy(string name, int health, Position position, int damage)
            : base(name, health, position)
        {
            this.damage = damage;
        }
        
    }
}
