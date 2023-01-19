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
            Display display = new Display();
            Map map = new MapCreator().GetMap();



            Console.Write("Write your name: ");
            string name = Console.ReadLine();


            

            Player player = new Player(name, 100, new Position(new Vector2(3,3), 1));


            //map.currentLevel.positions[1, 0].State = PositionStateExtension.GetFromNumber(3);

            /*display.Draw(map, player.position);
            Console.WriteLine();
            map.setCurrentLevel();
            display.Draw(map, player.position);
            Console.WriteLine();*/

            while (true)
            {

                display.Draw(map, player);
                Console.WriteLine();

                var key = Console.ReadKey(true);
                switch (key.Key) {
                    case ConsoleKey.UpArrow:
                        map.currentLevel.MovePlayer(Direction.Up); break; 
                    case ConsoleKey.DownArrow:
                        map.currentLevel.MovePlayer(Direction.Down); break;
                    case ConsoleKey.LeftArrow:
                        map.currentLevel.MovePlayer(Direction.Left); break;
                    case ConsoleKey.RightArrow:
                        map.currentLevel.MovePlayer(Direction.Right); break;
                    /*case ConsoleKey.Spacebar:
                        player.Attack();
                        break;*/

                }

                


            }
        }
    }
}