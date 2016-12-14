namespace AdventOfCode.CubicleMaze
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Drawing;
    using System.Linq;
    using System.Net.Http.Headers;

    using MoreLinq;

    public class PathFinder
    {
        private int _width;

        private int _height;

        public Node[,] Nodes;

        private Node _startNode;

        private Node _endNode;

        public SearchParameters SearchParameters;

        public PathFinder(SearchParameters searchParameters)
        {
            SearchParameters = searchParameters;
            InitialiseNodes(searchParameters.Map);
            _startNode = Nodes[searchParameters.StartLocation.X, searchParameters.StartLocation.Y];
            _startNode.State = NodeState.Open;
            _endNode = Nodes[searchParameters.EndLocation.X, searchParameters.EndLocation.Y];
        }

        public List<Point> FindPath()
        {
            List<Point> path = new List<Point>();
            bool success = Search(_startNode);
            if (success)
            {
                Node node = _endNode;
                while (node.ParentNode != null)
                {
                    path.Add(node.Location);
                    node = node.ParentNode;
                }

                path.Reverse();
            }

            return path;
        }

        private void InitialiseNodes(bool[,] map)
        {
            _width = map.GetLength(0);
            _height = map.GetLength(1);
            Nodes = new Node[_width,_height];

            foreach (var y in Enumerable.Range(0, _height))
            {
                foreach (var x in Enumerable.Range(0, _width))
                {
                    Nodes[x,y] = new Node(x, y, map[x,y], SearchParameters.EndLocation);
                }
            }
        }

        private bool Search(Node currentNode)
        {
            currentNode.State = NodeState.Closed;
            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);

            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));

            foreach (var nextNode in nextNodes)
            {
                if (nextNode.Location == _endNode.Location)
                {
                    return true;
                }
                if (Search(nextNode)) return true;
            }

            return false;
        }

        private List<Node> GetAdjacentWalkableNodes(Node fromNode)
        {
            List<Node> walkableNodes = new List<Node>();
            IEnumerable<Point> nextLocations = GetAdjacentLocations(fromNode.Location);

            foreach (var location in nextLocations)
            {
                int x = location.X;
                int y = location.Y;

                if (x < 0 || x >= _width || y < 0 || y >= _height)
                    continue;

                Node node = Nodes[x, y];

                if (!node.IsWalkable) continue;

                if (node.State == NodeState.Closed)
                    continue;

                if (node.State == NodeState.Open)
                {
                    float traversalCost = Node.GetTraversalCost(node.Location, node.ParentNode.Location);
                    float gTemp = fromNode.G + traversalCost;
                    if (gTemp < node.G)
                    {
                        node.ParentNode = fromNode;
                        walkableNodes.Add(node);
                    }
                }
                else
                {
                    node.ParentNode = fromNode;
                    node.State = NodeState.Open;
                    walkableNodes.Add(node);
                }
            }

            return walkableNodes;
        }

        private static IEnumerable<Point> GetAdjacentLocations(Point fromLocation)
        {
            return new Point[]
                   {
                       new Point(fromLocation.X - 1, fromLocation.Y),
                       new Point(fromLocation.X, fromLocation.Y + 1),
                       new Point(fromLocation.X + 1, fromLocation.Y),
                       new Point(fromLocation.X, fromLocation.Y - 1)
                   };
        }
    }
}