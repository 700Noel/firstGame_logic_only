using firstgame.Entities.Characters.PlayerMechanics;
using firstgame.Entities.Enums;
using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Range = firstgame.Entities.Characters.PlayerMechanics.Range;

namespace firstgame.Entities.Characters
{
    internal class Player : Character
    {
        public Weapon weapon { get; private set; }

        public Direction direction { get; private set; }

        public string name { get; private set; }

        PlayerCombat playerCombat = new PlayerCombat();

        public int damage { get; private set; }

        public int health { get; private set; }

        Position currentPosition;

        

        public void TestWeapon()
        {
            weapon = Weapon.Axe;
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;
        }

        public void SetWeapon(Weapon currentWeapon)
        {
            this.weapon = currentWeapon;
        }

        public void Combat(Level level)
        {
            playerCombat.getPlayer(this);
            playerCombat.Attack(level);
        }



        public void EnemyContact()
        {
            health -= 5;
        }

        public Player(string name, int health, Position startPosition, int damage)
            :base(startPosition, damage) 
        {
            this.damage = playerCombat.ReturnDamage();
            this.health = health;
            currentPosition = startPosition;
            this.name = name;
        }

        public int getX()
        {
            return currentPosition.vector2.x;
        } 

        public int getY() 
        { 
            return currentPosition.vector2.y;
        }

        
        
    }
}
