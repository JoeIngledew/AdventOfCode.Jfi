namespace AdventOfCode.CubicleMaze
{
    using System;
    using System.Drawing;

    public class Node
    {
        private Node _parentNode;

        public Point Location { get; private set; }

        public bool IsWalkable { get; set; }

        // Cost from start to this node
        public float G { get; private set; }

        // estimate cost from here to end
        public float H { get; private set; }

        public NodeState State { get; set; }

        public float F => G + H;

        public Node ParentNode
        {
            get
            {
                return _parentNode;
            }
            set
            {
                _parentNode = value;
                G = _parentNode.G + GetTraversalCost(Location, _parentNode.Location);
            }
        }

        public Node(int x, int y, bool isWalkable, Point endLocation)
        {
            Location = new Point(x, y);
            State = NodeState.Untested;
            IsWalkable = isWalkable;
            H = GetTraversalCost(Location, endLocation);
            G = 0;
        }

        public override string ToString()
        {
            return $"{Location.X}, {Location.Y}: {State}";
        }

        internal static float GetTraversalCost(Point location, Point otherLocation)
        {
            float deltaX = otherLocation.X - location.X;
            float deltaY = otherLocation.Y - location.Y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}