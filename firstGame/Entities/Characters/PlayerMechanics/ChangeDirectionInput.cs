using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters.PlayerMechanics
{
    internal class ChangeDirectionInput
    {
        public void Input(ConsoleKey consoleKey, Player player)
        {
            switch (consoleKey) {
                case ConsoleKey.UpArrow:
                    player.SetDirection(Direction.Up);
                    break;
                    case ConsoleKey.DownArrow:
                    player.SetDirection(Direction.Down);
                    break;
                    case ConsoleKey.LeftArrow:
                    player.SetDirection(Direction.Left);
                    break;
                    case ConsoleKey.RightArrow:
                    player.SetDirection(Direction.Right);
                    break;
                default:
                    break;

            }
        }
    }
}
