namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public class CodePad
    {
        public string FindCode(string allInstructions)
        {
            var splitInstruction = allInstructions.Split('\n');
            string code = "";
            int startIndex = 10;

            foreach (var s in splitInstruction)
            {
                var index = GetButtonIndexFromInstruction(s, startIndex);

                var key = GetKeyFromPos(index); //(pos.Item2 * 3) + (pos.Item1 + 1);
                code = code + key;
            }

            return code;
        }

        private string GetPassword(string input)
        {
            string[] lines = input.Split('\n');
            string password = "";
            int[] centerColumnAsciiBase = new int[] { 68, 66, 55, 51, 49 };

            Point pos = new Point(-2, 0);
            Point pos2 = new Point(0, 0);

            Dictionary<char, Point> charMap = new Dictionary<char, Point>(10);
            charMap.Add('L', new Point(-1, 0));
            charMap.Add('R', new Point(1, 0));
            charMap.Add('U', new Point(0, 1));
            charMap.Add('D', new Point(0, -1));

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    char c = lines[i][j];
                    pos2.x = pos.x;
                    pos2.y = pos.y;
                    pos2.Add(charMap[c], 1);
                    if (Math.Abs(pos2.x) + Math.Abs(pos2.y) <= 2)
                    {
                        pos.x = pos2.x;
                        pos.y = pos2.y;
                    }
                }
                password += (char)(centerColumnAsciiBase[pos.y + 2] + pos.x);
            }

            return password;
        }

        private int GetButtonIndexFromInstruction(string instruction, int startIndex)
        {
            var instructonArray = instruction.ToCharArray();
            int currentIndex = startIndex;

            foreach (var i in instructonArray)
            {
                switch (i)
                {
                    case 'U':
                        currentIndex -= 5;
                        if (currentIndex < 0 || GetKeyFromPos(currentIndex) == "-") currentIndex += 5;
                        break;
                    case 'D':
                        currentIndex += 5;
                        if (currentIndex > 25 || GetKeyFromPos(currentIndex) == "-") currentIndex -= 5;
                        break;
                    case 'R':
                        currentIndex++;
                        if (currentIndex > 25 || GetKeyFromPos(currentIndex) == "-") currentIndex--;
                        break;
                    case 'L':
                        currentIndex--;
                        if (currentIndex < 0 || GetKeyFromPos(currentIndex) == "-") currentIndex++;
                        break;
                }
            }

            return currentIndex;
        }

        private Tuple<int, int> ModifyBasedOnPadShape(int x, int y, int prevX, int prevY)
        {
            if ((x == 0 && y == 0) || (x == 1 && y == 0) || (x == 3 && y == 0) || (x == 4 && y == 0)
                || (x == 0 && y == 1) || (x == 4 && y == 1) || (x == 0 && y == 3) || (x == 4 && y == 3)
                || (x == 0 && y == 4) || (x == 1 && y == 4) || (x == 3 && y == 4) || (x == 4 && y == 4)
                || (x < 0) || (y < 0))
            {
                return new Tuple<int, int>(prevX, prevY);
            }

            return new Tuple<int, int>(x, y);
        }

        private string GetKeyFromPos(int pos)
        {
            var keyArray = new string[25]
                           {
                               "-", "-", "1", "-", "-", "-", "2", "3", "4", "-", "5", "6", "7", "8", "9", "-", "A", "B",
                               "C", "-", "-", "-", "D", "-", "-"
                           };

            return keyArray[pos];
        }

        private class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void Add(Point p, int scale)
            {
                x += p.x * scale;
                y += p.y * scale;
            }

            public override string ToString()
            {
                return x + " " + y;
            }
        }
    }
}