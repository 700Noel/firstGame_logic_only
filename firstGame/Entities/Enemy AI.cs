using firstgame.Entities.Enums;
using firstgame.Entities.World;

namespace firstgame.Entities
{
    internal class Enemy_AI
    {
        private bool playerInRange;
        private bool unreachable;
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
            this.playerInRange = false;
            this.unreachable = false;
            openList.Clear();
            closedList.Clear();
            path.Clear();


            this.currentlevel = level;
            this.playerPosition = playerPosition;
            startingPoint = enemyPosition.vector2;
            parent = new Node(null, enemyPosition, playerPosition);
            openList.Add(parent);

            AddAdjecentNodes();

            openList.Remove(parent);
            closedList.Add(parent);

            while (!playerInRange && !unreachable)
            {


                foreach (Node node in openList)
                {
                    if (node.getF() > bestPath)
                    {
                        parent = node;
                        bestPath = node.getF();
                    }
                }
                bestPath = 0;

                if (!ClosedListContains(parent.getPosition()))
                {
                    openList.Remove(parent);
                    closedList.Add(parent);
                }

                AddAdjecentNodes();

                if (openList.Count() == 0 && !playerInRange)
                {
                    unreachable = true;
                    path.Clear();
                    return path;
                }
            }
            while (parent.getPosition() != enemyPosition)
            {
                path.Add(parent.getPosition());
                parent = parent.getParent();
            }

            return path;
        }

        private void AddAdjecentNodes()
        {
            if (parent.getVector2().x + 1 < 12 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(parent.getVector2().x + 1, parent.getVector2().y), playerPosition);
                if (!OpenListContains(adjacentNode.getPosition()) && !ClosedListContains(adjacentNode.getPosition()))
                {
                    openList.Add(adjacentNode);
                }
            }


            if (parent.getVector2().x - 1 >= 0 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(parent.getVector2().x - 1, parent.getVector2().y), playerPosition);
                if (!OpenListContains(adjacentNode.getPosition()) && !ClosedListContains(adjacentNode.getPosition()))
                {
                    openList.Add(adjacentNode);
                }
            }

            if (parent.getVector2().y + 1 < 8 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(parent.getVector2().x, parent.getVector2().y + 1), playerPosition);
                if (!OpenListContains(adjacentNode.getPosition()) && !ClosedListContains(adjacentNode.getPosition()))
                {
                    openList.Add(adjacentNode);
                }
            }

            if (parent.getVector2().y - 1 >= 0 && CheckFreeSpot(currentlevel, parent.getVector2(), playerPosition.vector2))
            {
                adjacentNode = new Node(parent, currentlevel.GetPosition(parent.getVector2().x - 1, parent.getVector2().y), playerPosition);
                if (!OpenListContains(adjacentNode.getPosition()) && !ClosedListContains(adjacentNode.getPosition()))
                {
                    openList.Add(adjacentNode);
                }
            }
        }

        private bool ClosedListContains(Position position)
        {
            foreach (Node node in closedList)
            {
                if (node.getPosition().vector2.y == position.vector2.y && node.getPosition().vector2.x == position.vector2.x)
                {
                    return true;
                }
            }
            return false;
        }


        private bool OpenListContains(Position position)
        {
            foreach (Node node in openList)
            {
                if (node.getPosition().vector2.y == position.vector2.y && node.getPosition().vector2.x == position.vector2.x)
                {
                    return true;
                }
            }
            return false;
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
