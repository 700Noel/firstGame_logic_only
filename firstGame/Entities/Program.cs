using firstgame.Extensions;
using firstgame.Entities.LevelCreation;
using firstgame.Entities.World;
using firstgame.Entities.Enums;
using firstgame.Entities.World.MapCreation;
using firstgame.Entities.Characters;

namespace firstgame.Entities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 13);
            Display display = new Display();
            Map map = new MapCreator().GetMap();

            Console.Write("Write your name: ");
            string name = Console.ReadLine();

            Player player = new Player(name, 100, new Position(new Vector2(3,3), 1), 0);

            while (true)
            {

                display.Draw(map, player);
                Console.WriteLine();

                var key = Console.ReadKey(true);
                switch (key.Key) {
                    case ConsoleKey.UpArrow:
                        map.currentLevel.Move(Direction.Up); break; 
                    case ConsoleKey.DownArrow:
                        map.currentLevel.Move(Direction.Down); break;
                    case ConsoleKey.LeftArrow:
                        map.currentLevel.Move(Direction.Left); break;
                    case ConsoleKey.RightArrow:
                        map.currentLevel.Move(Direction.Right); break;
                    case ConsoleKey.Spacebar:
                        player.Combat(map.currentLevel); break;
                    case ConsoleKey.C:
                        player.TestWeapon(); break;
                }
            }
        }
    }
}