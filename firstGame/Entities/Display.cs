using firstgame.Entities.Characters;
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
        PositionState currentState;

        public void Draw(Map map, Player player)
        {
            Console.Clear();
            map.currentLevel.SetPlayerData(player);
            map.currentLevel.GiveMap(map);

            for (int y = 0; y < map.currentLevel.size.y; y++)
            {
                for (int x = 0; x < map.currentLevel.size.x; x++)
                {
                    if (y == player.getY() && x == player.getX())
                    {
                        currentState = PositionState.Player;
                    }
                    else
                    {
                        currentState = map.currentLevel.GetPosition(y, x).State;
                    }
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
