using firstgame.Entities.Enums;
using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters
{
    internal class Player : Character
    {
        public Weapon weapon { get; private set; }

        public int damage { get; private set; }

        Range range = new Range();

        Position currentPosition;



        public void SetWeapon(Weapon currentWeapon)
        {
            this.weapon = currentWeapon;
        }

        public int Attack(Enemy enemy)
        {
            if(range.InRange(position, enemy.position, weapon)) {
                if (weapon == Weapon.Sword) { damage = 10; }
                else if (weapon == Weapon.Axe) { damage = 20; }
            }
                else if( weapon == Weapon.Speer ) { damage = 10; } 
            

            return damage; 
        }

        public Player(string name, int health, Position startPosition)
            :base(name, health, startPosition) 
        {
            currentPosition = startPosition;
        }

        public int getX()
        {
            return currentPosition.worldPosition.x;
        } 

        public int getY() 
        { 
            return currentPosition.worldPosition.y;
        }

        
        
    }
}
