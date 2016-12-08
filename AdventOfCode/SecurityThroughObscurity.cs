namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SecurityThroughObscurity
    {
        public int GetSumOfValidRoomSectorIds(string inputs)
        {
            var splitInput = inputs.Replace("\r", "").Split('\n');

            int counter = splitInput.Where(IsRoomReal).Sum(ExtractCode);

            return counter;
        }

        public IEnumerable<KeyValuePair<string, int>> GetDecodedRealRooms(string inputs)
        {
            var splitInput = inputs.Replace("\r", "").Split('\n');

            var realRooms = splitInput.Where(IsRoomReal);

            return realRooms.Select(GetDecryptedRoomNameAndId).ToList();           
        } 

        public KeyValuePair<string, int> GetDecryptedRoomNameAndId(string input)
        {
            var shiftAmount = ExtractCode(input);

            var splitString = input.Split('-');
            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < splitString.Length - 1; i++)
            {
                var decoded = RotateChars(splitString[i], shiftAmount);
                sb.Append(decoded);
                sb.Append(" ");
            }

            return new KeyValuePair<string, int>(sb.ToString(), shiftAmount);
        }

        public bool IsRoomReal(string input)
        {
            var checksumMatch = Regex.Match(input, "\\[[a-z]{5}]");
            var checksum = checksumMatch.Value.Replace("[", "").Replace("]", "");

            var trimmedInput = input.Substring(0, input.Length - 11).Replace("-", "");
            var distinctChars = trimmedInput.Distinct();

            Dictionary<char, int> charsWithNumOccurrences = new Dictionary<char, int>();

            foreach (var distinctChar in distinctChars)
            {
                var occurrences = CountOccurrences(trimmedInput, distinctChar);

                charsWithNumOccurrences.Add(distinctChar, occurrences);
            }

            var ordered = charsWithNumOccurrences.OrderByDescending(a => a.Value).ThenBy(a => a.Key).ToList();

            var constructedChecksum =
                $"{ordered[0].Key}{ordered[1].Key}{ordered[2].Key}{ordered[3].Key}{ordered[4].Key}";

            return checksum == constructedChecksum;
        }

        public string RotateChars(string input, int shift)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";

            var smallShift = shift % alphabet.Length;

            if (smallShift == 0)
            {
                return input;
            }

            var sb = new StringBuilder();

            foreach (var character in input)
            {
                var alphaIndex = alphabet.IndexOf(character);
                int actualShift = alphaIndex + smallShift;

                if (actualShift > alphabet.Length - 1)
                {
                    actualShift -= alphabet.Length;
                }

                var newChar = alphabet[actualShift];
                sb.Append(newChar);
            }

            return sb.ToString();
        }

        private int ExtractCode(string input)
        {
            var codeMatch = Regex.Match(input, "[0-9]{3}");

            return int.Parse(codeMatch.Value);
        }

        public int CountOccurrences(string haystack, char needle)
        {
            int count = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle)
                {
                    count++;
                }
            }
            return count;
        }
    }
}