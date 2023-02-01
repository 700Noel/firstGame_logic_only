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
        public void EnemiesList(List<Enemy> enemies)
        {
            levelEnemies = enemies;
        }
        
        public List<Enemy> respawningEnemies()
        {
            return levelEnemies;
        }
    }
}
