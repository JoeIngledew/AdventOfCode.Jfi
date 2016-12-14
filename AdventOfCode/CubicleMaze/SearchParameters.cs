namespace AdventOfCode.CubicleMaze
{
    using System.Drawing;

    public class SearchParameters
    {
        public Point StartLocation { get; set; }

        public Point EndLocation { get; set; }

        public bool[,] Map { get; set; }

        public SearchParameters(Point start, Point end, bool[,] map)
        {
            StartLocation = start;
            EndLocation = end;
            Map = map;
        }
    }
}