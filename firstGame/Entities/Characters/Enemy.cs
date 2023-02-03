using firstgame.Entities.Characters.EnemyMechanics;
using firstgame.Entities.Characters.NPCs;
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
        public string race { get; private set; }
        public int damage { get; private set; }
        public Position position { get; private set; }
        public int health { get; private set; }

        public byte id { get; private set; }

        public void DamageEnemy(int newHealth)
        {
            this.health -= newHealth;
        }


        public Enemy Clone()
        {
            Position clonedPosition = position.Clone();
            return new Enemy(this.id, clonedPosition, this.damage);
        }


        public Enemy(byte id, Position position, int damage)
            : base(position, damage)
        {
            CreateEnemy create = new CreateEnemy(id);
            this.race = create.GetRace();
            this.position = position;
            this.health = create.GetHealth();
            this.damage = create.GetDamage();
            this.id = id;
        }
        
    }
}
