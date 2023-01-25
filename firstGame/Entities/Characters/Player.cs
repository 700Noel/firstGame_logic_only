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

        public int health { get; private set; }

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

        public int Attack(Level level)
        {
            /*if(range.InRange(position, enemy.position, weapon)) {
                if (weapon == Weapon.Sword) { damage = 10; }
                else if (weapon == Weapon.Axe) { damage = 20; }
            }
                else if( weapon == Weapon.Speer ) { damage = 10; } 
            
            */
            return ReturnDamage(); 
        }

        private int ReturnDamage() 
        {
            switch (weapon)
            {
                case Weapon.Sword:
                    return 10;
                case Weapon.Speer:
                    return 10;
                case Weapon.Axe:
                    return 20;
                default:
                    return 0;
            }
        }

        public void EnemyContact()
        {
            health -= 5;
        }

        public Player(string name, int health, Position startPosition, int damage)
            :base(startPosition, damage) 
        {
            this.damage = ReturnDamage();
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
