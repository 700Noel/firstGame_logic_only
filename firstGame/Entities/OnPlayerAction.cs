using firstgame.Entities.Characters;
using firstgame.Entities.Characters.EnemyMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities
{
    internal class OnPlayerAction
    {
        EnemyMovement enemyMovement = new EnemyMovement();

        public void EnemiesMove(Player player, Level level) {
                foreach (Enemy enemy in level.Enemies())
                {
                    enemyMovement.MoveEnemyTowardsPlayer(level, player, enemy);
                }
        }
    }
}
