using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.World
{
    internal class Node
    {
        private Node parent;
        private Position position;
        private Vector2 vector2;
        private int startingPointToThis;
        private int costThisToDestination;

        public Node(Node parent, Position position, Position destination)
        {
            this.parent = parent;
            this.position = position;
            this.vector2 = position.vector2;
            this.costThisToDestination = Math.Abs(position.vector2.x - destination.vector2.x) + Math.Abs(position.vector2.y - destination.vector2.y);
            if(parent!= null)
            {
                startingPointToThis = parent.getG() + 1;
            }
            else
            {
                startingPointToThis = 0;
            }
            

        }

        public int getH() { return costThisToDestination; }

        public int getG() { return startingPointToThis; }

        public int getF() { return costThisToDestination + startingPointToThis; }

        public int giveGToChild() { return costThisToDestination; }

        public Node getParent() { return parent; }

        public Position getPosition() { return position; }

        public Vector2 getVector2() { return vector2;}



    }
}
