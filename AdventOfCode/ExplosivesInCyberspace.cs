namespace AdventOfCode
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public class ExplosivesInCyberspace
    { // wrong - todo
        //public string Decompress(string compressedString)
        //{
        //    int remainingMatches = 1;
        //    string output = "";
        //    string input = compressedString;

        //    do
        //    {
        //        var matches = Regex.Matches(input, "\\([0-9]+[x]{1}[0-9]+\\)");
        //        remainingMatches = matches.Count;

        //        if (remainingMatches > 0)
        //        {
        //            Match thisMatch = matches[0];
        //            var indexToExpandAt = thisMatch.Index + thisMatch.Length;
        //            var indexOfX = thisMatch.Value.IndexOf('x');
        //            var numCharsToRepeat = int.Parse(thisMatch.Value.Substring(1, indexOfX - 1));
        //            var numTimesToRepeat =
        //                int.Parse(
        //                    thisMatch.Value.Substring(
        //                        indexOfX + 1,
        //                        thisMatch.Length - (3 + numCharsToRepeat.ToString().Length)));

        //            var charsToRepeat = input.Substring(indexToExpandAt, numCharsToRepeat);
        //            string replaceString = "";
        //            for (var i = 0; i < numTimesToRepeat; i++)
        //            {
        //                replaceString += charsToRepeat;
        //            }

        //            var start = indexToExpandAt == 0 ? "" : input.Substring(0, indexToExpandAt);
        //            var end = input.Substring(indexToExpandAt);

        //            input = start + replaceString + end;
        //        }
        //        output = input;
        //    }
        //    while (remainingMatches > 0);

        //    return output;
        //}

        public string Decompress(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    var endOfMarkerIndex = input.Substring(i).IndexOf(')');
                    var marker = input.Substring(i, (endOfMarkerIndex) + 1); // should be (AxB)
                    var indexOfXInMarker = marker.IndexOf('x');
                    var numCharsToRepeat = int.Parse(marker.Substring(1, indexOfXInMarker - 1));
                    var numTimesStr = marker.Substring(indexOfXInMarker + 1, marker.Length - (indexOfXInMarker + 2));
                    var numTimesToRepeat = int.Parse(numTimesStr);
                    var patternToRepeat = input.Substring(i + (marker.Length), numCharsToRepeat);
                    //Console.WriteLine($"{marker} - {patternToRepeat.Length}");
                    input = input.Remove(i, marker.Length);
                    for (var j = 0; j < numTimesToRepeat - 1; j++)
                    {
                        input = input.Insert(i, patternToRepeat);
                    }
                    i += (patternToRepeat.Length * (numTimesToRepeat )) - 1;
                    //Console.WriteLine($"{patternToRepeat} repeated {numTimesToRepeat} times [{marker}]");
                    //Console.WriteLine($"Iterator: {i}");
                    // Console.WriteLine($"Num chars: {input.Length} i: {i}");
                }
            }
            return input;
        }

        public string DecompressAndRecurse(string input, bool recurse)
        {
            var isMatch = Regex.IsMatch(input, "\\([0-9]+[x]{1}[0-9]+\\)");
            var newInput = input;
            string output = "";
            int counter = 0;
            while (isMatch)
            {
                Console.WriteLine($"Recursion: {counter}");
                output = Decompress(newInput);
                Console.WriteLine($"Looking for matches");
                isMatch = Regex.IsMatch(output, "\\([0-9]+[x]{1}[0-9]+\\)");
                Console.WriteLine($"Mathes left? {isMatch}");
                if (isMatch)
                {
                    newInput = output;
                }
                Console.WriteLine($"Length: {newInput.Length}");
                counter++;
            }

            return output;
        }
    }
}