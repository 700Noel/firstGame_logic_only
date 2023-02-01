using firstgame.Entities.Enums;
using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = firstgame.Entities.World.Vector2;

namespace firstgame.Entities.Characters.EnemyMechanics
{
    internal class EnemyMovement
    {
        private bool playerInRange;

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
                if(Math.Abs(differenceX) >= Math.Abs(differenceY) )
                {
                    EnemyAttackPlayer(player, enemy);
                    if(differenceX > 0 && CheckFreeSpot(level, new Vector2(enemyX + 1, enemyY), new Vector2(playerX, playerY)))
                    {
                        enemy.position.vector2.x++;
                    } else if(CheckFreeSpot(level, new Vector2(enemyX - 1, enemyY), new Vector2(playerX, playerY)))
                    {
                        enemy.position.vector2.x--;
                    }
                } else
                {
                    EnemyAttackPlayer(player, enemy);
                    if (differenceY > 0 && CheckFreeSpot(level, new Vector2(enemyX, enemyY + 1), new Vector2(playerX, playerY)))
                    {
                        enemy.position.vector2.y++;
                    }
                    else if(CheckFreeSpot(level, new Vector2(enemyX, enemyY - 1), new Vector2(playerX, playerY)))
                    {
                        enemy.position.vector2.y--;
                    }
                }
            }
        }

        public bool CheckFreeSpot(Level level, Vector2 enemy, Vector2 player)
        {
            PositionState newPosition = level.positions[enemy.x, enemy.y].State;
            if (newPosition == PositionState.Obstacle || newPosition == PositionState.Path)
            {
                return false;
            } else if(enemy.x == player.x && enemy.y == player.y)
            {
                playerInRange = true;
                return false;
            }
            return true;
        }

        private void EnemyAttackPlayer(Player player, Enemy enemy)
        {
            if (playerInRange)
            {
                player.PlayerHit(enemy.damage);
                playerInRange = false;
            }
        }
    }
}
