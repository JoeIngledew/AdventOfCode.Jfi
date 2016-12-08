namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class IpVerSeven
    {
        public int GetNumberOfIpsThatSupportTls(string ipList)
        {
            var splitList = ipList.Replace("\r", "").Split('\n');

            return splitList.Count(DoesSupportTls);
        }

        public int GetNumberOfIpsThatSupportSsl(string ipList)
        {
            var splitList = ipList.Replace("\r", "").Split('\n');

            return splitList.Count(DoesSupportSsl);
        }


        private bool DoesSupportSsl(string ip)
        {
            MatchCollection insideBracketsStrings = Regex.Matches(ip, "\\[[a-z]*\\]");

            string ipWithReplacedBracketStrings = ip;

            List<string> babs = new List<string>();

            foreach (Match match in insideBracketsStrings)
            {
                babs.AddRange(GetBabs(match.Value.Substring(1, match.Value.Length - 2)));

                ipWithReplacedBracketStrings = ipWithReplacedBracketStrings.Replace(match.Value, "|");
            }

            foreach (var part in ipWithReplacedBracketStrings.Split('|'))
            {
                if (ContainsCorrespondingAba(part, babs))
                {
                    return true;
                }
            }

            return false;
        }

        private bool DoesSupportTls(string ip)
        {
            MatchCollection insideBracketsStrings = Regex.Matches(ip, "\\[[a-z]*\\]");

            string ipWithReplacedBracketStrings = ip;

            foreach (Match match in insideBracketsStrings)
            {
                if (ContainsAbba(match.Value.Substring(1, match.Value.Length - 2)))
                {
                    return false;
                }

                ipWithReplacedBracketStrings = ipWithReplacedBracketStrings.Replace(match.Value, "|");
            }

            foreach (var part in ipWithReplacedBracketStrings.Split('|'))
            {
                if (ContainsAbba(part))
                {
                    return true;
                }
            }

            return false;
        }

        private List<string> GetBabs(string input)
        {
            var babs = new List<string>();

            if (input.Length == 0 || string.IsNullOrEmpty(input))
            {
                return babs;
            }

            int iterator = 0;

            while (iterator < input.Length - 2)
            {
                if (input[iterator] == input[iterator + 2]
                    && input[iterator] != input[iterator + 1])
                {
                    babs.Add(input.Substring(iterator, 3));
                }

                iterator++;
            }

            return babs;
        }

        private bool ContainsCorrespondingAba(string input, List<string> babs)
        {
            if (input.Length == 0 || string.IsNullOrEmpty(input))
            {
                return false;
            }

            int iterator = 0;

            while (iterator < input.Length - 2)
            {
                if (input[iterator] == input[iterator + 2]
                    && input[iterator] != input[iterator + 1])
                {
                    var bab = $"{input[iterator + 1]}{input[iterator]}{input[iterator + 1]}";
                    if (babs.Contains(bab))
                    {
                        return true;
                    }
                }

                iterator++;
            }

            return false;
        }

        private bool ContainsAbba(string input)
        {
            if (input.Length == 0 || string.IsNullOrEmpty(input))
            {
                return false;
            }

            int iterator = 0;

            while (iterator < input.Length - 3)
            {
                if (input[iterator] == input[iterator + 3] && input[iterator + 1] == input[iterator + 2]
                    && input[iterator] != input[iterator + 1])
                {
                    return true;
                }

                iterator++;
            }

            return false;
        }
    }
}