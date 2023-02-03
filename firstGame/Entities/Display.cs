﻿using firstgame.Entities.Characters;
using firstgame.Entities.World;
using firstgame.Extensions;
using firstgame.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            map.currentLevel.SetMap(map);



            for (int y = 0; y < map.currentLevel.size.y; y++)
            {
                for (int x = 0; x < map.currentLevel.size.x; x++)
                {
                    if (y == player.getY() && x == player.getX())
                    {
                        currentState = PositionState.Player;
                    } else if(map.currentLevel.CheckEnemyPosition(x,y)) {
                        currentState = PositionState.Enemy;
                    } else if(map.currentLevel.CheckItemPosition(x,y))
                    {
                        currentState = PositionState.Weapon;
                    } else if (map.currentLevel.CheckHealthPosition(x,y))
                    {
                        currentState = PositionState.Health;
                    }
                    else
                    {
                        currentState = map.currentLevel.GetPosition(y, x).State;
                    }
                    Console.Write(currentState.AsString());
                }
                Statistics(y, map, player);
                Console.WriteLine();
            }

        }

        private void Statistics(int y, Map map, Player player)
        {
            switch (y)
            {
                case 0:
                    Console.Write("    Player Name: " + player.name.ToString());
                    for (int i = player.name.Length; i < 11; i++)
                    {
                        Console.Write(" ");
                    }
                    break;
                case 1:
                    Console.Write("    Player Health: " + player.health.ToString());
                    for (int i = player.health.ToString().Length; i < 9; i++)
                    {
                        Console.Write(" ");
                    }
                    break;
                case 2:
                    Console.Write("    Player Weapon: " + player.weapon.ToString());
                    for (int i = player.weapon.ToString().Length; i < 9; i++)
                    {
                        Console.Write(" ");
                    }
                    break;
                case 3:
                    Console.Write("    Player Direction: " + player.direction.ToString());
                    for (int i = player.direction.ToString().Length; i < 6; i++)
                    {
                        Console.Write(" ");
                    }
                    break;
                case 4:
                    Console.Write("");
                        break;
            }

            if(y < 4 && map.currentLevel.Enemies().Count != 0 && y < map.currentLevel.Enemies().Count())
            {
                Console.Write("    " + map.currentLevel.Enemies()[y].race + " Health: " + map.currentLevel.Enemies()[y].health.ToString());
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
