using firstgame.Entities.Characters;
using firstgame.Entities.Enums;
using firstgame.Entities.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities
{
    internal class Enemy_AI
    {
        bool playerInRange;
        private Level currentlevel;
        private Position playerPosition;

        private List<Node> openList = new List<Node>();
        private List<Node> closedList = new List<Node>();
        private Vector2 startingPoint;

        private Node parent;
        private Node adjacentNode;
        private int bestPath = 0;

        private List<Position> path = new List<Position>();

        public List<Position> generatePath(Position enemyPosition, Position playerPosition, Level level)
        {
            this.currentlevel = level;
            this.playerPosition = playerPosition;
            startingPoint = enemyPosition.vector2;
            parent = new Node(null, enemyPosition, playerPosition);
            openList.Add(parent);

            AddAdjecentNodes();

            openList.Remove(parent);
            closedList.Add(parent);

            while (!playerInRange) {

                foreach (Node node in openList)
                {
                    if (node.getF() > bestPath)
                    {
                        parent = node;
                        bestPath = node.getF();
                    }
                }
                bestPath = 0;

                openList.Remove(parent);
                closedList.Add(parent);
                AddAdjecentNodes();
            }
            while (parent.getPosition() != enemyPosition) {
                path.Add(parent.getPosition());
                parent = parent.getParent();
            }

            return path;
        }

        private void AddAdjecentNodes()
        {
            if (startingPoint.x + 1 < 12 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(startingPoint.x + 1, startingPoint.y), playerPosition);
                if (!openList.Contains(adjacentNode))
                {
                    openList.Add(adjacentNode);
                }
            }

            
            if (startingPoint.x - 1 >= 0 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2) && !openList.Contains(adjacentNode))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(startingPoint.x - 1, startingPoint.y), playerPosition);
                if (!openList.Contains(adjacentNode))
                {
                    openList.Add(adjacentNode);
                }
            }

            if (startingPoint.y + 1 < 8 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(startingPoint.x, startingPoint.y + 1), playerPosition);
                if (!openList.Contains(adjacentNode))
                {
                    openList.Add(adjacentNode);
                }
            }

            if (startingPoint.y - 1 >= 0 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(startingPoint.x - 1, startingPoint.y), playerPosition);
                if (!openList.Contains(adjacentNode))
                {
                    openList.Add(adjacentNode);
                }
            }
        }

        private bool CheckFreeSpot(Level level, Vector2 enemy, Vector2 player)
        {
            PositionState newPosition = level.positions[enemy.x, enemy.y].State;
            if (newPosition == PositionState.Obstacle || newPosition == PositionState.Path)
            {
                return false;
            }
            else if (enemy.x == player.x && enemy.y == player.y)
            {
                playerInRange = true;
                return false;
            }
            return true;
        }

    }
}
