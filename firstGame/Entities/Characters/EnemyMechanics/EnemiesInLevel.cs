using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters.EnemyMechanics
{
    internal class EnemiesInLevel
    {
        List<Enemy> levelEnemies = new List<Enemy>();

        public EnemiesInLevel(List<Enemy> levelEnemies)
        {
            this.levelEnemies = levelEnemies;
        }
        
        public void respawningEnemies(List<Enemy> enemies)
        {
            enemies = levelEnemies;
        }
    }
}
