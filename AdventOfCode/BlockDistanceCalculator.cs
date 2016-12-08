namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Policy;

    public class BlockDistanceCalculator
    {
        private static readonly Tuple<int, int> StartCoords = new Tuple<int, int>(0, 0);

        private static Facing facing;

        public static int xCoord;

        public static int yCoord;

        public int? xVisitedTwice = null;

        public int? yVisitedTwice = null;

        public List<KeyValuePair<int, int>> CoordHistory = new List<KeyValuePair<int, int>>();

        public BlockDistanceCalculator()
        {
            xCoord = 0;
            yCoord = 0;
            facing = Facing.Up;
            CoordHistory.Add(new KeyValuePair<int, int>(0, 0));
        }

        public void TurnLeft()
        {
            facing += 1;

            if (facing == Facing.Invalid)
            {
                facing = Facing.Up;
            }
        }

        public void TurnRight()
        {
            facing -= 1;

            if (facing == Facing.LowInvalid)
            {
                facing = Facing.Right;
            }
        }

        public void MoveForward(int moveLength)
        {
            for (var i = 0; i < moveLength; i++)
            {
                switch (facing)
                {
                    case Facing.Left:
                        xCoord --;
                        break;
                    case Facing.Right:
                        xCoord ++;
                        break;
                    case Facing.Down:
                        yCoord --;
                        break;
                    case Facing.Up:
                        yCoord ++;
                        break;
                    default:
                        throw new InvalidOperationException("Ended in invalid facing...");
                }

                if (CoordHistory.Any(k => k.Key == xCoord && k.Value == yCoord) && xVisitedTwice == null
                    && yVisitedTwice == null)
                {
                    xVisitedTwice = xCoord;
                    yVisitedTwice = yCoord;
                }

                CoordHistory.Add(new KeyValuePair<int, int>(xCoord, yCoord));
            }
        }

        public void InterperetInstruction(string instruction)
        {
            var trimmedInstruction = instruction.Trim();
            var direction = trimmedInstruction.Substring(0, 1).ToUpper();
            var moveLength = int.Parse(trimmedInstruction.Substring(1));

            switch (direction)
            {
                case "R":
                    TurnRight();
                    break;
                case "L":
                    TurnLeft();
                    break;
                default:
                    throw new InvalidOperationException("Not correct instruction.");
            }

            MoveForward(moveLength);
        }

        public void FollowDirections(string directions)
        {
            var directionList = directions.Split(',');

            foreach (var direction in directionList)
            {
                var trimmedDirection = direction.Trim();

                InterperetInstruction(direction);
            }
        }

        public int BlocksFromStart()
        {
            if (xCoord < 0) xCoord = 0 - xCoord;
            if (yCoord < 0) yCoord = 0 - yCoord;

            var dist = xCoord + yCoord;

            return dist < 0 ? 0 - dist : dist;
        }
    }

    public enum Facing
    {
        LowInvalid = 0,
        Up = 1,
        Left = 2,
        Down = 3,
        Right = 4,
        Invalid = 5
    }
}