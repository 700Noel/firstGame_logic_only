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

        public bool InRange(Position playerPosition, Position enemyPosition, Weapon weapon, Direction direction) 
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
            if(PlayerToEnemyRange(playerX, EnemyX, range, direction) && PlayerToEnemyRange(playerY, EnemyY, 0, direction) || 
                PlayerToEnemyRange(playerY, EnemyY, range, direction) && PlayerToEnemyRange(playerX, EnemyX, 0, direction)) {
                return true;
            }
            return false;
        }

        private bool PlayerToEnemyRange(int playerVector, int enemyVector, int checkNumber, Direction direction)
        {
            if (direction == Direction.Up || direction == Direction.Left)
            {
                if (playerVector - enemyVector <= checkNumber && playerVector - enemyVector >= 0)
                {
                    return true;
                }
                return false;
            } else
            {
                if (playerVector - enemyVector >= -checkNumber && playerVector - enemyVector <= 0)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
