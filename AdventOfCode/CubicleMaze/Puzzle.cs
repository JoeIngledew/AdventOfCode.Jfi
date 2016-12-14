namespace AdventOfCode.CubicleMaze
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class Puzzle
    {
        public PathFinder PathFinder;

        private int _size;

        private bool[,] _map;

        public void Setup(int size, int favNum)
        {
            _size = size;

            bool[,] map = new bool[size,size];

            foreach (var y in Enumerable.Range(0, size))
            {
                foreach (var x in Enumerable.Range(0, size))
                {
                    map[x, y] = IsTraversible(x, y, favNum);
                }
            }

            _map = map;

            Console.WriteLine("Map: ");
            Console.WriteLine();
            foreach (var y in Enumerable.Range(0, size))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var x in Enumerable.Range(0, size))
                {
                    if (x == 1 && y == 1)
                    {
                        sb.Append("S");
                    }
                    else if (x == 31 && y == 39)
                    {
                        sb.Append("E");
                    }
                    else
                    {
                        sb.Append(map[x, y] ? " " : "#");
                    }
                }
                Console.WriteLine(sb.ToString());
            }

            var searchParams = new SearchParameters(new Point(1, 1), new Point(31, 39), map);
            PathFinder = new PathFinder(searchParams);
        }

        public int GetPathLength()
        {
            var path = PathFinder.FindPath();

            if (path.Count != 0)
            {
                // write path
                Console.WriteLine("Solved Map: ");
                Console.WriteLine();
                foreach (var y in Enumerable.Range(0, _size))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var x in Enumerable.Range(0, _size))
                    {
                        //if (x == 1 && y == 1)
                        //{
                        //    sb.Append("S");
                        //}
                        //else if (x == 31 && y == 39)
                        //{
                        //    sb.Append("E");
                        //}
                        if (path.Any(p => p.X == x && p.Y == y))
                        {
                            sb.Append("O");
                        }
                        else
                        {
                            sb.Append(_map[x, y] ? " " : "#");
                        }
                    }
                    Console.WriteLine(sb.ToString());
                }
            }

            return path.Count;
        }

        public bool IsTraversible(int x, int y, int favNum)
        {
            // x^2 + 3x + 2xy + y + y^2
            var resultOfPolynomial = x * x + 3 * x + 2 * x * y + y + y * y;

            var resultOfSum = resultOfPolynomial + favNum;//1352;

            var binaryRep = Convert.ToString(resultOfSum, 2).ToCharArray();

            if (binaryRep.Count(c => c == '1') % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public int GetNumberOfLocationsWithinSteps(int maxSteps, int favNum)
        {
            var counter = 0;
            foreach (var y in Enumerable.Range(0, _size))
            {
                foreach (var x in Enumerable.Range(0, _size))
                {
                    if (IsTraversible(x, y, favNum))
                    {
                        var newParams = new SearchParameters(new Point(1,1), new Point(x, y), _map);
                        var newFinder = new PathFinder(newParams);
                        var path = newFinder.FindPath();
                        if (path.Count > 0 && path.Count < 51)
                        {
                            Console.WriteLine($"Point ({x},{y}) is reachable in under 50 steps");
                            counter++;
                        }
                    }
                }
            }

            return counter;
        }
    }
}
