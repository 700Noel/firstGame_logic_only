using firstgame.Entities.Characters;
using firstgame.Entities.Characters.EnemyMechanics;
using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities
{
    internal class OnPlayerAction
    {
        //EnemyMovement enemyMovement = new EnemyMovement();
        Enemy_AI enemy_AI = new Enemy_AI();


        public void EnemiesMove(Player player, Level level) {
            if (level.positions[player.position.vector2.x, player.position.vector2.y].State != PositionState.Path)
            {
                foreach (Enemy enemy in level.Enemies())
                {
                    //enemyMovement.MoveEnemyTowardsPlayer(level, player, enemy);
                    enemy.SetEnemyPosition(enemy_AI.generatePath(enemy.position, player.position, level).Last());
                }
                
            }
        }
    }
}
