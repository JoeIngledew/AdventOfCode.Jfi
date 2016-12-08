namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SignalsAndNoise
    {
        public string Decode(string inputStrings)
        {
            var seperatedInputs = inputStrings.Replace("\r", "").Split('\n');

            string output = "";

            for (var i = 0; i < seperatedInputs[0].Trim().Length; i++)
            {
                output += GetMostCommonCharacterAtIndex(i, seperatedInputs);
            }

            return output;
        }

        private string GetMostCommonCharacterAtIndex(int i, string[] seperatedInputs)
        {
            List<string> charactersAtIndex = seperatedInputs.Select(s => s.Trim()[i].ToString()).ToList();
            var distinctChars = charactersAtIndex.Distinct().ToList();

            var lowestCount = 1000;
            var returnChar = "";

            foreach (var c in distinctChars)
            {
                var charCount = charactersAtIndex.Count(s => s == c);

                if (charCount < lowestCount)
                {
                    returnChar = c;
                    lowestCount = charCount;
                }
            }

            return returnChar;
        }
    }
}