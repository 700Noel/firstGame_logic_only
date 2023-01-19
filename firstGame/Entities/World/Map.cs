using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World
{
    internal class Map
    {
        public Vector2 playerPosition { get; private set; }

        public Level currentLevel { get; private set; }
        private int levelID = 0;

        public List<Level> levels { get; private set; } = new List<Level>();

        public Map(List<Level> levels)
        {
            this.levels = levels;
            currentLevel = levels[0];
        }

        public void setCurrentLevel(int next)
        {
            levelID += next;
            currentLevel = levels[levelID];
        }
    }
}
