namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RadioIsotopeThermoElectricGenerators
    {
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        public static void Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, verticesCount);
        }


        // impl
        public List<List<IThing>> Floors = new List<List<IThing>>();

        public void SetupFloors()
        {
            
        }

        public bool IsMoveValid(List<List<IThing>> floors)
        {
            bool isValid = true;
            foreach (var floor in floors)
            {
                foreach (IThing thing in floor)
                {
                    if (thing.IsChip())
                    {
                        if (!floor.Any(t => t.IsGenerator()))
                        {
                            
                        }

                        if (floor.Where(t => t.IsGenerator()).Any(t => t.GetCategory() == thing.GetCategory()))
                        {
                            
                        }

                        isValid = false;
                    }
                }
            }

            return isValid;
        }
    }

    public interface IThing
    {
        bool IsGenerator();

        bool IsChip();

        string GetCategory();
    }

    public class Generator : IThing
    {
        private readonly string _cat;

        public Generator(string cat)
        {
            _cat = cat;
        }

        public bool IsGenerator()
        {
            return true;
        }

        public bool IsChip()
        {
            return false;
        }

        public string GetCategory()
        {
            return _cat;
        }
    }

    public class Chip : IThing
    {
        private readonly string _cat;

        public Chip(string cat)
        {
            _cat = cat;
        }

        public bool IsGenerator()
        {
            return false;
        }

        public bool IsChip()
        {
            return true;
        }

        public string GetCategory()
        {
            return _cat;
        }
    }

}