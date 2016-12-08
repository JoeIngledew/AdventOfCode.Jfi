namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class WrappingPaperCalc
    {
        public WrappingPaperCalc()
        {
            
        }

        public long GetWrappingPaperSqFeetForAllPresents(string allDimensions)
        {
            var splitInput = allDimensions.Split('\n');

            return splitInput.Sum(instruction => GetWrappingPaperSqFeetForSinglePresent(instruction));
        }

        public long GetRibbonFeetForAllPresents(string allDimensions)
        {
            var splitInput = allDimensions.Split('\n');

            return splitInput.Sum(instruction => GetRibbonFeetForSinglePresent(instruction));
        }

        private long GetRibbonFeetForSinglePresent(string dimensions)
        {
            var splitDims = dimensions.Split('x');

            var smallestSide = int.Parse(splitDims.OrderBy(int.Parse).ToList()[0]);
            var secondSmallestSide = int.Parse(splitDims.OrderBy(int.Parse).ToList()[1]);

            var faceCalc = smallestSide + smallestSide + secondSmallestSide + secondSmallestSide;

            var bow = GetBowForDimensions(splitDims);

            return bow + faceCalc;
        }

        private long GetBowForDimensions(string[] dims)
        {
            return int.Parse(dims[0]) * int.Parse(dims[1]) * int.Parse(dims[2]);
        }

        private long GetWrappingPaperSqFeetForSinglePresent(string dimensions)
        {
            var splitDims = dimensions.Split('x');

            var l = int.Parse(splitDims[0]);
            var w = int.Parse(splitDims[1]);
            var h = int.Parse(splitDims[2]);

            var side1 = (l * w);
            var side2 = (w * h);
            var side3 = (h * l);

            var smallest = new List<long>() { side1, side2, side3 }.Min();

            return side1 + side1 + side2 + side2 + side3 + side3 + smallest;
        }
    }
}