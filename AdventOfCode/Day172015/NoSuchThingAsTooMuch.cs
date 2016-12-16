namespace AdventOfCode.Day172015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NoSuchThingAsTooMuch
    {
        private int[] _containers = { 33, 14, 18, 20, 45, 35, 16, 35, 1, 13, 18, 13, 50, 44, 48, 6, 24, 41, 30, 42 };

        public List<List<int>> FindAllCombinationsOfContainersToFit(int liters)
        {
            List<List<int>> validWomboCombos = new List<List<int>>();
            var possibleCombinationCount = ((int)Math.Pow(2, _containers.Length)) - 1;

            foreach (var i in Enumerable.Range(0, possibleCombinationCount))
            {
                var binaryRep = Convert.ToString(i, 2);
                if (binaryRep.Length < _containers.Length)
                {
                    var missing = _containers.Length - binaryRep.Length;
                    StringBuilder sb = new StringBuilder();
                    for (var j = 0; j < missing; j++)
                    {
                        sb.Append("0");
                    }
                    sb.Append(binaryRep);
                    binaryRep = sb.ToString();
                }

                List<int> intsToInclude = new List<int>();
                foreach (var k in Enumerable.Range(0, binaryRep.Length))
                {
                    switch (binaryRep[k])
                    {
                        case '1':
                            intsToInclude.Add(_containers[k]);
                            break;
                    }
                }

                if (intsToInclude.Sum() == liters)
                {
                    validWomboCombos.Add(intsToInclude);
                }
            }

            return validWomboCombos;
        }
    }
}