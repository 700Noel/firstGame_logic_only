using firstgame.Entities.Enums;
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

            if (level.positions[playerX, playerY].State != PositionState.Path)
            {
                int differenceX = playerX - enemyX;
                int differenceY = playerY - enemyY;
                if(Math.Abs(differenceX) >= Math.Abs(differenceY) && Math.Abs(differenceX) > 1)
                {
                    if(differenceX > 0 && CheckFreeSpot(level, enemyX + 1, enemyY))
                    {
                        enemy.position.vector2.x++;
                    } else if(CheckFreeSpot(level, enemyX - 1, enemyY))
                    {
                        enemy.position.vector2.x--;
                    }
                } else if(Math.Abs(differenceY) > 1)
                {
                    if (differenceY > 0 && CheckFreeSpot(level, enemyX, enemyY + 1))
                    {
                        enemy.position.vector2.y++;
                    }
                    else if(CheckFreeSpot(level, enemyX, enemyY - 1))
                    {
                        enemy.position.vector2.y--;
                    }
                }
            }
        }

        public bool CheckFreeSpot(Level level, int enemyX, int enemyY)
        {
            PositionState newPosition = level.positions[enemyX, enemyY].State;
            if (newPosition == PositionState.Player || newPosition == PositionState.Obstacle || newPosition == PositionState.Path)
            {
                return false;
            }
            return true;
        }
    }
}
