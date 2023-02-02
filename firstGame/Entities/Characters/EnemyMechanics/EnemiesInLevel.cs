using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters.EnemyMechanics
{
    internal class EnemiesInLevel
    {
        List<Enemy> respawningEnemies = new List<Enemy>();

        public EnemiesInLevel(List<Enemy> levelEnemies)
        {
            foreach(Enemy enemy in levelEnemies)
            {
                respawningEnemies.Add(enemy);
            }
        }

        public List<Enemy> GetEnemies()
        {
            return respawningEnemies;
        }

       
    }
}
