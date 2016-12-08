namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PasswordIncrementer
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        public string GetNextValidPassword(string original)
        {
            var output = IncrementPasswordAtIndex(original, original.Length - 1);

            bool isRule1Done = CheckRule1(output);
            bool isRule2Done = CheckRule2(output);
            bool isRule3Done = CheckRule3(output);


            while (!(isRule1Done && isRule2Done && isRule3Done))
            {
                output = IncrementPasswordAtIndex(output, original.Length - 1);


                isRule1Done = CheckRule1(output);
                isRule2Done = CheckRule2(output);
                isRule3Done = CheckRule3(output);
            }

            return output;
        }

        private string TakeABreak()
        {
            return "Taken a break....";
        }

        public string IncrementPasswordAtIndex(string start, int index)
        {
            var alphaIndexOfCharAtIndex = Alphabet.IndexOf(start[index]);

            var isRollingOver = alphaIndexOfCharAtIndex == Alphabet.Length - 1;

            int nextIndex = isRollingOver ? 0 : alphaIndexOfCharAtIndex + 1;

            var toArr = start.ToCharArray();
            toArr[index] = Alphabet[nextIndex];
            //var backToString = toArr.Aggregate("", (current, c) => current + c);
            var backToString = "";

            foreach (var c in toArr)
            {
                backToString += c;
            }

            if (isRollingOver/* && index > 0*/)
            {
                return IncrementPasswordAtIndex(backToString, index - 1);
            }

            return backToString;
        }

        public bool CheckRule1(string input)
        {
            for (var i = 0; i < input.Length - 2; i++)
            {
                var startCharAlphaIndex = Alphabet.IndexOf(input[i]);

                if (startCharAlphaIndex < Alphabet.Length - 2)
                {
                    if (input[i + 1] == Alphabet[startCharAlphaIndex + 1]
                        && input[i + 2] == Alphabet[startCharAlphaIndex + 2])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckRule2(string input)
        {
            if (input.Contains('i') || input.Contains('o') || input.Contains('l'))
            {
                return false;
            }

            return true;
        }

        public bool CheckRule3(string input)
        {
            int i = 0;
            int doubleChars = 0;

            while (i < input.Length - 1)
            {
                if (input[i] == input[i + 1])
                {
                    doubleChars++;
                    i += 2;
                }
                else
                {
                    i ++;
                }

                if (doubleChars > 1)
                {
                    return true;
                }

                
            }

            return false;
        }
    }
}