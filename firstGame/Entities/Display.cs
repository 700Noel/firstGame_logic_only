using firstgame.Entities.World;
using firstgame.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities
{
    internal class Display
    {

        public void Draw(Map map)
        {
            for (int y = 0; y < map.currentLevel.size.y; y++)
            {
                for (int x = 0; x < map.currentLevel.size.x; x++)
                {
                    PositionState currentState = map.currentLevel.GetPosition(y, x).State;
                    Console.Write(currentState.AsString());
                }
                Console.WriteLine();
            }

        }
    }

    public class PositionUI
    {
        Dictionary<PositionState, string> UI = new Dictionary<PositionState, string>();

        public PositionUI(Dictionary<PositionState, string> uI)
        {
            UI = uI;
        }

        public string getUI(PositionState positionState)
        {
            return UI[positionState];
        }
    }
}
