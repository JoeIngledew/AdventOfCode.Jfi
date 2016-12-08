namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class HowAboutANiceGameOfChess
    {
        public string GetPassword(string doorId)
        {
            int charsFound = 0;
            string password = "";
            int counter = 0;
            List<KeyValuePair<int, string>> foundCharacters = new List<KeyValuePair<int, string>>();

            while (charsFound < 8)
            {    
                string hashable = $"{doorId}{counter}";

                string hash = CalculateHash(hashable);

                if (hash.Substring(0, 5) == "00000")
                {
                    int position = -1;
                    var isValidPos = int.TryParse(hash[5].ToString(), out position);
                    if (!(!isValidPos || position < 0 || position > 7 || foundCharacters.Any(f => f.Key == position)))
                    {
                        var character = hash[6];
                        password += character;
                        foundCharacters.Add(new KeyValuePair<int, string>(position, character.ToString()));
                        charsFound++;
                    }
                }

                counter++;
            }

            string orderedPassword = "";
            for (var i = 0; i < 8; i++)
            {
                orderedPassword += foundCharacters.Single(f => f.Key == i).Value;
            }
            return orderedPassword;
        }

        private string CalculateHash(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}