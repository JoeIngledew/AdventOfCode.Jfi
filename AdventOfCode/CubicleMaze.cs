//namespace AdventOfCode
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Drawing;
//
//    public class CubicleMaze
//    {
//        // startLocation is 0,0
//        public int GetMinimumStepsToPoint(int x, int y)
//        {
//            int startX = 0;
//            int startY = 0;
//        }
//
//        public List<CubePoint> CreatePoints()
//        {
//            return (from i in Enumerable.Range(0, 40) from j in Enumerable.Range(0, 40) select new CubePoint(i, j)).ToList();
//        }
//    }
//
//    public class SearchParameters
//    {
//        public Point StartLocation { get; set; }
//        public Point EndLocation { get; set; }
//        public bool[,] Map { get; set; }
//
//        public List<Point> FindPath()
//        {
//            List<Point> path = new List<Point>();
//            bool success = Search(startNode);
//
//            if (success)
//            {
//                Node node = _endNode;
//                while (node.ParentNode != null)
//                {
//                    path.Add(node.Location);
//                    node = node.ParentNode;
//                }
//                path.Reverse();
//            }
//            return path;
//        }
//
//        private bool Search(Node currentNode)
//        {
//            currentNode.State = NodeState.Closed;
//            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);
//            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
//            foreach (var nextNode in nextNodes)
//            {
//                if (nextNode.Location == _endNode.Location)
//                {
//                    return true;
//                }
//                else
//                {
//                    if (Search(nextNode)) return true;
//                }
//            }
//            return false;
//        }
//
//        private List<Node> GetAdjacentWalkableNodes(Node fromNode)
//        {
//            List<Node> walkableNodes = new List<Node>();
//            IEnumerable<Point> nextLocations = GetAdjacentLocations(fromNode.Location);
//
//            foreach (var location in nextLocations)
//            {
//                int x = location.X;
//                int y = location.Y;
//
//                if (x < 0 || x >= _width || y < 0 || y >= _height)
//                    continue;
//
//                Node node = _nodes[x, y];
//
//                if (!node.IsWalkable) continue;
//
//                if (node.State == NodeState.Closed)
//                    continue;
//
//                if (node.State == NodeState.Open)
//                {
//                    float traversalCost = Node.GetTraversalCost(node.Location, node.ParentNode.Location);
//                    float gTemp = fromNode.G + traversalCost;
//                    if (gTemp < node.G)
//                    {
//                        node.ParentNode = fromNode;
//                        walkableNodes.Add(node);
//                    }
//                }
//                else
//                {
//                    node.ParentNode = fromNode;
//                    node.State = NodeState.Open;
//                    walkableNodes.Add(node);
//                }
//            }
//
//            return walkableNodes;
//        }
//    }
//
//    public class Node
//    {
//        public Point Location { get; private set; }
//        public bool IsWalkable { get; set; }
//        public float G { get; private set; }
//        public float H { get; private set; }
//        public float F { get; private set; }
//        public NodeState State { get; set; }
//
//        public Node ParentNode
//        {
//            get
//            {
//
//            }
//            set
//            {
//
//            }
//        }
//    }
//
//    public enum NodeState
//    {
//        Untested,
//        Open,
//        Closed
//    }
//
//    public class CubePoint
//    {
//        public CubePoint(int xCoord, int yCoord)
//        {
//            YCoord = yCoord;
//            XCoord = xCoord;
//        }
//
//        public int XCoord { get; }
//
//        public int YCoord { get; }
//
//        public bool IsTraversible()
//        {
//            // x^2 + 3x + 2xy + y + y^2
//            var resultOfPolynomial = (XCoord * XCoord) + (3 * XCoord) + (2 * XCoord * YCoord) + YCoord
//                                     + (YCoord * YCoord);
//
//            var binaryRep = Convert.ToString(resultOfPolynomial, 2);
//
//            return binaryRep.Count(c => c == '1') % 2 == 0;
//        }
//    }
//}