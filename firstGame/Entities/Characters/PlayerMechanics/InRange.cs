using firstgame.Entities.Enums;
using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters.PlayerMechanics
{
    internal class Range
    {
        int range;

        public bool InRange(Position playerPosition, Position enemyPosition, Weapon weapon, Direction direction)
        {
            int playerX = playerPosition.vector2.x;
            int playerY = playerPosition.vector2.y;
            int EnemyX = enemyPosition.vector2.x;
            int EnemyY = enemyPosition.vector2.y;

            if (weapon == Weapon.Speer)
            {
                range = 2;
            }
            else if (weapon == Weapon.none)
            {
                range = 0;
            }
            else
            {
                range = 1;
            }
            if (PlayerToEnemyRange(playerX, EnemyX, range, direction) && PlayerToEnemyRange(playerY, EnemyY, 0, direction) ||
                PlayerToEnemyRange(playerY, EnemyY, range, direction) && PlayerToEnemyRange(playerX, EnemyX, 0, direction))
            {
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
            }
            else
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
