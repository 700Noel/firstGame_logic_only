using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters.NPCs
{
    internal class CreateEnemy
    {

        public string race { get; private set; }
        public int health { get; private set; }
        public int damage { get; private set; }

        public CreateEnemy(int id) 
        {
            switch (id)
            {
                case 1:
                    race = "Wolf";
                    health = 30;
                    damage = 5;
                    break;
                default:
                    race = "empty";
                    health = 0;
                    damage = 0;
                    break;
            }
            
                
        }
 
        public int GetHealth()
        {
            return health;
        }

        public int GetDamage()
        {
            return damage;
        }

        public string GetRace()
        {
            return race;
        }

    }
}
