namespace AdventOfCode.Day18
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class LikeARouge
    {
        private string _firstRow =
            ".^^^.^.^^^^^..^^^..^..^..^^..^.^.^.^^.^^....^.^...^.^^.^^.^^..^^..^.^..^^^.^^...^...^^....^^.^^^^^^^";

        private List<TilePoint> _tileMap;

        public void Setup()
        {
            _tileMap = new List<TilePoint>();

            foreach (var i in Enumerable.Range(0, _firstRow.Length))
            {
                var thisTile = new TilePoint(new Point(i, 0)) { IsSafe = _firstRow[i] == '.' };

                _tileMap.Add(thisTile);
            }

            foreach (var y in Enumerable.Range(1, (400000 - 1)))
            {
                foreach (var x in Enumerable.Range(0, _firstRow.Length))
                {
                    if (y % 1000 == 0)
                    {
                        Console.WriteLine($"Adding row {y}");
                    }

                    _tileMap.Add(new TilePoint(new Point(x, y)) { IsSafe = false});
                }
            }
        }


        public int GetNumberOfSafeTiles()
        {
            foreach(var y in Enumerable.Range(1, (400000 - 1)))
            {
                foreach (var x in Enumerable.Range(0, _firstRow.Length))
                {
                    if (y % 1000 == 0)
                    {
                        Console.WriteLine($"Processing row {y}");
                    }

                    var tileUnderTest = _tileMap.Single(t => t.Location.X == x && t.Location.Y == y);
                    tileUnderTest.IsSafe = IsTileSafe(tileUnderTest.Location);
                }
            }

            return _tileMap.Count(t => t.IsSafe);
        }

        private bool IsTileSafe(Point toTest)
        {
            bool isLeftSafe;
            bool isRightSafe;
            if (toTest.X == 0)
            {
                isLeftSafe = true;
            }
            else
            {
                isLeftSafe =
                    _tileMap.Single(t => t.Location.X == toTest.X - 1 && t.Location.Y == toTest.Y - 1)
                        .IsSafe;
            }
            if (toTest.X == _firstRow.Length - 1)
            {
                isRightSafe = true;
            }
            else
            {
                isRightSafe =
                    _tileMap.Single(t => t.Location.X == toTest.X + 1 && t.Location.Y == toTest.Y - 1)
                        .IsSafe;
            }

            bool isMiddleSafe =
                _tileMap.Single(t => t.Location.X == toTest.X && t.Location.Y == toTest.Y - 1).IsSafe;

            if (!isLeftSafe && !isMiddleSafe && isRightSafe)
            {
                return false;
            }
            if (!isMiddleSafe && !isRightSafe && isLeftSafe)
            {
                return false;
            }
            if (!isLeftSafe && isMiddleSafe && isRightSafe)
            {
                return false;
            }
            if (!isRightSafe && isMiddleSafe && isLeftSafe)
            {
                return false;
            }
            return true;
        }
    }

    public class TilePoint
    {
        public TilePoint(Point location)
        {
            Location = location;
        }

        public Point Location { get; }

        public bool IsSafe { get; set; }
    }
}