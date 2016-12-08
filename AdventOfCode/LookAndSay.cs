namespace AdventOfCode
{
    public class LookAndSay
    {
        public string RunLookAndSayOnRepeat(string initialInput, int numberOfIterations)
        {
            string input = initialInput;

            for (var i = 0; i < numberOfIterations; i++)
            {
                input = RunLookAndSay(input);
            }

            return input;
        }

        public string RunLookAndSay(string input)
        {
            int iterator = 0;

            string output = "";

            while (iterator < input.Length)
            {
                var numberOfCharacters = GetMatches(input, iterator);
                output += $"{numberOfCharacters}{input[iterator]}";
                iterator += numberOfCharacters;
            }

            return output;
        }

        private int GetMatches(string input, int index)
        {
            int numInSeq = 1;
            bool isMatch = true;
            int start = index + 1;
            while (isMatch && start < input.Length)
            {
                if (input[index] == input[start])
                {
                    numInSeq++;
                    start++;
                }
                else
                {
                    isMatch = false;
                }
            }

            return numInSeq;
        }
    }
}