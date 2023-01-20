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
        public Position enemyPosition { get; private set; }
        public int health { get; private set; }

        public byte id { get; private set; }
        public Enemy(byte id, Position position)
            : base(position)
        {
            CreateEnemy create = new CreateEnemy(id);
            this.race = create.GetRace();
            this.enemyPosition = position;
            this.health = create.GetHealth();
            this.damage = create.GetDamage();
            this.id = id;
        }
        
    }
}
