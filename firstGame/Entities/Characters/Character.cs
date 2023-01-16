using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters
{
    internal class Character    
    {
        public int health { get; private set; }
        public string name { get; private set; }
        public Position position { get; private set; }

        public Character(string name, int health, Position position) 
        {
            this.name = name;
            this.health = health;   
            this.position = position;
        }
    }
}
