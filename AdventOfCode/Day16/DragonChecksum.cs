namespace AdventOfCode.Day16
{
    using System.Collections.Generic;
    using System.Text;

    public class DragonChecksum
    {
        public string GenRandomData(string input, int maxLengthOfDisk)
        {
            var transientInput = input;
            var output = "";
            while (output.Length < maxLengthOfDisk + 1)
            {
                output = GenRandomDataForSingleIteration(transientInput);
                transientInput = output;
            }

            return output.Substring(0, maxLengthOfDisk);
        }

        public string GenChecksum(string input)
        {
            var offset = 0;
            List<string> pairs = new List<string>();
            while (offset < input.Length - 1)
            {
                pairs.Add(input.Substring(offset, 2));
                offset += 2;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var pair in pairs)
            {
                sb.Append(pair[0] == pair[1] ? '1' : '0');
            }

            var checksum = sb.ToString();
            return checksum.Length % 2 == 0 ? GenChecksum(checksum) : checksum;
        }

        private string GenRandomDataForSingleIteration(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (var i = input.Length - 1; i > -1; i--)
            {
                sb.Append(input[i]);
            }

            var b = sb.ToString();
            sb.Clear();

            foreach (var ch in b)
            {
                sb.Append(ch == '0' ? '1' : '0');
            }
            b = sb.ToString();

            return $"{input}0{b}";
        }
    }
}