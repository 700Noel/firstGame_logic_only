using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities
{
    internal class GameScreens
    {
        public void ComandScreen()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine();
            Console.WriteLine("Press UpKey, DownKey, LeftKey, RightKey to Move");
            Console.WriteLine();
            Console.WriteLine("Press C to Change direction without Moving");
            Console.WriteLine();
            Console.WriteLine("Press B to skip a move");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
