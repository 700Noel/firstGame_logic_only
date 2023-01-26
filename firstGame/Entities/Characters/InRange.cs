using firstgame.Entities.Enums;
using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters
{
    internal class Range
    {
        int range;

        public bool InRange(Position playerPosition, Position enemyPosition, Weapon weapon) 
        {
            int playerX = playerPosition.worldPosition.x;
            int playerY = playerPosition.worldPosition.y;
            int EnemyX = enemyPosition.worldPosition.x;
            int EnemyY = enemyPosition.worldPosition.y;

            if (weapon == Weapon.Speer)
            {
                range = 2;
            } else if (weapon == Weapon.none) 
            {
                range = 0;
            } else
            {
                range = 1;
            }
            if(PlayerToEnemyRange(playerX, EnemyX, range) && PlayerToEnemyRange(playerY, EnemyY, 0) || PlayerToEnemyRange(playerY, EnemyY, range) && PlayerToEnemyRange(playerX, EnemyX, 0)) {
                return true;
            }
            return false;
        }

        private bool PlayerToEnemyRange(int playerVector, int enemyVector, int checkNumber)
        {
            if(Math.Abs(playerVector - enemyVector) <= checkNumber)
            {
                return true;
            }
            return false;
        }

    }
}
