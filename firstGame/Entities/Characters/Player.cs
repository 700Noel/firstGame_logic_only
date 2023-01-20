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

        public Direction direction { get; private set; }

        public string name { get; private set; }

        Level level;

        public int damage { get; private set; }

        private int health;

        Range range = new Range();

        Position currentPosition;



        public void SetWeapon(Weapon currentWeapon)
        {
            this.weapon = currentWeapon;
        }

        public void getLevel(Level currentLevel)
        {
            level = currentLevel;
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

        public void EnemyContact()
        {
            health = -5;
        }

        public Player(string name, int health, Position startPosition)
            :base(startPosition) 
        {
            this.health = health;
            currentPosition = startPosition;
            this.name = name;
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
