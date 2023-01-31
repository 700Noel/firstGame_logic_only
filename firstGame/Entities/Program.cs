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

            OnPlayerAction onPlayerAction = new OnPlayerAction();

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
                        map.currentLevel.Move(Direction.Up);
                        onPlayerAction.EnemiesMove(player, map.currentLevel); break;
                    case ConsoleKey.DownArrow:
                        map.currentLevel.Move(Direction.Down);
                        onPlayerAction.EnemiesMove(player, map.currentLevel); break;
                    case ConsoleKey.LeftArrow:
                        map.currentLevel.Move(Direction.Left);
                        onPlayerAction.EnemiesMove(player, map.currentLevel); break;
                    case ConsoleKey.RightArrow:
                        map.currentLevel.Move(Direction.Right);
                        onPlayerAction.EnemiesMove(player, map.currentLevel); break;
                    case ConsoleKey.Spacebar:
                        player.Combat(map.currentLevel);
                        onPlayerAction.EnemiesMove(player, map.currentLevel); break;
                    case ConsoleKey.V:
                        key = Console.ReadKey(true);
                        player.ChangeDirection(key.Key); break;

                    /*case ConsoleKey.C:
                        player.TestWeapon(); break;*/

                        //Step ?. Enemy movement überarbeiten
                        //Step 1. Enemy Attack
                        //Step 2. Enemy spawn each time, when Enemy enters
                        //Step 3. Enemy drop Health
                        //Step 4. New Enemy Races
                        //Step 5. friendly NPCs
                        //Step 6. talk to NPCs
                        //Step 7. Game Start Text
                }
            }
        }
    }
}