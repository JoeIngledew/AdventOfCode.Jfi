namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;

    public class BreadthFirstSearch
    {
        public int[] edgeTo;
        public int[] distTo;
        public int s;

        public BreadthFirstSearch(GraphAdjList G, int s)
        {
            edgeTo = new int[G.VertexCount];
            distTo = new int[G.VertexCount];

            for (int i = 0; i < G.VertexCount; i++)
            {
                distTo[i] = -1;
                edgeTo[i] = -1;
            }

            this.s = s;

            BFS(G, s);
        }

        void BFS(GraphAdjList G, int s)
        {
            var queue = new Queue<int>();
            queue.Enqueue(s);
            distTo[s] = 0;

            while (queue.Count != 0)
            {
                int v = queue.Dequeue();

                foreach (var w in G.GetAdj(v))
                {
                    if (distTo[w] == -1)
                    {
                        queue.Enqueue(w);
                        distTo[w] = distTo[v] + 1;
                        edgeTo[w] = v;
                    }
                }
            }
        }
    }

    public class GraphAdjList
    {
        private readonly int V;

        private readonly List<int>[] Adj;

        public GraphAdjList(int v)
        {
            V = v;
            Adj = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                Adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            Adj[v].Add(w);
            Adj[w].Add(v);
        }

        public List<int> GetAdj(int v)
        {
            return Adj[v];
        }

        public int VertexCount => V;
    }

    public class IGiveUp
    {
        const string downCommand = "DOWN";
        const string upCommand = "UP";
        const string elevator = "EE";
        const string strontiumGenerator = "SG"; //
        const string strontiumMicrochip = "SM"; //
        const string plutoniumGenerator = "PG"; //
        const string plutoniumMicrochip = "PM"; //
        const string thuliumGenerator = "TG"; //
        const string thuliumMicrochip = "TM"; //
        const string rutheniumGenerator = "RG"; //
        const string rutheniumMicrochip = "RM"; //
        const string promethiumGenerator = "QG";// 
        const string promethiumMicrochip = "QM"; //
        const string empty = "--";
        public static List<List<string>> building;
        public static int currentFloor = 0;
        public static int totalMoves = 0;
        public static Cargo[] cargoList = new Cargo[10];

        internal static void Run()
        {
            building = new List<List<string>>();
            for (int index = 0; index < 4; index++)
            {
                building.Add(new List<string>());
                for (int stringIndex = 0; stringIndex < 15; stringIndex++)
                {
                    building[index].Add(empty);
                }
            }
            building[0][0] = elevator;
            cargoList[4] = new Cargo(thuliumGenerator, 0); //
            cargoList[5] = new Cargo(thuliumMicrochip, 0); //
            cargoList[0] = new Cargo(strontiumGenerator, 0); //
            cargoList[2] = new Cargo(plutoniumGenerator, 0); //

            cargoList[1] = new Cargo(strontiumMicrochip, 1); // 
            cargoList[3] = new Cargo(plutoniumMicrochip, 1); //
            
            cargoList[6] = new Cargo(rutheniumGenerator, 2); //
            cargoList[7] = new Cargo(rutheniumMicrochip, 2); //
            cargoList[8] = new Cargo(promethiumGenerator, 2); //
            cargoList[9] = new Cargo(promethiumMicrochip, 2); //

            while (true)
            {
                Draw();
                string command = Console.ReadLine().ToUpper();
                if (command == upCommand || command == downCommand)
                {
                    Console.Write("Cargo One: ");
                    Cargo cargoOne = Cargo.Find(Console.ReadLine());
                    Console.Write("Cargo Two: ");
                    Cargo cargoTwo = Cargo.Find(Console.ReadLine());
                    if ((cargoOne == null || cargoOne.myFloor == currentFloor) && (cargoTwo == null || cargoTwo.myFloor == currentFloor))
                    {
                        MoveCargo(cargoOne, cargoTwo, command);
                    }
                }
                else if (command == "-")
                {
                    totalMoves--;
                }
                else if (command == "+")
                {
                    totalMoves++;
                }
            }
        }

        private static void Draw()
        {
            Console.Clear();
            Console.WriteLine("I HATE THIS PUZZLE");
            Console.WriteLine();
            for (int index = 3; index >= 0; index--)
            {
                Console.Write("F" + index + " ");
                for (int stringIndex = 0; stringIndex < 15; stringIndex++)
                {
                    if (stringIndex < 14)
                    {
                        Console.Write(building[index][stringIndex] + " ");
                    }
                    else
                    {
                        Console.WriteLine(building[index][stringIndex]);
                    }
                }
            }
            Console.WriteLine("Moves: " + totalMoves);
        }

        private static void MoveCargo(Cargo cargoOne, Cargo cargoTwo, string command)
        {
            if (command.Equals(upCommand))
            {
                if (currentFloor < 3 && (cargoOne != null || cargoTwo != null))
                {
                    if (cargoOne != null)
                    {
                        cargoOne.MoveUp();
                    }

                    if (cargoTwo != null)
                    {
                        cargoTwo.MoveUp();
                    }

                    building[currentFloor][0] = empty;
                    currentFloor++;
                    building[currentFloor][0] = elevator;
                    totalMoves++;
                }
            }
            else
            {
                if (currentFloor > 0 && (cargoOne != null || cargoTwo != null))
                {
                    if (cargoOne != null)
                    {
                        cargoOne.MoveDown();
                    }

                    if (cargoTwo != null)
                    {
                        cargoTwo.MoveDown();
                    }

                    building[currentFloor][0] = empty;
                    currentFloor--;
                    building[currentFloor][0] = elevator;
                    totalMoves++;
                }
            }
        }

        public class Cargo
        {
            static int lastSlot = 0;
            public int mySlot;
            public int myFloor;
            public string myID;

            public Cargo(string id, int floor)
            {
                myID = id;
                myFloor = floor;
                lastSlot++;
                mySlot = lastSlot;
                building[myFloor][mySlot] = myID;
            }

            public void MoveDown()
            {
                building[myFloor][mySlot] = empty;
                myFloor--;
                building[myFloor][mySlot] = myID;
            }

            public void MoveUp()
            {
                building[myFloor][mySlot] = empty;
                myFloor++;
                building[myFloor][mySlot] = myID;
            }

            public static Cargo Find(string id)
            {
                foreach (Cargo cargo in cargoList)
                {
                    if (cargo.myID.ToUpper() == id.ToUpper())
                    {
                        return cargo;
                    }
                }
                return null;
            }
        }
    }
}