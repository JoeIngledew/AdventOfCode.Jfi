﻿namespace AdventOfCode
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class TwoFactorAuth
    {
        // first list rows, second list cols.
        private static string[,] matrix = new string[6,50];

        private const string Unlit = " ";

        private const string Lit = "#";

        public TwoFactorAuth(int numRows, int numCols)
        {
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numCols; j++)
                {
                    matrix[i,j] = Unlit;
                }
            }
        }

        public void Generate()
        {
            var instructions = input.Replace("\r", "").Split('\n');

            foreach (var instruction in instructions)
            {
                var splitInstr = instruction.Split(' ');

                if (splitInstr[0] == "rect")
                {
                    var x = int.Parse(splitInstr[1].Split('x')[0]);
                    var y = int.Parse(splitInstr[1].Split('x')[1]);
                    Rect(x, y);
                }
                else
                {
                    var isRow = splitInstr[1] == "row";
                    var index = int.Parse(splitInstr[2].Split('=')[1]);
                    var numTimes = int.Parse(splitInstr[4]);
                    Rotate(isRow, index, numTimes);
                }
                Display();
            }

            Console.ReadLine();
        }

        private void Rotate(bool isRow, int rowOrColIx, int numTimes)
        {
            foreach (var i in Enumerable.Range(0, numTimes))
            {
                RotateOnce(isRow, rowOrColIx);
            }
        }

        private void RotateOnce(bool isRow, int rowOrColIx)
        {
            if (isRow)
            {
                string[] temp = new string[50];
                foreach (var i in Enumerable.Range(0, 50))
                {
                    temp[i] = matrix[rowOrColIx, i];
                }

                foreach (var i in Enumerable.Range(0, 50))
                {
                    int ix;
                    if (i == 0)
                    {
                        ix = 49;
                    }
                    else
                    {
                        ix = i - 1;
                    }
                    matrix[rowOrColIx, i] = temp[ix];
                    //Display();
                }
            }
            else
            {
                string[] temp = new string[6];
                foreach (var i in Enumerable.Range(0, 6))
                {
                    temp[i] = matrix[i, rowOrColIx];
                }

                foreach (var i in Enumerable.Range(0, 6))
                {
                    int ix;
                    if (i == 0)
                    {
                        ix = 5;
                    }
                    else
                    {
                        ix = i - 1;
                    }
                    matrix[i, rowOrColIx] = temp[ix];
                    //Display();
                }
            }
        }

        private void Display()
        {
            var numberIlluminated = 0;
            Console.Clear();
            foreach (var i in Enumerable.Range(0, 6))
            {
                foreach (var j in Enumerable.Range(0, 50))
                {
                    if (matrix[i, j] == Lit)
                    {
                        numberIlluminated++;
                    }
                    Console.Write(matrix[i,j]);
                }
                Console.Write('\n');
            }
            Console.WriteLine($"Number illuminated: {numberIlluminated}");
            Task.Delay(TimeSpan.FromMilliseconds(50)).Wait();
        }

        private void Rect(int x, int y)
        {
            for (var i = 0; i < y; i++)
            {
                for (var j = 0; j < x; j++)
                {
                    matrix[i,j] = Lit;
                    //Display();
                }
            }
        }

        private const string input = @"rect 1x1
