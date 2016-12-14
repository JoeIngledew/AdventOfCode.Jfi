namespace AdventOfCode.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public class OneTimePad
    {
        private List<CandidateKey> _candidateKeys;

        private List<CandidateKey> _foundKeys; 

        public OneTimePad()
        {
            _candidateKeys = new List<CandidateKey>();
            _foundKeys = new List<CandidateKey>();
        }

        public long GetThisKey(int numberToGet, string salt)
        {
            int keysGenerated = 0;
            long index = 0;

            //while (_foundKeys.Count < numberToGet)
            while (_foundKeys.Count < numberToGet)
            {
                var hash = GenerateMd5Hash(index, salt);

                var matches = new List<string>();

                for (var i = 0; i < hash.Length - 2; i++)
                {
                    if (hash[i] == hash[i + 1] && hash[i] == hash[i + 2])
                    {
                        //if (i - 1 > -1 && hash[i] == hash[i - 1]){}
                        //else if (i + 3 < hash.Length && hash[i] == hash[i + 3]) { }
                        //else
                        //{
                            matches.Add(hash[i].ToString());
                        //}
                    }
                }
                
                if (matches.Count != 0)
                {
                        //Console.WriteLine($"Candidate key found at index {index}");
                        _candidateKeys.Add(new CandidateKey(matches.First(), hash, index));
                }

                var index1 = index;
                foreach (var candidate in _candidateKeys.Where(ck => ck.Md5Hash != hash && ck.Index > (index - 1000)))
                {
                    var rep = candidate.CharThatAppearsAsAThreeOf;
                    if (hash.Contains($"{rep}{rep}{rep}{rep}{rep}"))
                    {
                        candidate.IsAKey = true;
                        _foundKeys.Add(candidate);
                        keysGenerated++;
                        Console.WriteLine($"Key found: {candidate.Index} (number {keysGenerated}) repChar {candidate.CharThatAppearsAsAThreeOf} hash {candidate.Md5Hash}");
                        Console.WriteLine($"Other hash index: {index}, hash {hash}");
                        Console.WriteLine();
                    }
                }

                index++;
            }

            return _foundKeys.OrderBy(ck => ck.Index).ToList()[63].Index;
        }

        private string GenerateMd5Hash(long index, string salt)
        {
            string input = $"{salt}{index}";

            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            //StringBuilder sb = new StringBuilder();

            //foreach (byte t in hash)
            //{
            //    sb.Append(t.ToString("x2"));
            //}

            //return sb.ToString();

            return ByteArrayToString(hash);
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }

    public class CandidateKey : IEquatable<CandidateKey>
    {
        public CandidateKey(string charThatAppearsAsAThreeOf, string md5Hash, long index)
        {
            CharThatAppearsAsAThreeOf = charThatAppearsAsAThreeOf;
            Md5Hash = md5Hash;
            Index = index;
            IsAKey = false;
        }

        public string Md5Hash { get; }

        public long Index { get; }

        public string CharThatAppearsAsAThreeOf { get; }

        public bool IsAKey { get; set; }

        public bool Equals(CandidateKey other)
        {
            return Md5Hash == other.Md5Hash 
                && Index == other.Index
                && CharThatAppearsAsAThreeOf == other.CharThatAppearsAsAThreeOf 
                && IsAKey == other.IsAKey;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(CandidateKey))
            {
                return Equals((CandidateKey) obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 
                Md5Hash.GetHashCode() ^ Index.GetHashCode() ^ CharThatAppearsAsAThreeOf.GetHashCode() ^ IsAKey.GetHashCode();
        }
    }
}