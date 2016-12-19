namespace AdventOfCode.Day17
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using AdventOfCode.Day182015;

    public class TwoStepsForward
    {
        public int FindShortestLengthToVault(string initialCode)
        {
            // solved in python instead. Seemed difficult for C#.
            return 1;
        }

        private List<string> GetAllPossibleRoutes(string startCode)
        {
            return null;
        }

        private List<Door> GetOpenDoors(string code, Point currentLocation)
        {
            string roomHash = GetHash(code);

            List<Point> traversiblePoints = GetTraversiblePoints(currentLocation);

            List<Door> doors = new List<Door>();

            foreach (Point traversiblePoint in traversiblePoints)
            {
                if (traversiblePoint.X < currentLocation.X)
                {
                    doors.Add(new Door { Direction = "L", IsUnlocked = IsOpen(roomHash[2])});
                }
                else if (traversiblePoint.X > currentLocation.X)
                {
                    doors.Add(new Door { Direction = "R", IsUnlocked = IsOpen(roomHash[3]) });
                }
                else if (traversiblePoint.Y < currentLocation.Y)
                {
                    doors.Add(new Door { Direction = "U", IsUnlocked = IsOpen(roomHash[0]) });
                }
                else if (traversiblePoint.Y > currentLocation.Y)
                {
                    doors.Add(new Door { Direction = "D", IsUnlocked = IsOpen(roomHash[1]) });
                }
            }

            return doors.Where(d => d.IsUnlocked).ToList();
        }

        private List<Point> GetTraversiblePoints(Point currentLocation)
        {
            var points = new List<Point>();

            if (currentLocation.X != 0)
            {
                points.Add(new Point(currentLocation.X - 1, currentLocation.Y));
            }
            if (currentLocation.Y != 0)
            {
                points.Add(new Point(currentLocation.X, currentLocation.Y - 1));
            }
            if (currentLocation.X != 3)
            {
                points.Add(new Point(currentLocation.X + 1, currentLocation.Y));
            }
            if (currentLocation.Y != 3)
            {
                points.Add(new Point(currentLocation.X, currentLocation.Y + 1));
            }

            return points;
        }

        private bool IsOpen(char hashChar)
        {
            switch (hashChar)
            {
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                    return true;
                default:
                    return false;
            }
        }

        private string GetHash(string code)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(code);

            byte[] hash = md5.ComputeHash(inputBytes);

            //StringBuilder sb = new StringBuilder();

            //foreach (byte t in hash)
            //{
            //    sb.Append(t.ToString("x2"));
            //}

            //return sb.ToString();

            return ByteArrayToString(hash);
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }

    public class Door
    {
        public string Direction { get; set; }

        public bool IsUnlocked { get; set; }
    }
}