using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.LevelCreation
{
    internal class Checker
    {
        public bool TicknessHorizontal(int borderThickness, int position, int WIDTH)
        {
            if (position == WIDTH / 2 - 1 || position == WIDTH / 2)
            {
                return false;
            }

            if (position < borderThickness || position > WIDTH - 1 - borderThickness)
            {
                return true;
            }
            return false;

        }
        public bool SpaceVertical(int borderThickness, int position, int HEIGHT)
        {
            /*if (position == HEIGHT / 2 - 1|| position == HEIGHT / 2)
            {
                return false;
            }*/

            if (position < borderThickness || position > HEIGHT - 1 - borderThickness)
            {
                return true;
            }
            return false;
        }
    }
}