rotate row y=0 by 7
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 7
rect 6x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 2
rect 1x2
rotate row y=1 by 10
rotate row y=0 by 3
rotate column x=0 by 1
rect 2x1
rotate column x=20 by 1
rotate column x=15 by 1
rotate column x=5 by 1
rotate row y=1 by 5
rotate row y=0 by 2
rect 1x2
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate row y=2 by 15
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate row y=2 by 5
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate row y=2 by 10
rotate row y=0 by 10
rotate column x=8 by 1
rotate column x=5 by 1
rotate column x=0 by 1
rect 9x1
rotate column x=27 by 1
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate column x=42 by 1
rotate column x=40 by 1
rotate column x=22 by 1
rotate column x=17 by 1
rotate column x=12 by 1
rotate column x=7 by 1
rotate column x=2 by 1
rotate row y=3 by 10
rotate row y=2 by 5
rotate row y=1 by 3
rotate row y=0 by 10
rect 1x4
rotate column x=37 by 2
rotate row y=3 by 18
rotate row y=2 by 30
rotate row y=1 by 7
rotate row y=0 by 2
rotate column x=13 by 3
rotate column x=12 by 1
rotate column x=10 by 1
rotate column x=7 by 1
rotate column x=6 by 3
rotate column x=5 by 1
rotate column x=3 by 3
rotate column x=2 by 1
rotate column x=0 by 1
rect 14x1
rotate column x=38 by 3
rotate row y=3 by 12
rotate row y=2 by 10
rotate row y=0 by 10
rotate column x=7 by 1
rotate column x=5 by 1
rotate column x=2 by 1
rotate column x=0 by 1
rect 9x1
rotate row y=4 by 20
rotate row y=3 by 25
rotate row y=2 by 10
rotate row y=0 by 15
rotate column x=12 by 1
rotate column x=10 by 1
rotate column x=8 by 3
rotate column x=7 by 1
rotate column x=5 by 1
rotate column x=3 by 3
rotate column x=2 by 1
rotate column x=0 by 1
rect 14x1
rotate column x=34 by 1
rotate row y=1 by 45
rotate column x=47 by 1
rotate column x=42 by 1
rotate column x=19 by 1
rotate column x=9 by 2
rotate row y=4 by 7
rotate row y=3 by 20
rotate row y=0 by 7
rotate column x=5 by 1
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=0 by 1
rect 6x1
rotate row y=4 by 8
rotate row y=3 by 5
rotate row y=1 by 5
rotate column x=5 by 1
rotate column x=4 by 1
rotate column x=3 by 2
rotate column x=2 by 1
rotate column x=1 by 3
rotate column x=0 by 1
rect 6x1
rotate column x=36 by 3
rotate column x=25 by 3
rotate column x=18 by 3
rotate column x=11 by 3
rotate column x=3 by 4
rotate row y=4 by 5
rotate row y=3 by 5
rotate row y=2 by 8
rotate row y=1 by 8
rotate row y=0 by 3
rotate column x=3 by 4
rotate column x=0 by 4
rect 4x4
rotate row y=4 by 10
rotate row y=3 by 20
rotate row y=1 by 10
rotate row y=0 by 10
rotate column x=8 by 1
rotate column x=7 by 1
rotate column x=6 by 1
rotate column x=5 by 1
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=1 by 1
rotate column x=0 by 1
rect 9x1
rotate row y=0 by 40
rotate column x=44 by 1
rotate column x=35 by 5
rotate column x=18 by 5
rotate column x=15 by 3
rotate column x=10 by 5
rotate row y=5 by 15
rotate row y=4 by 10
rotate row y=3 by 40
rotate row y=2 by 20
rotate row y=1 by 45
rotate row y=0 by 35
rotate column x=48 by 1
rotate column x=47 by 5
rotate column x=46 by 5
rotate column x=45 by 1
rotate column x=43 by 1
rotate column x=40 by 1
rotate column x=38 by 2
rotate column x=37 by 3
rotate column x=36 by 2
rotate column x=32 by 2
rotate column x=31 by 2
rotate column x=28 by 1
rotate column x=23 by 3
rotate column x=22 by 3
rotate column x=21 by 5
rotate column x=20 by 1
rotate column x=18 by 1
rotate column x=17 by 3
rotate column x=13 by 1
rotate column x=10 by 1
rotate column x=8 by 1
rotate column x=7 by 5
rotate column x=6 by 5
rotate column x=5 by 1
rotate column x=3 by 5
rotate column x=2 by 5
rotate column x=1 by 5";
    }
}