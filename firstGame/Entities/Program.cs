using firstgame.Extensions;
using firstgame.Entities.LevelCreation;
using firstgame.Entities.World;
using firstgame.Entities.Enums;
using firstgame.Entities.World.MapCreation;

namespace firstgame.Entities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();
            Map map = new MapCreator().GetMap();

            //map.currentLevel.positions[1, 0].State = PositionStateExtension.GetFromNumber(3);

            display.Draw(map);
            Console.WriteLine();
            map.setCurrentLevel();
            display.Draw(map);
            Console.WriteLine();

            /*while (true)
            {
                display.Draw(map);
                Console.WriteLine();


            }*/
        }
    }
}