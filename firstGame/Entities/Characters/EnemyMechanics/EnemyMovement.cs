using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters.EnemyMechanics
{
    internal class EnemyMovement
    {

        public void MoveEnemyTowardsPlayer(Level level, Player player, Enemy enemy)
        {
            int playerX = player.position.vector2.x;
            int playerY = player.position.vector2.y;
            int enemyX = enemy.position.vector2.x;
            int enemyY = enemy.position.vector2.y;

            if (level.positions[playerX, playerY].State != Enums.PositionState.Path)
            {
                int differenceX = playerX - enemyX;
                int differenceY = playerY - enemyY;
                if(Math.Abs(differenceX) >= Math.Abs(differenceY) && Math.Abs(differenceX) > 1)
                {
                    if(differenceX > 0)
                    {
                        enemy.position.vector2.x++;
                    } else
                    {
                        enemy.position.vector2.x--;
                    }
                } else if(Math.Abs(differenceY) > 1)
                {
                    if (differenceY > 0)
                    {
                        enemy.position.vector2.y++;
                    }
                    else
                    {
                        enemy.position.vector2.y--;
                    }
                }
            }
        }
    }
}
