namespace AdventOfCode.Day182015
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class AnimatedLights
    {
        public List<AnimatedLightPoint> Lights;

        public void Setup(string input)
        {
            var sanitizedInputLines = input.Replace("\r", "").Split('\n');
            Lights = new List<AnimatedLightPoint>();

            for (var y = 0; y < 100; y++)
            {
                for (var x = 0; x < 100; x++)
                {
                    var isLit = sanitizedInputLines[y][x] == '#';
                    Lights.Add(new AnimatedLightPoint(new Point(x, y), isLit));
                }
            }
        }

        public int Part2(int numIterations)
        {
            Lights.Single(l => l.Location.LocationEqual(new Point(0, 0))).IsLit = true;
            Lights.Single(l => l.Location.LocationEqual(new Point(0, 99))).IsLit = true;
            Lights.Single(l => l.Location.LocationEqual(new Point(99, 0))).IsLit = true;
            Lights.Single(l => l.Location.LocationEqual(new Point(99, 99))).IsLit = true;

            List<AnimatedLightPoint> transformedList = new List<AnimatedLightPoint>();
            for (var i = 0; i < numIterations; i++)
            {
                foreach (var j in Enumerable.Range(0, Lights.Count))
                {
                    if (!Lights[j].Location.LocationEqual(new Point(0,0))
                        && !Lights[j].Location.LocationEqual(new Point(0, 99))
                        && !Lights[j].Location.LocationEqual(new Point(99, 0))
                        && !Lights[j].Location.LocationEqual(new Point(99, 99)))
                    { 
                        int litNeighbors = Lights[j].GetNumberOfLitNeighbors(Lights);
                        if (Lights[j].IsLit)
                        {
                            if (litNeighbors == 2 || litNeighbors == 3)
                            {
                                transformedList.Add(new AnimatedLightPoint(Lights[j].Location, true));
                            }
                            else
                            {
                                transformedList.Add(new AnimatedLightPoint(Lights[j].Location, false));
                            }
                        }
                        else
                        {
                            transformedList.Add(
                                litNeighbors == 3
                                    ? new AnimatedLightPoint(Lights[j].Location, true)
                                    : new AnimatedLightPoint(Lights[j].Location, false));
                        }
                    }
                }

                transformedList.Add(new AnimatedLightPoint(new Point(0, 0), true));
                transformedList.Add(new AnimatedLightPoint(new Point(99, 0), true));
                transformedList.Add(new AnimatedLightPoint(new Point(0, 99), true));
                transformedList.Add(new AnimatedLightPoint(new Point(99, 99), true));

                Lights = new List<AnimatedLightPoint>(transformedList);
                transformedList.Clear();
                Console.WriteLine($"At iteration {i}, {Lights.Count(l => l.IsLit)} lit");
            }

            return Lights.Count(l => l.IsLit);
        }

        public int GetLitAfterIterations(int numIterations)
        {
            List<AnimatedLightPoint> transformedList = new List<AnimatedLightPoint>();
            for (var i = 0; i < numIterations; i++)
            {
                foreach (var j in Enumerable.Range(0, Lights.Count))
                {
                    int litNeighbors = Lights[j].GetNumberOfLitNeighbors(Lights);
                    if (Lights[j].IsLit)
                    {
                        if (litNeighbors == 2 || litNeighbors == 3)
                        {
                            transformedList.Add(new AnimatedLightPoint(Lights[j].Location, true));
                        }
                        else
                        {
                            transformedList.Add(new AnimatedLightPoint(Lights[j].Location, false));
                        }
                    }
                    else
                    {
                        transformedList.Add(
                            litNeighbors == 3
                                ? new AnimatedLightPoint(Lights[j].Location, true)
                                : new AnimatedLightPoint(Lights[j].Location, false));
                    }
                }
                Lights = new List<AnimatedLightPoint>(transformedList);
                transformedList.Clear();
                Console.WriteLine($"At iteration {i}, {Lights.Count(l => l.IsLit)} lit");
            }

            return Lights.Count(l => l.IsLit);
        }
    }

    public class AnimatedLightPoint
    {
        public AnimatedLightPoint(Point location, bool isInitiallyLit)
        {
            Location = location;
            IsLit = isInitiallyLit;
        }

        public Point Location { get; }

        public bool IsLit { get; set; }
    }

    public static class Extensions
    {
        public static List<Point> GetNeighborPoints(this AnimatedLightPoint light)
        {
            List<Point> neighbors = new List<Point>
            {
                new Point(light.Location.X - 1, light.Location.Y - 1),
                new Point(light.Location.X - 1, light.Location.Y),
                new Point(light.Location.X - 1, light.Location.Y + 1),
                new Point(light.Location.X, light.Location.Y - 1),
                new Point(light.Location.X, light.Location.Y + 1),
                new Point(light.Location.X + 1, light.Location.Y - 1),
                new Point(light.Location.X + 1, light.Location.Y),
                new Point(light.Location.X + 1, light.Location.Y + 1),
            };

            return neighbors.Where(n => n.X != -1 && n.X != 100 && n.Y != -1 && n.Y != 100).ToList();
        }

        public static bool LocationEqual(this Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static int GetNumberOfLitNeighbors(this AnimatedLightPoint light, List<AnimatedLightPoint> allLights)
        {
            var neighbors = light.GetNeighborPoints();
            return allLights.Count(l => neighbors.Any(p => p.LocationEqual(l.Location)) && l.IsLit);
        }
    }
}